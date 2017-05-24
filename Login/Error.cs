using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Error : Form
    {

        public Error(String meldung)
        {
            InitializeComponent();
            zeigeNachricht(meldung);
            waehleBild();
        }

        private void waehleBild()
        {
            pictureBoxChibi.Image = Image.FromFile("Error" + new Random().Next(1, 6) + ".png");
            
        }

        private void zeigeNachricht(String m)
        {
            if(m.Length > 30)
            {
                labelMeldung1.Text =  m.Substring(0, 30);
                labelMeldung2.Text = m.Substring(31);
            }
            else
            {
                labelMeldung1.Text = m;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }
    }
}
