using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI
{
    public class RoundPictureBox : PictureBox
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new System.Drawing.Region(path);
            base.OnPaint(pe);
        }
    }
}
