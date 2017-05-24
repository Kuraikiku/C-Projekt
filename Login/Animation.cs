using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Login
{
    public class Animation
    {
        private Control ziel;
        private Image[] bilder;
        private int delay;
        private Boolean wiederholt;
        private Boolean aktiv;
        private Thread t;

        #region Getter/Setter
        public Control Ziel
        {
            get
            {
                return ziel;
            }

            set
            {
                ziel = value;
            }
        }

        public Image[] Bilder
        {
            get
            {
                return bilder;
            }

            set
            {
                bilder = value;
            }
        }

        public int Delay
        {
            get
            {
                return delay;
            }

            set
            {
                delay = value;
            }
        }

        public bool Wiederholt
        {
            get
            {
                return wiederholt;
            }

            set
            {
                wiederholt = value;
            }
        }

        public bool Aktiv
        {
            get
            {
                return aktiv;
            }

            set
            {
                aktiv = value;
            }
        }
        #endregion

        public Animation(Control ziel, Image[] bilder, int delay, Boolean wiederholung)
        {
            Ziel = ziel;
            Bilder = bilder;
            Delay = delay;
            Wiederholt = wiederholung;
        }

        public void starteAnimation()
        {
            Aktiv = true;
            t = new Thread(new ThreadStart(run));
            t.Start();
            
        }

        private void run()
        {
            
            while(Aktiv == true)
            {
                try
                {
                    foreach (Image img in Bilder)
                    {
                        Ziel.BackgroundImage = img;
                        System.Threading.Thread.Sleep(delay);
                    }
                    if (wiederholt == false)
                    {
                        stopAnimation();
                    }
                }
                catch (ThreadInterruptedException)
                {
                    t.Interrupt();
                }
            }
        }

        public void stopAnimation()
        {
            Aktiv = false;
            t.Interrupt();
            
        }
    }
}
