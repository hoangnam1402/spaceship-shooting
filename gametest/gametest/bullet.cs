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
    class bullet : PictureBox
    {
        public bullet(int left,int top,string tag,Color c)
        {
            
            this.BackColor = c;
            this.Height = 8;
            this.Width = 5;
            this.Left = left;
            this.Top = top;
            this.Tag = tag;
            
            /*this.col = c;
            this.hei = 8;
            this.wit = 5;
            this.lef = left;
            this.top = top;
            this.tag = tag;*/

        }
       
    }
}
