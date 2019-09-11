using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Controls.Controls.DataGridView;

namespace Controls.DataGridView
{
    /// <summary>
    /// Class DataGridViewColumnEntity.
    /// </summary>
    public class DataGridViewColumnEntity
    {
        public DataGridViewColumnEntity()
        {
            this.CellType = CellTypeEnum.Label;
        }
        /// <summary>
        /// Gets or sets the head text.
        /// </summary>
        /// <value>The head text.</value>
        public string HeadText { get; set; }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }
        /// <summary>
        /// Gets or sets the type of the width.
        /// </summary>
        /// <value>The type of the width.</value>
        public System.Windows.Forms.SizeType WidthType { get; set; }
        /// <summary>
        /// Gets or sets the data field.
        /// </summary>
        /// <value>The data field.</value>
        public string DataField { get; set; }
        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        public Func<object,dynamic> Format { get; set; }
        /// <summary>
        /// The text align
        /// </summary>
        private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        public ContentAlignment TextAlign { get { return _TextAlign; } set { _TextAlign = value; } }
        /// <summary>
        /// 单元格类型
        /// </summary>
        public CellTypeEnum CellType { get; set; }

        public object DataSource { get; set; }

        public string TextFildName { get; set; }

        public string ValueFildName { get; set; }

    }
}
