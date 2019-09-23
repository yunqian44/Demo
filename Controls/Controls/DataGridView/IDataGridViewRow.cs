using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controls.DataGridView
{
    public interface IDataGridViewRow
    {
        event DataGridViewRowCustomEventHandler RowCustomEvent;
        /// <summary>
        /// CheckBox选中事件
        /// </summary>
        event DataGridViewEventHandler CheckBoxChangeEvent;
        /// <summary>
        /// 点击单元格事件
        /// </summary>
        event DataGridViewEventHandler CellClick;
        /// <summary>
        /// 数据源改变事件
        /// </summary>
        event DataGridViewEventHandler SourceChanged;
        /// <summary>
        /// 列参数，用于创建列数和宽度
        /// </summary>
        /// <value>The columns.</value>
        List<DataGridViewColumnEntity> Columns { get; set; }

        bool IsShowCheckBox { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        bool IsChecked { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        /// <value>The data source.</value>
        object DataSource { get; set; }

        /// <summary>
        /// 添加单元格元素，仅做添加控件操作，不做数据绑定，数据绑定使用BindingCells
        /// </summary>
        void ReloadCells();

        /// <summary>
        /// 绑定数据到Cell
        /// </summary>
        void BindingCellData();

        /// <summary>
        /// 设置选中状态，通常为设置颜色即可
        /// </summary>
        void SetSelect(bool blnSelected);

        /// <summary>
        /// 行高
        /// </summary>
        int RowHeight { get; set; }

        /// <summary>
        /// 添加单元格
        /// </summary>
        void AddCells();

        /// <summary>
        /// 绑定新的单元格数据
        /// </summary>
        void BindingAddCellData();

        /// <summary>
        /// 选中行的索引
        /// </summary>
        int RowIndex { get; set; }
    }
}
