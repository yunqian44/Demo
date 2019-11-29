using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace UC.Controls.Controls.TextBox
{
    public partial class UCTextBox : UserControl
    {
        #region 属性

        /// <summary>
        /// 校验属性名
        /// </summary>
        public string ValidateName { get; set; }

        #region 获取焦点是否变色
        private bool isFocusColor = false;
        /// <summary>
        /// 获取焦点是否变色
        /// </summary>
        public bool IsFocusColor
        {
            get { return isFocusColor; }
            set { isFocusColor = value; }
        }
        #endregion

        #region 边框颜色
        private Color borderColor = Color.FromArgb(255, 77, 59);
        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Refresh();
            }
        }
        #endregion

        public string InputText
        {
            get
            {
                return txtInput.Text;
            }
            set
            {
                txtInput.Text = value;
            }
        }

        #endregion

        public UCTextBox()
        {
            InitializeComponent();
            txtInput.GotFocus += (a, b) =>
            {
                this.BorderColor = Color.FromArgb(255, 77, 59);
            };
            txtInput.LostFocus += (a, b) =>
            {
                this.BorderColor = Color.FromArgb(220, 220, 220);
            };
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (IsFocusColor)
            {
                GraphicsPath graphicsPath = new GraphicsPath();
                #region 边框圆角方法
                Rectangle clientRectangle = base.ClientRectangle;
                graphicsPath.AddLine(0f, 0f, clientRectangle.Width, 0);
                graphicsPath.AddLine(clientRectangle.Width, 0, clientRectangle.Width, clientRectangle.Height);
                graphicsPath.AddLine(clientRectangle.Width, clientRectangle.Height, 0, clientRectangle.Height);
                graphicsPath.AddLine(0, clientRectangle.Height, 0f, 0f);
                graphicsPath.CloseFigure();
                #endregion

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                Color rectColor = BorderColor;
                Pen pen = new Pen(rectColor, 1);
                e.Graphics.DrawRectangle(pen,0,0, clientRectangle.Width - 1, clientRectangle.Height - 1);
                //绘制边框 
                pen.Dispose();
            }
            base.OnPaint(e);

        }
    }
}
