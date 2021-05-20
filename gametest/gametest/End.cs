using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gametest
{
    class End : TextBox
    {
        public End(int s)
        {
            this.Size = new Size(200, 80);
            this.Location = new Point(100, 200);
            this.Text = "Hightest score \n" + s;
            this.Multiline = true;
            this.TextAlign = HorizontalAlignment.Center;
            this.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
