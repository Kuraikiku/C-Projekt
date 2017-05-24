using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Login
{
    class Opening
    {
        Panel panel;
        PictureBox logo;
        Animation background;
        Form1 f;
        public Opening(Panel p, PictureBox pic, Animation background, Form1 f)
        {
            this.f = f;
            panel = p;
            logo = pic;
            this.background = background;
            new Thread(new ThreadStart(startOpening)).Start();
        }

        public void startOpening()
        {
            
            logo.Location = new Point(panel.Location.X - panel.Size.Width, panel.Location.Y + Convert.ToInt32(panel.Size.Height / 2));

            while (logo.Location.X < panel.Location.X+Convert.ToInt32(panel.Size.Width/2)-Convert.ToInt32(logo.Size.Width/2))
            {
                logo.Location = new Point(logo.Location.X + 1, logo.Location.Y);
                Thread.Sleep(50);
            }
        }
    }
}
