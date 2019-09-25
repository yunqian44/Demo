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

        #region 属性
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
        #endregion

        #region 私有方法
        #region 关闭的时间

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
        #endregion

        #region 清理提示框
        /// <summary>
        /// 清理提示框
        /// <summary>
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

        #region 显示提示框
        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="frm">父窗体</param>
        /// <param name="strMsg">提示信息</param>
        /// <param name="intAutoColseTime">自动关闭倒计时(ms:毫秒)</param>
        /// <param name="align">提示框位置</param>
        /// <param name="state">提示框状态</param>
        /// <returns>FrmToastr.</returns>
        private static FrmToastr ShowToastr(
            Form frm,
            string strMsg,
            int intAutoColseTime = 0,
            ContentAlignment align = ContentAlignment.BottomLeft,
            ToastrState state = ToastrState.Info)
        {
            FrmToastr FrmToastr = new FrmToastr();
            FrmToastr.Size = new Size(350, 65);
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
            return FrmToastr;
        }
        #endregion

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
        #endregion

        #region 移除Toastr提示
        /// <summary>
        /// 移除Toastr提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmToastr_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_lstToastr.Remove(this);
            ReshowToastr();
        }
        #endregion

        #endregion

        #region 事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmToastr_Load(object sender, EventArgs e)
        {
            if (m_CloseTime > 0)
            {
                this.timer1.Interval = m_CloseTime;
                this.timer1.Enabled = true;
            }
        }

        #region 释放资源
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs" /> instance containing the event data.</param>
        private void FrmToastr_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }
        #endregion

        #region 关闭事件
        private void BtnClose_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }
        #endregion

        #region 鼠标移入方法
        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            var control = sender as Control;
            //control.Cursor = Cursor.;
        }
        #endregion 
        #endregion

        #region 公开方法

        #region 定时器事件
        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.Close();
        }
        #endregion

        #region 成功提示框
        /// <summary>
        /// 成功提示框
        /// </summary>
        /// <param name="frm">当前父窗体</param>
        /// <param name="strMsg">提示信息</param>
        /// <returns>FrmToastr.</returns>
        public static FrmToastr ShowToastrSuccess(Form frm, string strMsg)
        {
            return FrmToastr.ShowToastr(frm, strMsg, 3000, ContentAlignment.BottomCenter, ToastrState.Success);
        }
        #endregion

        #region 失败提示框
        /// <summary>
        /// 失败提示框
        /// </summary>
        /// <param name="frm">当前父窗体</param>
        /// <param name="strMsg">提示信息</param>
        /// <returns>FrmToastr.</returns>
        public static FrmToastr ShowToastrError(Form frm, string strMsg)
        {
            return FrmToastr.ShowToastr(frm, strMsg, 3000, ContentAlignment.BottomCenter, ToastrState.Error);
        }
        #endregion

        #region 信息提示框
        /// <summary>
        /// 信息提示框
        /// </summary>
        /// <param name="frm">当前父窗体</param>
        /// <param name="strMsg">提示信息</param>
        /// <returns>FrmToastr.</returns>
        public static FrmToastr ShowToastrInfo(Form frm, string strMsg)
        {
            return FrmToastr.ShowToastr(frm, strMsg, 3000, ContentAlignment.BottomCenter, ToastrState.Info);
        }
        #endregion

        #region 警告提示框
        /// <summary>
        /// 警告提示框
        /// </summary>
        /// <param name="frm">当前父窗体</param>
        /// <param name="strMsg">提示信息</param>
        /// <returns>FrmToastr.</returns>
        public static FrmToastr ShowToastrWarning(Form frm, string strMsg)
        {
            return FrmToastr.ShowToastr(frm, strMsg, 3000, ContentAlignment.BottomCenter, ToastrState.Warning);
        }
        #endregion 
        #endregion
    }

    /// <summary>
    /// 通知栏状态
    /// </summary>
    public enum ToastrState
    {
        Success,

        Info,

        Warning,

        Error
    }
}
