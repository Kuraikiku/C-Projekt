using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Login
{
    public partial class Form1 : Form
    {
        #region Attribute
        Animation background;
        Animation buttonBack;
        Einstellungen settings;
        List<Image> hintergrundbilder;
        List<Image> buttonHintergrund;
        Image buttonStandardbild;
        Boolean []pruefRegist = new Boolean[3];
        SettingsGUI s;
        Client aClient;
        const char TRENN = ';';
        #endregion

        public Form1()
        {
            InitializeComponent();
            openingSettings();
            
        }


        #region Opening
        private void openingSettings()
        {
            panelOpening.Visible = true;
            settings = new Einstellungen();
            settings.setzeBildSound(pictureBoxSound);
            settings.setzeBildSettings(pictureBoxSetting);
            settings.setzeBildMusic(pictureBoxMusik);
            ladeHintergrund();
            settings.playMusic();
            pictureBoxLogo.Image = Image.FromFile("Logo.png");
            pictureBoxLogo.Visible = true;
            pictureBoxLogo.Location = new Point(panelOpening.Location.X + panelOpening.Size.Width / 2 - pictureBoxLogo.Size.Width / 2, panelOpening.Location.Y + panelOpening.Size.Height / 2-pictureBoxLogo.Size.Height/2);
            
            //new Opening(panelOpening, pictureBoxLogo, background,this);
        }

        private void endOpening()
        {
            
            panelOpening.Visible = false;
            startSettings();
        }

       
        #endregion


        #region Design
        private void ladeHintergrund()
        {
            hintergrundbilder = new List<Image>();
            panelStart.BackgroundImageLayout = ImageLayout.Center;
            for (int i = 0; i < 6; i++)
            {
                hintergrundbilder.Add(Image.FromFile(i.ToString() + ".png"));
            }
            background = new Animation(panelStart, hintergrundbilder.ToArray(), 150, true);
            buttonStandardbild = Image.FromFile("ButtonLogin.png");
            buttonHintergrund = new List<Image>();
            for (int i = 2; i < 8; i++)
            {
                buttonHintergrund.Add(Image.FromFile("Shine" + i.ToString() + ".png"));
            }
            buttonBack = new Animation(buttonSkipOpening, buttonHintergrund.ToArray(), 200, true);
        }

        private void buttonShine(object o)
        {
            buttonBack.Ziel = (Control)o;
            if (!buttonBack.Aktiv)
            {
                buttonBack.starteAnimation();

            }

        }

        private void stopButtonShine(object o)
        {
            buttonBack.stopAnimation();
            ((Control)o).BackgroundImage = buttonStandardbild;
        }
        #endregion

        #region Einstellungen
        private void pictureBoxSound_Click(object sender, EventArgs e)
        {
            settings.manageSound((PictureBox)sender);
        }

        private void pictureBoxSetting_Click(object sender, EventArgs e)
        {
            if (s != null)
            {
                if (s.Visible)
                {
                    s.Dispose();
                }
                else
                {
                    s = new SettingsGUI(settings, buttonBack, buttonStandardbild);
                    s.zeigeFenster(this.Location.X + this.Width, this.Location.Y);
                }
            }
            else
            {
                s = new SettingsGUI(settings, buttonBack, buttonStandardbild);
                s.zeigeFenster(this.Location.X + this.Width, this.Location.Y);
            }

        }

        private void pictureBoxSound_MouseEnter(object sender, EventArgs e)
        {
            settings.setzeBildSoundFocus((PictureBox)sender);
        }

        private void pictureBoxSound_MouseLeave(object sender, EventArgs e)
        {

            settings.setzeBildSound((PictureBox)sender);
        }

        private void pictureBoxSetting_MouseEnter(object sender, EventArgs e)
        {
            settings.setzeBildSettingsFocus((PictureBox)sender);
        }

        private void pictureBoxSetting_MouseLeave(object sender, EventArgs e)
        {
            settings.setzeBildSettings((PictureBox)sender);
        }

        private void pictureBoxMusik_Click(object sender, EventArgs e)
        {
            settings.manageMusic((PictureBox)sender);
        }

        private void pictureBoxMusik_MouseEnter(object sender, EventArgs e)
        {
            settings.setzeBildMusicFocus((PictureBox)sender);
        }

        private void pictureBoxMusik_MouseLeave(object sender, EventArgs e)
        {
            settings.setzeBildMusic((PictureBox)sender);

        }
        #endregion

        #region Fenster: Start

        private void startSettings()
        {
            panelStart.Visible = true;
            background.starteAnimation();
            background.Ziel = panelStart;
        }

        #region Events
        private void buttonLogin_MouseEnter(object sender, EventArgs e)
        {
            buttonShine(sender);
        }

        private void buttonLogin_MouseLeave(object sender, EventArgs e)
        {
            stopButtonShine(sender);

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginSettings();
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            registSettings();
            
        }

        private void buttonGast_Click(object sender, EventArgs e)
        {
            new Error("TestMeldung").ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            background.stopAnimation();
            buttonBack.stopAnimation();
            settings.saveSetting();
            if (s != null)
            {
                s.Dispose();
            }
            if(aClient != null)
            {
                aClient.stoppeClient();
            }
            this.Close();
        }
        #endregion
        #endregion

        #region Fenster: Registration
        private void registSettings()
        {
            aClient = new Client(settings.Ip, settings.Port, this);
            if (aClient.AClient != null)
            {
                
                textBoxPw1.ResetText();
                textBoxPw2.ResetText();
                textBoxUserName.ResetText();
                labelPw1.ResetText();
                labelPw2.ResetText();
                labelBenutzername.ResetText();
                panelRegist.Visible = true;
                panelStart.Visible = false;
                background.Ziel = panelRegist;
                textBoxPw1.PasswordChar = '°';
                textBoxPw2.PasswordChar = '°';
                textBoxUserName.MaxLength = 15;
                textBoxPw1.MaxLength = 15;
                textBoxPw2.MaxLength = 15;
                labelBenutzername.BackColor = System.Drawing.Color.Transparent;
                labelPw1.BackColor = System.Drawing.Color.Transparent;
                labelPw2.BackColor = System.Drawing.Color.Transparent;
                labelBenutzername.ForeColor = System.Drawing.Color.IndianRed;
                labelPw1.ForeColor = System.Drawing.Color.IndianRed;
                labelPw2.ForeColor = System.Drawing.Color.IndianRed;
                textBoxUserName.Focus();

            }
            
        }

        public void serverUserName(Boolean ok)
        {
            if(ok)
            {
                Registration.erstelleOkIcon(pictureBoxUserName);
                pruefRegist[0] = true;
            }
            else
            {
                pruefRegist[0] = false;
                pictureBoxUserName.Visible = false;
            }
        }

        private void abbruchRegist()
        {
            background.Ziel = panelStart;
            panelRegist.Visible = false;
            panelStart.Visible = true;
            pictureBoxPw1.Visible = false;
            pictureBoxPw2.Visible = false;
            pictureBoxUserName.Visible = false;
            aClient.stoppeClient();
            aClient = null;
            
        }

        #region Events
        
        private void buttonCancRegist_Click(object sender, EventArgs e)
        {
            abbruchRegist();

        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            if(Registration.pruefeBenutzerChar(textBoxUserName.Text, labelBenutzername))
            {
                labelBenutzername.Text = "";
            }
            else
            {
                pictureBoxUserName.Visible = false;
            }
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            if (!Registration.pruefeBenutzerNamen(textBoxUserName.Text, labelBenutzername))
            {
                pruefRegist[0] = false;
                pictureBoxUserName.Visible = false;
            }
            else
            {
                aClient.sendeNachricht("DRN" + TRENN + textBoxUserName.Text);
            }
        }

        private void textBoxPw1_Leave(object sender, EventArgs e)
        {
            if (Registration.pruefePw1(textBoxPw1.Text, labelPw1))
            {
                Registration.erstelleOkIcon(pictureBoxPw1);
                pruefRegist[1] = true;
            }
            else
            {
                pruefRegist[1] = false;
                pictureBoxPw1.Visible = false;
            }
        }

        private void textBoxPw2_Leave(object sender, EventArgs e)
        {
            if (Registration.pruefePw2(textBoxPw1.Text, textBoxPw2.Text, labelPw2))
            {
                Registration.erstelleOkIcon(pictureBoxPw2);
                pruefRegist[2] = true;
            }
            else
            {
                pruefRegist[2] = false;
                pictureBoxPw2.Visible = false;
            }
        }

        private void buttonBestRegist_Click(object sender, EventArgs e)
        {
            
            if(!pruefRegist[0] )
            {
                textBoxUserName.Focus();
            }
            else if(!pruefRegist[1] )
            {
                textBoxPw1.Focus();
            }
            else if(!pruefRegist[2])
            {
                textBoxPw2.Focus();
            }
            else
            {
                panelRegist.Visible = false;
            }
        }

        private void textBoxUserName_Enter(object sender, EventArgs e)
        {
            buttonShine(sender);
        }

        private void buttonBestRegist_MouseEnter(object sender, EventArgs e)
        {
            buttonShine(sender);
        }


        private void buttonBestRegist_MouseLeave(object sender, EventArgs e)
        {
            stopButtonShine(sender);
        }
        #endregion

        #endregion

        #region Fenster: Login
        private void loginSettings()
        {
            
            background.Ziel = panelLogin;
            textBoxLoginPw.PasswordChar = '°';
            textBoxLoginPw.MaxLength = 20;
            textBoxLoginUserName.MaxLength = 20;
            panelStart.Visible = false;
            panelLogin.Visible = true;
        }
        
        private void pruefeLogin()
        {
            aClient = new Client(settings.Ip, settings.Port, this);

            aClient.sendeNachricht("DBL"+TRENN + textBoxLoginUserName.Text + TRENN + textBoxLoginPw.Text);
        }

        public void bestLogin(Boolean login)
        {
            if(login)
            {
                MessageBox.Show("Login erfolgreich");
            }
            else
            {
                labelLoginMeldung.ForeColor = Color.OrangeRed;
                labelLoginMeldung.Text="Name oder Passwort falsch."; 
            }
        }

        #region Events
        private void buttonLoginLogin_MouseEnter(object sender, EventArgs e)
        {
            buttonShine(sender);
        }

        private void buttonLoginLogin_MouseLeave(object sender, EventArgs e)
        {
            stopButtonShine(sender);
        }

        private void buttonCancLogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            background.Ziel = panelStart;
            textBoxLoginUserName.ResetText();
            textBoxLoginPw.ResetText();
            panelStart.Visible = true;
            if(aClient != null)
            {
                aClient.stoppeClient();
                aClient = null;
            }
            
            
        }

        private void buttonLoginLogin_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(pruefeLogin)).Start() ;
        }
        #endregion
        #endregion


       

        private void buttonSkipOpening_Click(object sender, EventArgs e)
        {
            endOpening();
        }

        private void buttonSkipOpening_MouseEnter(object sender, EventArgs e)
        {
            buttonShine(sender);
        }

        private void buttonSkipOpening_MouseLeave(object sender, EventArgs e)
        {
            stopButtonShine(sender);
        }
    }
}
