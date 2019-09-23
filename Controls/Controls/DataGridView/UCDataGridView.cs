using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controls.DataGridView;
using System.Collections;
using Controls.Controls.DataGridView;
using Test;

namespace Controls.Controls.DataGridView
{
    public partial class UCDataGridView : UserControl
    {
        #region 属性

        /// <summary>
        /// The m is show CheckBox
        /// </summary>
        private bool m_isShowCheckBox = false;

        /// <summary>
        /// 是否显示复选框
        /// </summary>
        [Description("是否显示选择框"), Category("自定义")]
        public bool IsShowCheckBox
        {
            get { return m_isShowCheckBox; }
            set
            {
                if (value != m_isShowCheckBox)
                {
                    m_isShowCheckBox = value;
                    LoadColumns();
                }
            }
        }

        /// <summary>
        /// 行高
        /// </summary>
        private int m_rowHeight = 40;
        /// <summary>
        /// 行高
        /// </summary>
        /// <value>The height of the row.</value>
        [Description("数据行高"), Category("自定义")]
        public int RowHeight
        {
            get { return m_rowHeight; }
            set { m_rowHeight = value; }
        }

        /// <summary>
        /// 可显示个数
        /// </summary>
        private int m_showCount = 0;
        /// <summary>
        /// 可显示个数
        /// </summary>
        /// <value>The show count.</value>
        [Description("可显示个数"), Category("自定义")]
        public int ShowCount
        {
            get { return m_showCount; }
            private set
            {
                m_showCount = value;
            }
        }

        /// <summary>
        /// 列
        /// </summary>
        private List<DataGridViewColumnEntity> m_columns = null;
        /// <summary>
        /// 列
        /// </summary>
        /// <value>The columns.</value>
        [Description("列"), Category("自定义")]
        public List<DataGridViewColumnEntity> Columns
        {
            get { return m_columns; }
            set
            {
                m_columns = value;
                LoadColumns();
            }
        }

        /// <summary>
        /// The m data source
        /// </summary>
        private object m_dataSource = null;

        /// <summary>
        /// 数据源,支持列表或table，如果使用翻页控件，请使用翻页控件的DataSource
        /// </summary>
        [Description("数据源,支持列表或table，如果使用翻页控件，请使用翻页控件的DataSource"), Category("自定义")]
        public object DataSource
        {
            get { return m_dataSource; }
            set
            {
                if (value != null)
                {
                    if (!(m_dataSource is DataTable) && (!typeof(IList).IsAssignableFrom(value.GetType())))
                    {
                        throw new Exception("数据源不是有效的数据类型，请使用Datatable或列表");
                    }
                }
                m_dataSource = value;
                if (m_columns != null && m_columns.Count > 0)
                {
                    ReloadSource();
                }
            }
        }

        /// <summary>
        /// 行
        /// </summary>
        /// <value>The rows.</value>
        public List<IDataGridViewRow> Rows { get; private set; }

        /// <summary>
        /// 行类型
        /// </summary>
        private Type m_rowType = typeof(UCDataGridViewRow);

        /// <summary>
        /// 行元素类型，默认UCDataGridViewItem
        /// </summary>
        [Description("行控件类型，默认UCDataGridViewRow，如果不满足请自定义行控件实现接口IDataGridViewRow"), Category("自定义")]
        public Type RowType
        {
            get { return m_rowType; }
            set
            {
                if (value == null)
                    return;
                if (!typeof(IDataGridViewRow).IsAssignableFrom(value) || !value.IsSubclassOf(typeof(Control)))
                    throw new Exception("行控件没有实现IDataGridViewRow接口");
                m_rowType = value;
                ResetShowCount();
                if (m_columns != null && m_columns.Count > 0)
                    ReloadSource();
            }
        }
        /// <summary>
        /// 选中行
        /// </summary>
        IDataGridViewRow m_selectRow = null;
        /// <summary>
        /// 选中行
        /// </summary>
        /// <value>The select row.</value>
        [Description("选中行"), Category("自定义")]
        public IDataGridViewRow SelectRow
        {
            get { return m_selectRow; }
            private set { m_selectRow = value; }
        }


        /// <summary>
        /// 选中的行，如果显示CheckBox，则以CheckBox选中为准
        /// </summary>
        /// <value>The select rows.</value>
        [Description("选中的行，如果显示CheckBox，则以CheckBox选中为准"), Category("自定义")]
        public List<IDataGridViewRow> SelectRows
        {
            get
            {
                return GetSelectRows();
            }
        }

        /// <summary>
        /// 获取选中行
        /// </summary>
        /// <returns>List&lt;IDataGridViewRow&gt;.</returns>
        private List<IDataGridViewRow> GetSelectRows()
        {
            List<IDataGridViewRow> lst = new List<IDataGridViewRow>();
            if (m_isShowCheckBox)
            {
                if (Rows != null && Rows.Count > 0)
                    lst.AddRange(Rows.FindAll(p => p.IsChecked));
            }
            else
            {
                if (m_selectRow != null)
                    lst.AddRange(new List<IDataGridViewRow>() { m_selectRow });
            }
            return lst;
        }

        /// <summary>
        /// The m is automatic height
        /// </summary>
        private bool m_isCloseAutoHeight = false;
        /// <summary>
        /// 自动适应最大高度(当为true时，需要手动计算高度，请慎用)
        /// </summary>
        /// <value><c>true</c> if this instance is automatic height; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsCloseAutoHeight
        {
            get { return m_isCloseAutoHeight; }
            set
            {
                m_isCloseAutoHeight = value;
                this.AutoScroll = value;
            }
        }

        /// <summary>
        /// Pages the show source changed.
        /// </summary>
        /// <param name="currentSource">The current source.</param>
        void page_ShowSourceChanged(object currentSource)
        {
            this.DataSource = currentSource;
        }

        #region 事件
        /// <summary>
        /// The head CheckBox change event
        /// </summary>
        [Description("选中标题选择框事件"), Category("自定义")]
        public EventHandler HeadCheckBoxChangeEvent;
        /// <summary>
        /// The head column click event
        /// </summary>
        [Description("标题点击事件"), Category("自定义")]
        public EventHandler HeadColumnClickEvent;
        /// <summary>
        /// Occurs when [item click].
        /// </summary>
        [Description("项点击事件"), Category("自定义")]
        public event DataGridViewEventHandler ItemClick;
        /// <summary>
        /// Occurs when [source changed].
        /// </summary>
        [Description("数据源改变事件"), Category("自定义")]
        public event DataGridViewEventHandler SourceChanged;
        /// <summary>
        /// Occurs when [row custom event].
        /// </summary>
        [Description("预留的自定义的事件，比如你需要在行上放置删改等按钮时，可以通过此事件传递出来"), Category("自定义")]
        public event DataGridViewRowCustomEventHandler RowCustomEvent;
        #endregion
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UCDataGridView" /> class.
        /// </summary>
        public UCDataGridView()
        {
            InitializeComponent();
        }

        #region 私有方法

        #region 加载column
        /// <summary>
        /// 功能描述:加载column
        /// </summary>
        private void LoadColumns()
        {
            try
            {
                if (DesignMode)
                { return; }
                if (this.panColumns == null)
                {
                    return;
                }
                this.panColumns.Controls.Clear();
                this.panColumns.ColumnStyles.Clear();

                if (m_columns != null && m_columns.Count() > 0)
                {
                    int intColumnsCount = m_columns.Count();
                    if (m_isShowCheckBox)
                    {
                        intColumnsCount++;
                    }
                    this.panColumns.ColumnCount = intColumnsCount;
                    for (int i = 0; i < intColumnsCount; i++)
                    {
                        Control c = null;
                        if (i == 0 && m_isShowCheckBox)
                        {
                            this.panColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Absolute, 30F));

                            CheckBox box = new CheckBox();
                            box.Text = "";
                            box.Size = new Size(30, 30);
                            box.CheckedChanged += (a, b) =>
                            {
                                Rows.ForEach(p => p.IsChecked = box.Checked);
                                if (HeadCheckBoxChangeEvent != null)
                                {
                                    HeadCheckBoxChangeEvent(a, b);
                                }
                            };
                            c = box;
                        }
                        else
                        {
                            var item = m_columns[i - (m_isShowCheckBox ? 1 : 0)];
                            this.panColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(item.WidthType, item.Width));
                            Label lbl = new Label();
                            lbl.Name = "dgvColumns_" + i;
                            lbl.Text = item.HeadText;
                            lbl.Font = new Font("微软雅黑", 12F); ;
                            lbl.ForeColor = Color.Black;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.AutoSize = false;
                            lbl.Dock = DockStyle.Fill;
                            lbl.MouseDown += (a, b) =>
                            {
                                if (HeadColumnClickEvent != null)
                                {
                                    HeadColumnClickEvent(a, b);
                                }
                            };
                            c = lbl;
                        }
                        this.panColumns.Controls.Add(c, i, 0);
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        /// <summary>
        /// 获取显示个数
        /// </summary>
        /// <returns>返回值</returns>
        private void ResetShowCount()
        {
            if (DesignMode)
            { return; }
            if (this.Height <= 0)
                return;
            ShowCount = this.panRow.Height / (m_rowHeight);
            if (ShowCount == 0)
                return;
            int intCha = this.panRow.Height % (m_rowHeight);
            m_rowHeight += intCha / ShowCount;
        }
        #endregion

        #region 公共函数

        #region 新增行
        /// <summary>
        /// 刷新数据
        /// </summary>
        public void AddRow(object rowData)
        {
            if (DesignMode)
            { return; }
            try
            {
                this.panRow.Controls.Clear();
                Rows = new List<IDataGridViewRow>();
                if (m_columns == null || m_columns.Count <= 0)
                    return;
                if (m_dataSource != null)
                {
                    int index = 0;

                    #region 新增的行
                    if (m_dataSource != null)
                    {
                        IDataGridViewRow row = (IDataGridViewRow)Activator.CreateInstance(m_rowType);
                        if (m_dataSource is DataTable)
                        {
                            row.DataSource = (m_dataSource as DataTable).NewRow();
                        }
                        else if (typeof(IList).IsAssignableFrom(m_dataSource.GetType()))
                        {
                            var type = (m_dataSource as IList)[0].GetType();
                            var model = Activator.CreateInstance(type);
                            var type1 = rowData.GetType();
                            var props = type.GetProperties();
                            var rowDataProps = type1.GetProperties();
                            foreach (var prop in props)
                            {
                                if (prop.CanWrite)
                                {
                                    foreach (var rowDataProp in rowDataProps)
                                    {
                                        try
                                        {
                                            if (prop.Name == rowDataProp.Name)
                                            {
                                                var data = rowDataProp.GetValue(rowData, null);
                                                if (data != DBNull.Value)
                                                {
                                                    prop.SetValue(model, Convert.ChangeType(data, prop.PropertyType), null);
                                                }
                                            }
                                        }
                                        catch (IndexOutOfRangeException)
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                            row.DataSource = model;
                        }
                        row.RowIndex = index;
                        row.Columns = m_columns;
                        row.IsShowCheckBox = m_isShowCheckBox;
                        row.AddCells();
                        row.BindingAddCellData();

                        Control addRowControl = (row as Control);
                        this.panRow.Controls.Add(addRowControl);
                        row.RowHeight = m_rowHeight;
                        addRowControl.Dock = DockStyle.Top;
                        row.CellClick += (a, b) => { SetSelectRow(addRowControl, b); };
                        row.CheckBoxChangeEvent += (a, b) => { SetSelectRow(addRowControl, b); };
                        row.RowCustomEvent += (a, b) => { if (RowCustomEvent != null) { RowCustomEvent(a, b); } };
                        row.SourceChanged += RowSourceChanged;
                        addRowControl.BringToFront();
                        Rows.Add(row);
                        ++index;
                    }
                    #endregion

                    #region 旧的数据源
                    Control lastItem = null;
                    int intSourceCount = 0;
                    if (m_dataSource is DataTable)
                    {
                        intSourceCount = (m_dataSource as DataTable).Rows.Count;
                    }
                    else if (typeof(IList).IsAssignableFrom(m_dataSource.GetType()))
                    {
                        intSourceCount = (m_dataSource as IList).Count;
                    }

                    for (int i = 0; i < intSourceCount; i++)
                    {
                        IDataGridViewRow row = (IDataGridViewRow)Activator.CreateInstance(m_rowType);
                        if (m_dataSource is DataTable)
                        {
                            row.DataSource = (m_dataSource as DataTable).Rows[i];
                        }
                        else
                        {
                            row.DataSource = (m_dataSource as IList)[i];
                        }
                        row.Columns = m_columns;
                        row.RowIndex = index;
                        row.IsShowCheckBox = m_isShowCheckBox;
                        row.ReloadCells();
                        row.BindingCellData();


                        Control rowControl = (row as Control);
                        this.panRow.Controls.Add(rowControl);
                        row.RowHeight = m_rowHeight;
                        rowControl.Dock = DockStyle.Top;
                        row.CellClick += (a, b) => { SetSelectRow(rowControl, b); };
                        row.CheckBoxChangeEvent += (a, b) => { SetSelectRow(rowControl, b); };
                        row.RowCustomEvent += (a, b) => { if (RowCustomEvent != null) { RowCustomEvent(a, b); } };
                        row.SourceChanged += RowSourceChanged;
                        rowControl.BringToFront();
                        Rows.Add(row);
                        ++index;

                        if (lastItem == null)
                            lastItem = rowControl;
                    }

                    if (lastItem != null && intSourceCount == m_showCount)
                    {
                        lastItem.Height = this.panRow.Height - (m_showCount - 1) * m_rowHeight;
                    }
                    #endregion
                }
                else
                {
                    foreach (Control item in this.panRow.Controls)
                    {
                        item.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 刷新数据
        /// <summary>
        /// 刷新数据
        /// </summary>
        public void ReloadSource(int t = 0)
        {
            if (DesignMode)
            { return; }
            try
            {
                //ControlHelper.FreezeControl(this.panRow, true);
                this.panRow.Controls.Clear();
                Rows = new List<IDataGridViewRow>();
                if (m_columns == null || m_columns.Count <= 0)
                    return;
                if (m_dataSource != null)
                {
                    int index = 0;
                    Control lastItem = null;

                    int intSourceCount = 0;
                    if (m_dataSource is DataTable)
                    {
                        intSourceCount = (m_dataSource as DataTable).Rows.Count;
                    }
                    else if (typeof(IList).IsAssignableFrom(m_dataSource.GetType()))
                    {
                        intSourceCount = (m_dataSource as IList).Count;
                    }

                    for (int i = 0; i < intSourceCount; i++)
                    {
                        IDataGridViewRow row = (IDataGridViewRow)Activator.CreateInstance(m_rowType);
                        if (m_dataSource is DataTable)
                        {
                            row.DataSource = (m_dataSource as DataTable).Rows[i];
                        }
                        else
                        {
                            row.DataSource = (m_dataSource as IList)[i];
                        }
                        row.Columns = m_columns;
                        row.RowIndex = index;
                       
                        List<Control> lstCells = new List<Control>();
                        row.IsShowCheckBox = m_isShowCheckBox;
                        row.ReloadCells();
                        row.BindingCellData();


                        Control rowControl = (row as Control);
                        this.panRow.Controls.Add(rowControl);
                        row.RowHeight = m_rowHeight;
                        rowControl.Dock = DockStyle.Top;
                        row.CellClick += (a, b) => { SetSelectRow(rowControl, b); };
                        row.CheckBoxChangeEvent += (a, b) => { SetSelectRow(rowControl, b); };
                        row.RowCustomEvent += (a, b) => { if (RowCustomEvent != null) { RowCustomEvent(a, b); } };
                        row.SourceChanged += RowSourceChanged;
                        rowControl.BringToFront();
                        Rows.Add(row);
                        ++index;
                        if (lastItem == null)
                            lastItem = rowControl;
                    }

                    if (lastItem != null && intSourceCount == m_showCount)
                    {
                        lastItem.Height = this.panRow.Height - (m_showCount - 1) * m_rowHeight;
                    }
                }
                else
                {
                    foreach (Control item in this.panRow.Controls)
                    {
                        item.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 移除行
        /// <summary>
        /// 移除行
        /// </summary>
        /// <param name="rowIndex"></param>
        public void RemoveRow(int rowIndex)
        {
            if (DesignMode)
            { return; }
            try
            {
                this.panRow.Controls.Clear();
                var NewRows = new List<IDataGridViewRow>();
                if (m_columns == null || m_columns.Count <= 0)
                    return;
                if (this.Rows != null)
                {
                    int index = 0;
                    Control lastItem = null;
                    int intSourceCount = 0;
                    intSourceCount = this.Rows.Count;

                    for (int i = 0; i < intSourceCount; i++)
                    {
                        if (i == rowIndex)
                            continue;

                        IDataGridViewRow row = (IDataGridViewRow)Activator.CreateInstance(m_rowType);
                        row.DataSource = this.Rows[i].DataSource;
                        row.Columns = m_columns;
                        row.RowIndex = index;
                        List<Control> lstCells = new List<Control>();
                        row.IsShowCheckBox = m_isShowCheckBox;
                        row.ReloadCells();
                        row.BindingCellData();


                        Control rowControl = (row as Control);
                        this.panRow.Controls.Add(rowControl);
                        row.RowHeight = m_rowHeight;
                        rowControl.Dock = DockStyle.Top;
                        row.CellClick += (a, b) => { SetSelectRow(rowControl, b); };
                        row.CheckBoxChangeEvent += (a, b) => { SetSelectRow(rowControl, b); };
                        row.RowCustomEvent += (a, b) => { if (RowCustomEvent != null) { RowCustomEvent(a, b); } };
                        row.SourceChanged += RowSourceChanged;
                        rowControl.BringToFront();
                        NewRows.Add(row);
                        ++index;

                        if (lastItem == null)
                            lastItem = rowControl;
                    }

                    if (lastItem != null && intSourceCount == m_showCount)
                    {
                        lastItem.Height = this.panRow.Height - (m_showCount - 1) * m_rowHeight;
                    }
                }
                else
                {
                    foreach (Control item in this.panRow.Controls)
                    {
                        item.Visible = false;
                    }
                }
                Rows.Clear();
                Rows.AddRange(NewRows);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 移除行
        /// <summary>
        /// 移除行
        /// </summary>
        /// <param name="rowIndex"></param>
        public void EditRow(int rowIndex)
        {
            if (DesignMode)
            { return; }
            try
            {
                this.panRow.Controls.Clear();
                var NewRows = new List<IDataGridViewRow>();
                if (m_columns == null || m_columns.Count <= 0)
                    return;
                if (this.Rows != null)
                {
                    int index = 0;
                    Control lastItem = null;
                    int intSourceCount = 0;
                    intSourceCount = this.Rows.Count;

                    for (int i = 0; i < intSourceCount; i++)
                    {
                       

                        IDataGridViewRow row = (IDataGridViewRow)Activator.CreateInstance(m_rowType);
                        row.DataSource = this.Rows[i].DataSource;
                        row.Columns = m_columns;
                        row.RowIndex = index;
                        List<Control> lstCells = new List<Control>();
                        row.IsShowCheckBox = m_isShowCheckBox;
                        if (i == rowIndex)
                        {
                            row.AddCells();
                            row.BindingAddCellData();
                        }
                        else {
                            row.ReloadCells();
                            row.BindingCellData();
                        }

                        Control rowControl = (row as Control);
                        this.panRow.Controls.Add(rowControl);
                        row.RowHeight = m_rowHeight;
                        rowControl.Dock = DockStyle.Top;
                        row.CellClick += (a, b) => { SetSelectRow(rowControl, b); };
                        row.CheckBoxChangeEvent += (a, b) => { SetSelectRow(rowControl, b); };
                        row.RowCustomEvent += (a, b) => { if (RowCustomEvent != null) { RowCustomEvent(a, b); } };
                        row.SourceChanged += RowSourceChanged;
                        rowControl.BringToFront();
                        NewRows.Add(row);
                        ++index;

                        if (lastItem == null)
                            lastItem = rowControl;
                    }

                    if (lastItem != null && intSourceCount == m_showCount)
                    {
                        lastItem.Height = this.panRow.Height - (m_showCount - 1) * m_rowHeight;
                    }
                }
                else
                {
                    foreach (Control item in this.panRow.Controls)
                    {
                        item.Visible = false;
                    }
                }
                Rows.Clear();
                Rows.AddRange(NewRows);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #endregion

        #region 事件
        /// <summary>
        /// Rows the source changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewEventArgs" /> instance containing the event data.</param>
        void RowSourceChanged(object sender, DataGridViewEventArgs e)
        {
            if (SourceChanged != null)
                SourceChanged(sender, e);
        }
        /// <summary>
        /// Sets the select row.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="e">The <see cref="DataGridViewEventArgs" /> instance containing the event data.</param>
        private void SetSelectRow(Control item, DataGridViewEventArgs e)
        {
            try
            {
                if (item == null)
                    return;
                if (item.Visible == false)
                    return;
                this.FindForm().ActiveControl = this;
                this.FindForm().ActiveControl = item;
                if (m_selectRow != item)
                {
                    if (m_selectRow != null)
                    {
                        m_selectRow.SetSelect(false);
                    }
                    m_selectRow = item as IDataGridViewRow;
                    m_selectRow.SetSelect(true);

                    if (this.panRow.Controls.Count > 0)
                    {
                        if (item.Location.Y < 0)
                        {
                            this.panRow.AutoScrollPosition = new Point(0, Math.Abs(this.panRow.Controls[this.panRow.Controls.Count - 1].Location.Y) + item.Location.Y);
                        }
                        else if (item.Location.Y + m_rowHeight > this.panRow.Height)
                        {
                            this.panRow.AutoScrollPosition = new Point(0, Math.Abs(this.panRow.AutoScrollPosition.Y) + item.Location.Y - this.panRow.Height + m_rowHeight);
                        }
                    }
                }


                if (ItemClick != null)
                {
                    ItemClick(item, e);
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Handles the Resize event of the UCDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UCDataGridView_Resize(object sender, EventArgs e)
        {
            if (this.Height <= 0)
                return;
            if (m_isCloseAutoHeight)
                return;
            ResetShowCount();
            ReloadSource();
        }
        #endregion
    }
}
