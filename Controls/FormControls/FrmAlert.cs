using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UC.Controls.Controls.TextBox;

namespace UC.Controls.FormControls
{
    public partial class FrmAlert : Form
    {
        public FrmAlert()
        {
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }

        #region 属性
        /// <summary>
        /// Alter显示的对象
        /// </summary>
        private static FrmAlert frmAlert;

        public Action<object> CallBackEvent;

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
        public static void ClearAlert()
        {
            var current = frmAlert;
            if (!current.IsDisposed)
            {
                current.Close();
                current.Dispose();
            }
        }
        #endregion

        #region 显示提示框
        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="frm">父窗体</param>
        /// <param name="result">校验结果</param>
        /// <param name="action">回调方法</param>
        /// <param name="intAutoColseTime">自动关闭倒计时(ms:毫秒)</param>
        /// <returns>FrmToastr.</returns>
        private static void ShowAlter(Form frm, ValidationResult result, Action<object> action, int intAutoColseTime = 0)
        {
            if (frmAlert != null)
            {
                ClearAlert();
            }
            frmAlert = new FrmAlert();
            frmAlert.CallBackEvent = action;
            frmAlert.lblMsg.ForeColor = Color.Black;
            frmAlert.pctStat.Image = UC.Controls.Properties.Resources.Fail;
            frmAlert.BackColor = Color.White;
            frmAlert.CloseTime = intAutoColseTime;
            

            var controls = frm.Controls;
            for (int i = 0; i < controls.Count; i++)
            {
                var textBox = controls[i] as UCTextBox;
                if (textBox != null)
                {
                    result.Errors.ToList().ForEach((a) => {
                        if (a.PropertyName.Equals(textBox.ValidateName))
                        {
                            frmAlert.lblMsg.Text = a.ErrorMessage;
                            textBox.IsFocusColor = true;
                            frmAlert.CallBackEvent(controls[i]);
                        }
                    });
                }
            }
            var sumHeight = 65;//总行高
            var height = 21;//单行高度
            var row = 3;
            var rowNum = (int)Math.Ceiling(frmAlert.lblMsg.Text.Length * 1.00 / 17);
            if (rowNum > 3)
            {
                sumHeight = sumHeight + (rowNum - row) * height;
            }
            frmAlert.Size = new Size(350, sumHeight >= 600 ? 600 : sumHeight);
            frmAlert.Owner = frm;
            frmAlert.BringToFront();
            frmAlert.Show(frm);
            lock (frmAlert)
            {
                if (frmAlert != null)
                {
                    Size size = Screen.PrimaryScreen.Bounds.Size;
                    frmAlert.Location = new Point((size.Width - frmAlert.Width) / 2, size.Height - (size.Height - (frmAlert.Height + 10)) / 2 - (frmAlert.Height + 10));
                }
            }
        }
        #endregion

        #endregion

        #region 事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAlert_Load(object sender, EventArgs e)
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
        /// <param name="e"></param>
        private void FrmAlert_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            GC.Collect();
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

        #region 警告提示框
        /// <summary>
        /// 警告提示框
        /// </summary>
        /// <param name="frm">当前父窗体</param>
        /// <param name="strMsg">提示信息</param>
        /// <returns>FrmToastr.</returns>
        public static void Alert(Form frm, ValidationResult result, Action<object> action)
        {
            FrmAlert.ShowAlter(frm, result, action, 2000);
        }
        #endregion

        #endregion
    }
}
