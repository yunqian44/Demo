using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Controls.Controls.DataGridView;

namespace Controls.DataGridView
{
    public class DataGridViewColumnEntity
    {
        public DataGridViewColumnEntity()
        {
            this.CellType = CellTypeEnum.Label;
        }

        /// <summary>
        /// 单元格标题
        /// </summary>
        public string HeadText { get; set; }

        /// <summary>
        /// 宽度大小
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 单元格宽度类型
        /// </summary>
        public System.Windows.Forms.SizeType WidthType { get; set; }

        /// <summary>
        /// 数据绑定列
        /// </summary>
        public string DataField { get; set; }

        /// <summary>
        /// 单元格格式化方法
        /// </summary>
        public Func<object,dynamic> Format { get; set; }


        /// <summary>
        /// 文本对齐方式
        /// </summary>
        private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
        public ContentAlignment TextAlign { get { return _TextAlign; } set { _TextAlign = value; } }
        
        /// <summary>
        /// 单元格类型
        /// </summary>
        public CellTypeEnum CellType { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        public object DataSource { get; set; }

        /// <summary>
        /// 显示字段（配合DataSource使用）
        /// </summary>
        public string TextFildName { get; set; }

        /// <summary>
        /// 绑定值字段（配合DataSource使用）
        /// </summary>
        public string ValueFildName { get; set; }

        /// <summary>
        /// 绑定事件（配置BindControlName使用）
        /// </summary>
        public Action<object, object> BindEvent { get; set; }

        /// <summary>
        /// 绑定控件字段
        /// </summary>
        public string BindControlName { get; set; }

    }
}
