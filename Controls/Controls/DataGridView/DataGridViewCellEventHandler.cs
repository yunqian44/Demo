using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Controls.DataGridView
{
    [Serializable]
    [ComVisible(true)]
    public delegate void DataGridViewEventHandler(object sender, DataGridViewEventArgs e);

    [Serializable]
    [ComVisible(true)]
    public delegate void DataGridViewRowCustomEventHandler(object sender, DataGridViewRowCustomEventArgs e);
}
