﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controls.DataGridView
{
    public class DataGridViewEventArgs : EventArgs
    {

        public Control CellControl { get; set; }

        public int CellIndex { get; set; }

        public int RowIndex { get; set; }

    }
}
