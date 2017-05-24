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
    public partial class SettingsGUI : Form
    {
        Einstellungen einst;
        Image buttonBack;
        Animation a;
        public SettingsGUI(Einstellungen e, Animation a, Image bB)
        {
            InitializeComponent();
            Einst = e;
            fuelleFelder();
            buttonBack = bB;
            this.a = a;

        }
        #region Getter/Setter
        public Einstellungen Einst
        {
            get
            {
                return einst;
            }

            set
            {
                einst = value;
            }
        }
        #endregion

        private void fuelleFelder()
        {
            textBoxIP.Text = einst.Ip;
            textBoxPort.Text = einst.Port;
            foreach (String lied in einst.Lieder)
            {
                comboBoxLieder.Items.Add(lied);
            }
            comboBoxLieder.SelectedIndex = comboBoxLieder.Items.IndexOf(Einst.SelLied);
            trackBarLautstaerke.Value = Einst.Lautstaerke;
            
        }

        

        private void aendereEinstellungen()
        {
            Einst.Ip = textBoxIP.Text;
            Einst.Port = textBoxPort.Text;
            if (!comboBoxLieder.SelectedItem.ToString().Equals(Einst.SelLied))
            {
                Einst.SelLied = comboBoxLieder.SelectedItem.ToString();
                Einst.stopMusic();
                Einst.playMusic();
            }
            Einst.Lautstaerke = trackBarLautstaerke.Value;
            Einst.playMusic();
            List<String> liederlist = new List<string>();
            foreach(String s in comboBoxLieder.Items)
            {
                liederlist.Add(s);
            }
            Einst.Lieder = liederlist.ToArray();
        }



        #region Events
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            aendereEinstellungen();
            this.Dispose();
        }

        private void buttonAnweden_Click(object sender, EventArgs e)
        {
            aendereEinstellungen();
        }

        private void buttonAccept_MouseEnter(object sender, EventArgs e)
        {
            a.Ziel = (Control)sender;
            a.starteAnimation();
        }

        private void buttonAccept_MouseLeave(object sender, EventArgs e)
        {
            a.stopAnimation();
            ((Control)sender).BackgroundImage = buttonBack;
        }

        private void buttonMusicSuche_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "wav files (*.wav)|*.wav";
            dialog.Multiselect = true;
            dialog.ShowDialog();
            foreach (String s in dialog.FileNames)
            {
                comboBoxLieder.Items.Add(s);
            }
        }
        #endregion

        public void zeigeFenster(int x, int y)
        {
            this.Visible = true;
            this.SetDesktopLocation(x, y);
            
        }

        
    }
}
