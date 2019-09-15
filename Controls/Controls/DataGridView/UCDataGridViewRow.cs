using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controls.DataGridView;

namespace Controls.Controls.DataGridView
{
    [ToolboxItem(false)]
    public partial class UCDataGridViewRow : UserControl, IDataGridViewRow
    {
        #region 属性
        /// <summary>
        /// CheckBox选中事件
        /// </summary>
        public event DataGridViewEventHandler CheckBoxChangeEvent;
        /// <summary>
        /// Occurs when [row custom event].
        /// </summary>
        public event DataGridViewRowCustomEventHandler RowCustomEvent;
        /// <summary>
        /// 点击单元格事件
        /// </summary>
        public event DataGridViewEventHandler CellClick;

        /// <summary>
        /// 数据源改变事件
        /// </summary>
        public event DataGridViewEventHandler SourceChanged;

        /// <summary>
        /// 列参数，用于创建列数和宽度
        /// </summary>
        /// <value>The columns.</value>
        public List<DataGridViewColumnEntity> Columns
        {
            get;
            set;
        }

        public object DataSource
        {
            get;
            set;
        }

        public bool IsShowCheckBox
        {
            get;
            set;
        }

        /// <summary>
        /// 选中行的索引
        /// </summary>
        public int RowIndex { get; set; }

        private bool m_isChecked;

        public bool IsChecked
        {
            get
            {
                return m_isChecked;
            }

            set
            {
                if (m_isChecked != value)
                {
                    m_isChecked = value;
                    (this.panCells.Controls.Find("check", false)[0] as CheckBox).Checked = value;
                }
            }
        }
        /// <summary>
        /// The m row height
        /// </summary>
        int m_rowHeight = 40;
        /// <summary>
        /// 行高
        /// </summary>
        /// <value>The height of the row.</value>
        public int RowHeight
        {
            get
            {
                return m_rowHeight;
            }
            set
            {
                m_rowHeight = value;
                this.Height = value;
            }
        }

        #endregion

        public UCDataGridViewRow()
        {
            InitializeComponent();
        }
        #region 绑定数据到Cell
        /// <summary>
        /// 绑定数据到Cell
        /// </summary>
        /// <returns>返回true则表示已处理过，否则将进行默认绑定（通常只针对有Text值的控件）</returns>
        public void BindingCellData()
        {
            for (int i = 0; i < Columns.Count; i++)
            {
                DataGridViewColumnEntity com = Columns[i];
                var cs = this.panCells.Controls.Find("lbl_" + com.DataField, false);
                if (cs != null && cs.Length > 0)
                {
                    var pro = DataSource.GetType().GetProperty(com.DataField);
                    if (pro != null)
                    {
                        var value = pro.GetValue(DataSource, null);
                        if (com.Format != null)
                        {
                            cs[0].Text = com.Format(value);
                        }
                        else
                        {
                            cs[0].Text = value.ToString();
                        }
                    }
                }
            }
        }
        #endregion

        #region  绑定数据到新的Cell
        /// <summary>
        /// 绑定数据到Cell
        /// </summary>
        /// <returns>返回true则表示已处理过，否则将进行默认绑定（通常只针对有Text值的控件）</returns>
        public void BindingAddCellData()
        {
            for (int i = 0; i < Columns.Count; i++)
            {
                if (DataSource != null)
                {
                    DataGridViewColumnEntity com = Columns[i];
                    Control[] cs = null;
                    if (com.CellType == CellTypeEnum.Text || com.CellType == CellTypeEnum.Label)
                    {
                        if (com.CellType == CellTypeEnum.Label)
                        {
                            cs = this.panCells.Controls.Find("lbl_" + com.DataField, false);

                        }
                        else if (com.CellType == CellTypeEnum.Text)
                        {
                            cs = this.panCells.Controls.Find("tb_" + com.DataField, false);
                        }
                        if (cs != null && cs.Length > 0)
                        {
                            var pro = DataSource.GetType().GetProperty(com.DataField);
                            if (pro != null)
                            {
                                var value = Convert.ChangeType(pro.GetValue(DataSource, null), pro.PropertyType);
                                if (value != null)
                                {
                                    if (com.Format != null)
                                    {
                                        cs[0].Text = com.Format(value);
                                    }
                                    else
                                    {
                                        cs[0].Text = value.ToString();
                                    }
                                }
                                else
                                {
                                    cs[0].Text = string.Empty;
                                }
                            }
                        }

                    }
                    else if (com.CellType == CellTypeEnum.ComboBox || com.CellType == CellTypeEnum.NumericUpDown)
                    {
                        if (com.CellType == CellTypeEnum.ComboBox)
                        {
                            cs = this.panCells.Controls.Find("cb_" + com.DataField, false);
                            var cell = cs[0] as ComboBox;

                            if (cs != null && cs.Length > 0)
                            {
                                cell.DisplayMember = com.TextFildName;
                                cell.ValueMember = com.ValueFildName;
                                cell.DataSource = com.DataSource;
                                var pro = DataSource.GetType().GetProperty(com.DataField);
                                if (pro != null)
                                {
                                    var value = Convert.ChangeType(pro.GetValue(DataSource, null), pro.PropertyType);
                                    if (value != null)
                                    {
                                        if (com.Format != null)
                                        {
                                            cell.SelectedValue = value;
                                            cell.Text = com.Format(value);
                                        }
                                        else
                                        {
                                            cell.SelectedValue = value;
                                        }
                                    }
                                    else
                                    {
                                        cell.SelectedValue = 0;
                                    }
                                }
                            }
                        }
                        else if (com.CellType == CellTypeEnum.NumericUpDown)
                        {
                            cs = this.panCells.Controls.Find("num_" + com.DataField, false);
                            var cell = cs[0] as NumericUpDown;
                            if (cs != null && cs.Length > 0)
                            {
                                var pro = DataSource.GetType().GetProperty(com.DataField);
                                if (pro != null)
                                {
                                    var value = Convert.ChangeType(pro.GetValue(DataSource, null), pro.PropertyType);
                                    if (value != null)
                                    {
                                        if (com.Format != null)
                                        {
                                            cell.Value = com.Format(value);
                                        }
                                        else
                                        {
                                            cell.Value = decimal.Parse(value.ToString());
                                        }
                                    }
                                    else
                                    {
                                        cell.Value = 0;
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
        #endregion

        #region MyRegion
        /// <summary>
        /// Handles the MouseDown event of the Item control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        public void Item_MouseDown(object sender, MouseEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(this, new DataGridViewEventArgs()
                {
                    CellControl = this,
                    CellIndex = int.Parse((sender as Control).Tag.ToString())
                });
            }
        }
        #endregion

        #region 设置选中状态，通常为设置颜色即可
        /// <summary>
        /// 设置选中状态，通常为设置颜色即可
        /// </summary>
        /// <param name="blnSelected">是否选中</param>
        public void SetSelect(bool blnSelected)
        {
            if (blnSelected)
            {
                this.BackColor = Color.FromArgb(255, 247, 245);
            }
            else
            {
                this.BackColor = Color.Transparent;
            }
        }
        #endregion

        #region 添加新的单元格
        /// <summary>
        /// 添加新的单元格
        /// </summary>
        public void AddCells()
        {
            var dic = new Dictionary<Dictionary<string, string>, Action<object, object>>();
            try
            {
                this.panCells.Controls.Clear();
                this.panCells.ColumnStyles.Clear();
                int intColumnsCount = Columns.Count();
                if (Columns != null && intColumnsCount > 0)
                {
                    if (IsShowCheckBox)
                    {
                        intColumnsCount++;
                    }

                    this.panCells.ColumnCount = intColumnsCount;
                    for (int i = 0; i < intColumnsCount; i++)
                    {
                        Control c = null;
                        if (i == 0 && IsShowCheckBox)
                        {
                            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Absolute, 30F));
                            CheckBox box = new CheckBox();
                            box.Name = "check";
                            box.Text = "";
                            box.Size = new Size(30, 30);
                            box.Dock = DockStyle.Fill;
                            box.CheckedChanged += (a, b) =>
                            {
                                IsChecked = box.Checked;
                                if (CheckBoxChangeEvent != null)
                                {
                                    CheckBoxChangeEvent(a, new DataGridViewEventArgs()
                                    {
                                        CellControl = box,
                                        CellIndex = 0
                                    });
                                }
                            };
                            c = box;
                        }
                        else
                        {
                            var item = Columns[i - (IsShowCheckBox ? 1 : 0)];
                            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(item.WidthType, item.Width));
                            if (item.CellType == CellTypeEnum.Label)
                            {
                                Label lbl = new Label();
                                lbl.Tag = i - (IsShowCheckBox ? 1 : 0);
                                lbl.Name = "lbl_" + item.DataField;
                                lbl.Font = new Font("微软雅黑", 12);
                                lbl.ForeColor = Color.Black;
                                lbl.AutoSize = false;
                                lbl.Dock = DockStyle.Fill;
                                lbl.TextAlign = item.TextAlign;
                                lbl.MouseDown += (a, b) =>
                                {
                                    Item_MouseDown(a, b);
                                };
                                c = lbl;
                            }
                            else if (item.CellType == CellTypeEnum.Text)
                            {
                                TextBox tb = new TextBox();
                                tb.Tag = i - (IsShowCheckBox ? 1 : 0);
                                tb.Name = "tb_" + item.DataField;
                                tb.Font = new Font("微软雅黑", 12);
                                tb.ForeColor = Color.Black;
                                tb.AutoSize = true;
                                tb.Dock = DockStyle.Fill;
                                tb.TextAlign = HorizontalAlignment.Center;
                                tb.MouseDown += (a, b) =>
                                {
                                    Item_MouseDown(a, b);
                                };
                                c = tb;
                            }
                            else if (item.CellType == CellTypeEnum.ComboBox)
                            {
                                ComboBox cb = new ComboBox();
                                cb.Tag = i - (IsShowCheckBox ? 1 : 0);
                                cb.Name = "cb_" + item.DataField;
                                cb.Font = new Font("微软雅黑", 12);
                                cb.ForeColor = Color.Black;
                                cb.AutoSize = true;
                                cb.Dock = DockStyle.Fill;
                                cb.MouseDown += (a, b) =>
                                {
                                    Item_MouseDown(a, b);
                                };
                                c = cb;
                                if (item.BindEvent != null
                                    && !string.IsNullOrEmpty(item.BindControlName)
                                    && item.DataField != item.BindControlName)
                                {
                                    var key = new Dictionary<string, string>();
                                    key.Add(cb.Name, "cb_" + item.BindControlName);

                                    dic.Add(key, item.BindEvent);
                                }
                            }
                            else if (item.CellType == CellTypeEnum.NumericUpDown)
                            {
                                NumericUpDown num = new NumericUpDown();
                                num.Tag = i - (IsShowCheckBox ? 1 : 0);
                                num.Name = "num_" + item.DataField;
                                num.Font = new Font("微软雅黑", 12);
                                num.ForeColor = Color.Black;
                                num.AutoSize = true;
                                num.Dock = DockStyle.Fill;
                                num.MouseDown += (a, b) =>
                                {
                                    Item_MouseDown(a, b);
                                };
                                c = num;
                            }
                        }
                        this.panCells.Controls.Add(c, i, 0);
                    }
                }

                if (dic != null && dic.Count > 0)
                {
                    foreach (var key in dic.Keys)
                    {
                        foreach (var item in key)
                        {
                            var sourceControls = this.panCells.Controls.Find(item.Key, false);
                            var controls = this.panCells.Controls.Find(item.Value, false);
                            if (sourceControls != null && sourceControls.Length > 0
                                && controls != null && controls.Length > 0)
                            {
                                var sourceControl = sourceControls[0] as ComboBox;
                                var control = controls[0] as ComboBox;
                                sourceControl.SelectedValueChanged += (a, b) =>
                                {
                                    if (sourceControl.Items != null
                                    &&sourceControl.Items.Count>0
                                    && control.Items != null
                                    && control.Items.Count>0)
                                    {
                                        dic[key](sourceControl, control);
                                    }
                                };
                            }
                        }
                    }

                }
            }
            finally
            {
                //ControlHelper.FreezeControl(this, false);
            }
        }
        #endregion

        #region 重新绘制单元格
        /// <summary>
        /// 重新绘制单元格
        /// </summary>
        public void ReloadCells()
        {
            try
            {

                this.panCells.Controls.Clear();
                this.panCells.ColumnStyles.Clear();

                int intColumnsCount = Columns.Count();
                if (Columns != null && intColumnsCount > 0)
                {
                    if (IsShowCheckBox)
                    {
                        intColumnsCount++;
                    }
                    this.panCells.ColumnCount = intColumnsCount;
                    for (int i = 0; i < intColumnsCount; i++)
                    {
                        Control c = null;
                        if (i == 0 && IsShowCheckBox)
                        {
                            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Absolute, 30F));

                            CheckBox box = new CheckBox();
                            box.Name = "check";
                            box.Text = "";
                            box.Size = new Size(30, 30);
                            box.Dock = DockStyle.Fill;
                            box.CheckedChanged += (a, b) =>
                            {
                                IsChecked = box.Checked;
                                if (CheckBoxChangeEvent != null)
                                {
                                    CheckBoxChangeEvent(a, new DataGridViewEventArgs()
                                    {
                                        CellControl = box,
                                        CellIndex = 0
                                    });
                                }
                            };
                            c = box;
                        }
                        else
                        {
                            var item = Columns[i - (IsShowCheckBox ? 1 : 0)];
                            this.panCells.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(item.WidthType, item.Width));

                            Label lbl = new Label();
                            lbl.Tag = i - (IsShowCheckBox ? 1 : 0);
                            lbl.Name = "lbl_" + item.DataField;
                            lbl.Font = new Font("微软雅黑", 12);
                            lbl.ForeColor = Color.Black;
                            lbl.AutoSize = false;
                            lbl.Dock = DockStyle.Fill;
                            lbl.TextAlign = item.TextAlign;
                            lbl.MouseDown += (a, b) =>
                            {
                                Item_MouseDown(a, b);
                            };
                            c = lbl;

                        }
                        this.panCells.Controls.Add(c, i, 0);
                    }
                }
            }
            finally
            {
                //ControlHelper.FreezeControl(this, false);
            }
        }
        #endregion
    }
}
