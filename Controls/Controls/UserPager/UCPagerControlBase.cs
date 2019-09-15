﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controls.UserPager
{
    /// <summary>
    /// Class UCPagerControlBase.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// Implements the <see cref="HZH_Controls.Controls.IPageControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    /// <seealso cref="HZH_Controls.Controls.IPageControl" />
    [ToolboxItem(false)]
    public class UCPagerControlBase : UserControl, IPageControl
    {
        #region 构造
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UCPagerControlBase
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "UCPagerControlBase";
            this.Size = new System.Drawing.Size(304, 58);
            this.Load += new System.EventHandler(this.UCPagerControlBase_Load);
            this.ResumeLayout(false);

        }

        #endregion
        #endregion
        /// <summary>
        /// 总页数
        /// </summary>
        /// <value>The page count.</value>
        public virtual int PageCount
        {
            get;
            set;
        }
        /// <summary>
        /// The m page index
        /// </summary>
        private int m_pageIndex = 1;
        /// <summary>
        /// 当前页码
        /// </summary>
        /// <value>The index of the page.</value>
        public virtual int PageIndex
        {
            get { return m_pageIndex; }
            set { m_pageIndex = value; }
        }
        private List<object> dataSource;
        /// <summary>
        /// 关联的数据源
        /// </summary>
        /// <value>The data source.</value>
        public virtual List<object> DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;
            }
        }
        /// <summary>
        /// 数据源改变时发生
        /// </summary>
        public virtual event PageControlEventHandler ShowSourceChanged;
        /// <summary>
        /// The m page size
        /// </summary>
        private int m_pageSize = 1;
        /// <summary>
        /// 每页显示数量
        /// </summary>
        /// <value>The size of the page.</value>
        [Description("每页显示数量"), Category("自定义")]
        public virtual int PageSize
        {
            get { return m_pageSize; }
            set { m_pageSize = value; }
        }
        /// <summary>
        /// The start index
        /// </summary>
        private int startIndex = 0;
        /// <summary>
        /// 开始的下标
        /// </summary>
        /// <value>The start index.</value>
        [Description("开始的下标"), Category("自定义")]
        public virtual int StartIndex
        {
            get { return startIndex; }
            set
            {
                startIndex = value;
                if (startIndex <= 0)
                    startIndex = 0;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UCPagerControlBase" /> class.
        /// </summary>
        public UCPagerControlBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the UCPagerControlBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UCPagerControlBase_Load(object sender, EventArgs e)
        {
            if (DataSource == null)
                ShowBtn(false, false);
            else
            {
                ShowBtn(false, DataSource.Count > PageSize);
            }
        }
        /// <summary>
        /// 第一页
        /// </summary>
        public virtual void FirstPage()
        {
            startIndex = 0;
            var s = GetCurrentSource();

            if (ShowSourceChanged != null)
            {
                ShowSourceChanged(s);
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        public virtual void PreviousPage()
        {
            if (startIndex == 0)
                return;
            startIndex -= m_pageSize;
            if (startIndex < 0)
                startIndex = 0;
            var s = GetCurrentSource();

            if (ShowSourceChanged != null)
            {
                ShowSourceChanged(s);
            }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        public virtual void NextPage()
        {

            if (startIndex + m_pageSize >= DataSource.Count)
            {
                return;
            }
            startIndex += m_pageSize;
            if (startIndex < 0)
                startIndex = 0;
            var s = GetCurrentSource();

            if (ShowSourceChanged != null)
            {
                ShowSourceChanged(s);
            }
        }
        /// <summary>
        /// 最后一页
        /// </summary>
        public virtual void EndPage()
        {
            if (DataSource == null)
            {
                if (ShowSourceChanged != null)
                {
                    ShowSourceChanged(null);
                }
                return;
            }
            startIndex = DataSource.Count - m_pageSize;
            if (startIndex < 0)
                startIndex = 0;
            var s = GetCurrentSource();

            if (ShowSourceChanged != null)
            {
                ShowSourceChanged(s);
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        public virtual void Reload()
        {
            var s = GetCurrentSource();
            if (ShowSourceChanged != null)
            {
                ShowSourceChanged(s);
            }
        }
        /// <summary>
        /// 获取当前页数据
        /// </summary>
        /// <returns>List&lt;System.Object&gt;.</returns>
        public virtual List<object> GetCurrentSource()
        {
            if (DataSource == null || DataSource.Count <= 0)
                return null;
            int intShowCount = m_pageSize;
            if (intShowCount + startIndex > DataSource.Count)
                intShowCount = DataSource.Count - startIndex;
            object[] objs = new object[intShowCount];
            DataSource.CopyTo(startIndex, objs, 0, intShowCount);
            var lst = objs.ToList();

            bool blnLeft = false;
            bool blnRight = false;
            if (lst.Count > 0)
            {
                if (DataSource.IndexOf(lst[0]) > 0)
                {
                    blnLeft = true;
                }
                else
                {
                    blnLeft = false;
                }
                if (DataSource.IndexOf(lst[lst.Count - 1]) >= DataSource.Count - 1)
                {
                    blnRight = false;
                }
                else
                {
                    blnRight = true;
                }
            }
            ShowBtn(blnLeft, blnRight);
            return lst;
        }

        /// <summary>
        /// 控制按钮显示
        /// </summary>
        /// <param name="blnLeftBtn">是否显示上一页，第一页</param>
        /// <param name="blnRightBtn">是否显示下一页，最后一页</param>
        protected virtual void ShowBtn(bool blnLeftBtn, bool blnRightBtn)
        { }
    }
}
