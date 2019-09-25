using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controls.FormControls
{
    public partial class FrmToastr : Form
    {
        public FrmToastr()
        {
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }

        /// <summary>
        /// Toastr显示个数
        /// </summary>
        private static List<FrmToastr> m_lstToastr = new List<FrmToastr>();

        /// <summary>
        /// 显示的位置
        /// </summary>
        private ContentAlignment m_showAlign = ContentAlignment.BottomLeft;

        /// <summary>
        /// 显示位置
        /// </summary>
        /// <value>The show align.</value>
        public ContentAlignment ShowAlign
        {
            get { return m_showAlign; }
            set { m_showAlign = value; }
        }

        /// <summary>
        /// 关闭的时间
        /// </summary>
        private int m_CloseTime = 0;

        /// <summary>
        /// 关闭的时间
        /// </summary>
        /// <value>The close time.</value>
        public int CloseTime
        {
            get { return m_CloseTime; }
            set
            {
                m_CloseTime = value;
                if (value > 0)
                    timer1.Interval = value;
            }
        }

       

        #region 清理提示框
        /// <summary>
        /// 功能描述:清理提示框
        /// 作　　者:HZH
        /// 创建日期:2019-02-28 15:11:03
        /// 任务编号:POS
        /// </summary>
        public static void ClearToastr()
        {
            for (int i = m_lstToastr.Count - 1; i >= 0; i--)
            {
                FrmToastr current = m_lstToastr[i];
                if (!current.IsDisposed)
                {
                    current.Close();
                    current.Dispose();
                }
            }
            m_lstToastr.Clear();
        }
        #endregion

        #region 重置倒计时
        /// <summary>
        /// 重置倒计时
        /// </summary>
        private void ResetTimer()
        {
            if (m_CloseTime > 0)
            {
                timer1.Enabled = false;
                timer1.Enabled = true;
            }
        } 
        #endregion

        /// <summary>
        /// The m last tips
        /// </summary>
        private static KeyValuePair<string, FrmToastr> m_lastToastr = new KeyValuePair<string, FrmToastr>();

        /// <summary>
        /// Shows the tips.
        /// </summary>
        /// <param name="frm">The FRM.</param>
        /// <param name="strMsg">The string MSG.</param>
        /// <param name="intAutoColseTime">The int automatic colse time.</param>
        /// <param name="blnShowCoseBtn">if set to <c>true</c> [BLN show cose BTN].</param>
        /// <param name="align">The align.</param>
        /// <param name="point">The point.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="size">The size.</param>
        /// <param name="state">The state.</param>
        /// <param name="color">The color.</param>
        /// <returns>FrmToastr.</returns>
        private static FrmToastr ShowToastr(
            Form frm,
            string strMsg,
            int intAutoColseTime = 0,
            ContentAlignment align = ContentAlignment.BottomLeft,
            ToastrSizeMode mode = ToastrSizeMode.Small,
            ToastrState state = ToastrState.Info)
        {

            if (m_lastToastr.Key == strMsg + state && !m_lastToastr.Value.IsDisposed && m_lastToastr.Value.Visible)
            {
                m_lastToastr.Value.ResetTimer();
                return m_lastToastr.Value;
            }
            else
            {
                FrmToastr FrmToastr = new FrmToastr();
                switch (mode)
                {
                    case ToastrSizeMode.Small:
                        FrmToastr.Size = new Size(350, 35);
                        break;
                    case ToastrSizeMode.Medium:
                        FrmToastr.Size = new Size(350, 50);
                        break;
                    case ToastrSizeMode.Large:
                        FrmToastr.Size = new Size(350, 65);
                        break;
                    case ToastrSizeMode.None:
                            FrmToastr.Size = new Size(350, 35);
                        break;
                }


                
                FrmToastr.lblMsg.ForeColor = Color.White;
                switch (state)
                {
                    case ToastrState.Success:
                        FrmToastr.pctStat.Image = UC.Controls.Properties.Resources.Success;
                        FrmToastr.BackColor = Color.FromArgb(82, 169, 82);
                        break;
                    case ToastrState.Info:
                        FrmToastr.pctStat.Image = UC.Controls.Properties.Resources.Info;
                        FrmToastr.BackColor = Color.FromArgb(92, 170, 194);
                        break;
                    case ToastrState.Warning:
                        FrmToastr.pctStat.Image = UC.Controls.Properties.Resources.Warning;
                        FrmToastr.BackColor = Color.FromArgb(249, 169, 62);
                        break;
                    case ToastrState.Error:
                        FrmToastr.pctStat.Image = UC.Controls.Properties.Resources.Error;
                        FrmToastr.BackColor = Color.FromArgb(188, 57, 51);
                        break;
                    default:
                        break;
                }

                FrmToastr.lblMsg.Text = strMsg;
                FrmToastr.CloseTime = intAutoColseTime;
                FrmToastr.btnClose.Visible = true;


                FrmToastr.ShowAlign = align;
                FrmToastr.Owner = frm;
                FrmToastr.m_lstToastr.Add(FrmToastr);
                FrmToastr.Show(frm);
                FrmToastr.ReshowToastr(); 
                FrmToastr.BringToFront();
                m_lastToastr = new KeyValuePair<string, FrmToastr>(strMsg + state, FrmToastr);
                return FrmToastr;
            }
        }

        #region 重置位置
        /// <summary>
        /// 重置位置
        /// </summary>
        public static void ReshowToastr()
        {
            lock (FrmToastr.m_lstToastr)
            {
                FrmToastr.m_lstToastr.RemoveAll(p => p.IsDisposed == true);
                var enumerable = from p in FrmToastr.m_lstToastr
                                 group p by new
                                 {
                                     p.ShowAlign
                                 };
                Size size = Screen.PrimaryScreen.Bounds.Size;
                foreach (var item in enumerable)
                {
                    List<FrmToastr> list = FrmToastr.m_lstToastr.FindAll((FrmToastr p) => p.ShowAlign == item.Key.ShowAlign);
                    for (int i = 0; i < list.Count; i++)
                    {
                        FrmToastr FrmToastr = list[i];
                        if (FrmToastr.InvokeRequired)
                        {
                            FrmToastr.BeginInvoke(new MethodInvoker(delegate ()
                            {
                                switch (item.Key.ShowAlign)
                                {
                                    case ContentAlignment.BottomCenter:
                                        FrmToastr.Location = new Point((size.Width - FrmToastr.Width) / 2, size.Height - 100 - (i + 1) * (FrmToastr.Height + 10));
                                        break;
                                    case ContentAlignment.BottomLeft:
                                        FrmToastr.Location = new Point(10, size.Height - 100 - (i + 1) * (FrmToastr.Height + 10));
                                        break;
                                    case ContentAlignment.BottomRight:
                                        FrmToastr.Location = new Point(size.Width - FrmToastr.Width - 10, size.Height - 100 - (i + 1) * (FrmToastr.Height + 10));
                                        break;
                                    case ContentAlignment.MiddleCenter:
                                        FrmToastr.Location = new Point((size.Width - FrmToastr.Width) / 2, size.Height - (size.Height - list.Count * (FrmToastr.Height + 10)) / 2 - (i + 1) * (FrmToastr.Height + 10));
                                        break;
                                    case ContentAlignment.MiddleLeft:
                                        FrmToastr.Location = new Point(10, size.Height - (size.Height - list.Count * (FrmToastr.Height + 10)) / 2 - (i + 1) * (FrmToastr.Height + 10));
                                        break;
                                    case ContentAlignment.MiddleRight:
                                        FrmToastr.Location = new Point(size.Width - FrmToastr.Width - 10, size.Height - (size.Height - list.Count * (FrmToastr.Height + 10)) / 2 - (i + 1) * (FrmToastr.Height + 10));
                                        break;
                                    case ContentAlignment.TopCenter:
                                        FrmToastr.Location = new Point((size.Width - FrmToastr.Width) / 2, 10 + (i + 1) * (FrmToastr.Height + 10));
                                        break;
                                    case ContentAlignment.TopLeft:
                                        FrmToastr.Location = new Point(10, 10 + (i + 1) * (FrmToastr.Height + 10));
                                        break;
                                    case ContentAlignment.TopRight:
                                        FrmToastr.Location = new Point(size.Width - FrmToastr.Width - 10, 10 + (i + 1) * (FrmToastr.Height + 10));
                                        break;
                                    default:
                                        break;
                                }
                            }));
                        }
                        else
                        {
                            switch (item.Key.ShowAlign)
                            {
                                case ContentAlignment.BottomCenter:
                                    FrmToastr.Location = new Point((size.Width - FrmToastr.Width) / 2, size.Height - 100 - (i + 1) * (FrmToastr.Height + 10));
                                    break;
                                case ContentAlignment.BottomLeft:
                                    FrmToastr.Location = new Point(10, size.Height - 100 - (i + 1) * (FrmToastr.Height + 10));
                                    break;
                                case ContentAlignment.BottomRight:
                                    FrmToastr.Location = new Point(size.Width - FrmToastr.Width - 10, size.Height - 100 - (i + 1) * (FrmToastr.Height + 10));
                                    break;
                                case ContentAlignment.MiddleCenter:
                                    FrmToastr.Location = new Point((size.Width - FrmToastr.Width) / 2, size.Height - (size.Height - list.Count * (FrmToastr.Height + 10)) / 2 - (i + 1) * (FrmToastr.Height + 10));
                                    break;
                                case ContentAlignment.MiddleLeft:
                                    FrmToastr.Location = new Point(10, size.Height - (size.Height - list.Count * (FrmToastr.Height + 10)) / 2 - (i + 1) * (FrmToastr.Height + 10));
                                    break;
                                case ContentAlignment.MiddleRight:
                                    FrmToastr.Location = new Point(size.Width - FrmToastr.Width - 10, size.Height - (size.Height - list.Count * (FrmToastr.Height + 10)) / 2 - (i + 1) * (FrmToastr.Height + 10));
                                    break;
                                case ContentAlignment.TopCenter:
                                    FrmToastr.Location = new Point((size.Width - FrmToastr.Width) / 2, 10 + (i + 1) * (FrmToastr.Height + 10));
                                    break;
                                case ContentAlignment.TopLeft:
                                    FrmToastr.Location = new Point(10, 10 + (i + 1) * (FrmToastr.Height + 10));
                                    break;
                                case ContentAlignment.TopRight:
                                    FrmToastr.Location = new Point(size.Width - FrmToastr.Width - 10, 10 + (i + 1) * (FrmToastr.Height + 10));
                                    break;
                                default:
                                    break;
                            }
                        }

                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Handles the FormClosing event of the FrmToastr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs" /> instance containing the event data.</param>
        private void FrmToastr_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_lastToastr.Value == this)
                m_lastToastr = new KeyValuePair<string, FrmToastr>();
            m_lstToastr.Remove(this);
            ReshowToastr();

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].IsDisposed || !Application.OpenForms[i].Visible || Application.OpenForms[i] is FrmToastr)
                {
                    continue;
                }
                else
                {
                    Timer t = new Timer();
                    t.Interval = 100;
                    var frm = Application.OpenForms[i];
                    t.Tick += (a, b) =>
                    {
                        t.Enabled = false;
                        if (!frm.IsDisposed)
                        {
                            //ControlHelper.SetForegroundWindow(frm.Handle);
                        }
                    };
                    t.Enabled = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmToastr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmToastr_Load(object sender, EventArgs e)
        {
            if (m_CloseTime > 0)
            {
                this.timer1.Interval = m_CloseTime;
                this.timer1.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.Close();
        }

        /// <summary>
        /// Handles the MouseDown event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            this.timer1.Enabled = false;
            this.Close();
        }

        /// <summary>
        /// Shows the tips success.
        /// </summary>
        /// <param name="frm">The FRM.</param>
        /// <param name="strMsg">The string MSG.</param>
        /// <returns>FrmToastr.</returns>
        public static FrmToastr ShowToastrSuccess(Form frm, string strMsg)
        {
            return FrmToastr.ShowToastr(frm, strMsg, 3000, ContentAlignment.BottomCenter, ToastrSizeMode.Large, ToastrState.Success);
        }

        /// <summary>
        /// Shows the tips error.
        /// </summary>
        /// <param name="frm">The FRM.</param>
        /// <param name="strMsg">The string MSG.</param>
        /// <returns>FrmToastr.</returns>
        public static FrmToastr ShowToastrError(Form frm, string strMsg)
        {
            return FrmToastr.ShowToastr(frm, strMsg, 3000, ContentAlignment.BottomCenter, ToastrSizeMode.Large, ToastrState.Error);
        }

        /// <summary>
        /// Shows the tips information.
        /// </summary>
        /// <param name="frm">The FRM.</param>
        /// <param name="strMsg">The string MSG.</param>
        /// <returns>FrmToastr.</returns>
        public static FrmToastr ShowToastrInfo(Form frm, string strMsg)
        {
            return FrmToastr.ShowToastr(frm, strMsg, 3000, ContentAlignment.BottomCenter, ToastrSizeMode.Large, ToastrState.Info);
        }

        /// <summary>
        /// 显示警告框
        /// </summary>
        /// <param name="frm">The FRM.</param>
        /// <param name="strMsg">The string MSG.</param>
        /// <returns>FrmToastr.</returns>
        public static FrmToastr ShowToastrWarning(Form frm, string strMsg)
        {
            return FrmToastr.ShowToastr(frm, strMsg, 3000, ContentAlignment.BottomCenter, ToastrSizeMode.Large, ToastrState.Warning);
        }

        /// <summary>
        /// Handles the FormClosed event of the FrmToastr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs" /> instance containing the event data.</param>
        private void FrmToastr_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    public enum ToastrState 
    {
        Success,

        Info,

        Warning,

        Error
    }

    /// <summary>
    /// Enum ToastrSizeMode
    /// </summary>
    public enum ToastrSizeMode
    {
        /// <summary>
        /// The small
        /// </summary>
        Small,
        /// <summary>
        /// The medium
        /// </summary>
        Medium,
        /// <summary>
        /// The large
        /// </summary>
        Large,
        /// <summary>
        /// The none
        /// </summary>
        None
    }
}
