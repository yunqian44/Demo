using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UC.Controls.Controls.TextBox
{
    public class EXTextBox : System.Windows.Forms.TextBox
    {
        public EXTextBox()
        {
            FontFamily fontFamily = new FontFamily("宋体");
            System.Drawing.Font myFont = new Font(fontFamily, 11);
            this.Font = myFont;
        }
    }
}
