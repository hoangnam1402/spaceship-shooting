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
    class obj : PictureBox
    {
        public int hei { get; set; }
        public int wit { get; set; }
        public int top { get; set; }
        public int lef { get; set; }
        public Color col { get; set; }
        public string tag { get; set; }

        public obj(int hei,int wit, int top,int lef,Color col,string tag)
        {
            this.Height = hei;
            this.Width = wit;
            this.Left = lef;
            this.Top = top;
            this.BackColor = col;
            this.Tag = tag;
        }

        public obj()
        {
            this.Height = hei;
            this.Width = wit;
            this.Left = lef;
            this.Top = top;
            this.BackColor = col;
            this.Tag = tag;
        }
    }
}
