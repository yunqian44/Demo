using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC.Controls.Controls.Btn
{
    [DefaultEvent("BtnClick")]

    public partial class UCBtnExt : UserControl, IContainerControl
    {
        /// <summary>
        /// 按钮点击事件
        /// </summary>
        [Description("按钮点击事件"), Category("自定义")]
        public event EventHandler BtnClick;

        private bool enabledMouseEffect = true;


        #region 属性
        [Description("是否启用鼠标效果"), Category("自定义")]
        public bool EnabledMouseEffect
        {
            get { return enabledMouseEffect; }
            set { enabledMouseEffect = value; }
        }

        /// <summary>
        /// 按钮背景色
        /// </summary>
        private Color _btnBackColor = Color.White;

        /// <summary>
        /// 按钮背景色
        /// </summary>
        [Description("按钮背景色"), Category("自定义")]
        public Color BtnBackColor
        {
            get { return _btnBackColor; }
            set
            {
                _btnBackColor = value;
                this.BackColor = value;
            }
        }

        /// <summary>
        /// 按钮字体颜色
        /// </summary>
        private Color _btnForeColor = Color.White;

        /// <summary>
        /// 按钮字体颜色
        /// </summary>
        [Description("按钮字体颜色"), Category("自定义")]
        public virtual Color BtnForeColor
        {
            get { return _btnForeColor; }
            set
            {
                _btnForeColor = value;
                this.lbl.ForeColor = value;
            }
        }

        /// <summary>
        /// 按钮字体
        /// </summary>
        private Font _btnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

        /// <summary>
        /// 按钮字体
        /// </summary>
        [Description("按钮字体"), Category("自定义")]
        public Font BtnFont
        {
            get { return _btnFont; }
            set
            {
                _btnFont = value;
                this.lbl.Font = value;
            }
        }

        /// <summary>
        /// The BTN text
        /// </summary>
        private string _btnText;
        /// <summary>
        /// 按钮文字
        /// </summary>
        /// <value>The BTN text.</value>
        [Description("按钮文字"), Category("自定义")]
        public virtual string BtnText
        {
            get { return _btnText; }
            set
            {
                _btnText = value;
                lbl.Text = value;
            }
        }

        [Description("鼠标效果生效时发生，需要和MouseEffected同时使用，否则无效"), Category("自定义")]
        public event EventHandler MouseEffecting;

        [Description("鼠标效果结束时发生，需要和MouseEffecting同时使用，否则无效"), Category("自定义")]
        public event EventHandler MouseEffected;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UCBtnExt" /> class.
        /// </summary>
        public UCBtnExt()
        {
            InitializeComponent();
            this.TabStop = false;
            this.lbl.MouseEnter += lbl_MouseEnter;
            this.lbl.MouseLeave += lbl_MouseLeave;
        }
        Color m_cacheColor = Color.Empty;

        void lbl_MouseLeave(object sender, EventArgs e)
        {
            if (enabledMouseEffect)
            {
                if (MouseEffecting != null && MouseEffected != null)
                {
                    MouseEffected(this, e);
                }
                //else
                //{
                //    if (m_cacheColor != Color.Empty)
                //    {
                //        this.FillColor = m_cacheColor;
                //        m_cacheColor = Color.Empty;
                //    }
                //}
            }
        }

        void lbl_MouseEnter(object sender, EventArgs e)
        {
            if (enabledMouseEffect)
            {
                if (MouseEffecting != null && MouseEffected != null)
                {
                    MouseEffecting(this, e);
                }
                //else
                //{
                //    if (FillColor != Color.Empty && FillColor != null)
                //    {
                //        m_cacheColor = this.FillColor;
                //        this.FillColor = Color.FromArgb(230, this.FillColor);
                //    }
                //}
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the lbl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void lbl_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.BtnClick != null)
                BtnClick(this, e);
        }
    }
}
