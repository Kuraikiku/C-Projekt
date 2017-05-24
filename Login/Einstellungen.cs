using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Threading;
using System.Runtime.InteropServices;

namespace Login
{
    public class Einstellungen
    {
        Image[] soundBilder;
        Image[] settingBilder;
        Image[] musicBilder;
        Boolean music;
        Boolean isPlaying = false;
        Boolean sound;
        String ip;
        String port;
        SoundPlayer musicPlayer;
        SoundPlayer soundPlayer;
        String selLied;
        String[] lieder;
        int lautstaerke;

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);


        #region Getter/Setter
        public bool Sound
        {
            get
            {
                return sound;
            }

            set
            {
                sound = value;
            }
        }

        public string Ip
        {
            get
            {
                return ip;
            }

            set
            {
                ip = value;
            }
        }

        public string Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public bool Music
        {
            get
            {
                return music;
            }

            set
            {
                music = value;
            }
        }

        public string[] Lieder
        {
            get
            {
                return lieder;
            }

            set
            {
                lieder = value;
            }
        }

        public string SelLied
        {
            get
            {
                return selLied;
            }

            set
            {
                selLied = value;
            }
        }

        public int Lautstaerke
        {
            get
            {
                return lautstaerke;
            }

            set
            {
                lautstaerke = value;
            }
        }
        #endregion

        public Einstellungen()
        {
            try
            {
                List<Image> b1 = new List<Image>();
                b1.Add(Image.FromFile("Sound.png"));
                b1.Add(Image.FromFile("SoundFocus.png"));
                b1.Add(Image.FromFile("NoSound.png"));
                b1.Add(Image.FromFile("NoSoundFocus.png"));
                List<Image> b2 = new List<Image>();
                b2.Add(Image.FromFile("setting.png"));
                b2.Add(Image.FromFile("settingFocus.png"));
                List<Image> b3 = new List<Image>();
                b3.Add(Image.FromFile("Music.png"));
                b3.Add(Image.FromFile("MusicFocus.png"));
                b3.Add(Image.FromFile("NoMusic.png"));
                b3.Add(Image.FromFile("NoMusicFocus.png"));
                soundBilder = b1.ToArray();
                settingBilder = b2.ToArray();
                musicBilder = b3.ToArray();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim laden der Grafiken.", "Error");
            }

            try
            {
                StreamReader sr = new StreamReader("Settings.txt");
                if(sr.ReadLine().Equals("0"))
                {
                    Music = true;
                }
                else
                {
                    Music = false;
                }
                if (sr.ReadLine().Equals("0"))
                {
                    Sound = true;
                }
                else
                {
                    Sound = false;
                }

                ip = sr.ReadLine();
                port = sr.ReadLine();
                SelLied = sr.ReadLine();
                lieder = sr.ReadLine().Split(';');
                
                Lautstaerke = Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Fehler beim laden der Einstellungen.", "Error");
            }

            musicPlayer = new SoundPlayer();
            soundPlayer = new SoundPlayer();
            
            soundPlayer.SoundLocation = "click.wav";
            
        }
        #region setzeBilder
        public void setzeBildSound(PictureBox c)
        {
            if (Sound)
            {
                c.Image = soundBilder[0];
            }else
                {
                c.Image = soundBilder[2];
            }
        }

        public void setzeBildSoundFocus(PictureBox c)
        {
            if (Sound)
            {
                c.Image = soundBilder[1];
            }
            else
            {
                c.Image = soundBilder[3];
            }
        }
        

        public void setzeBildSettings(PictureBox c)
        {
            c.Image = settingBilder[0];
        }

        public void setzeBildSettingsFocus(PictureBox c)
        {
            c.Image = settingBilder[1];
        }

        public void setzeBildMusic(PictureBox c)
        {
            if (Music)
            {
                c.Image = musicBilder[0];
            }
            else
            {
                c.Image = musicBilder[2];
            }
        }

        public void setzeBildMusicFocus(PictureBox c)
        {
            if (Music)
            {
                c.Image = musicBilder[1];
            }
            else
            {
                c.Image = musicBilder[3];
            }
        }

        #endregion

        public void manageMusic(PictureBox c)
        {
            if(Music)
            {
                music = false;
            }
            else
            {
                music = true;
            }
            playMusic();
            setzeBildMusicFocus(c);
        }

        public void playMusic()
        {
            if(!isPlaying)
            {
                musicPlayer.SoundLocation = SelLied;
                new Thread(new ThreadStart(musicLoop)).Start();
                aendereLautstaerke(lautstaerke);
            }
            if (Music)
            {
                aendereLautstaerke(lautstaerke);
            }
            else
            {

                muteMusic();
            }
        }

        public void stopMusic()
        {
            isPlaying = false;
            musicPlayer.Stop();
        }

        public void playClickSound()
        {
            if(Sound)
            {
                new Thread(new ThreadStart(soundPlay)).Start();
            }
        }

        public void manageSound(PictureBox c)
        {
            if (Sound)
            {
                Sound = false;
            }
            else
            {
                Sound = true;
            }
            setzeBildSoundFocus(c);
        }
        

        private void musicLoop()
        {

            try
            {
                isPlaying = true;
                musicPlayer.PlayLooping();
            }
            catch (ThreadInterruptedException)
            {
                isPlaying = false;
            }
        }

        private void soundPlay()
        {
            soundPlayer.PlaySync();
        }

        public void saveSetting()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Settings.txt", false, Encoding.UTF8);
                if (music) sw.WriteLine("0");
                else sw.WriteLine("1");
                if (sound) sw.WriteLine("0");
                else sw.WriteLine("1");
                sw.WriteLine(Ip);
                sw.WriteLine(Port);
                sw.WriteLine(SelLied);
                String s = "";
                foreach (String l in lieder)
                {
                    s += l + ";";
                }
                s = s.Substring(0, s.Length - 1);
                sw.WriteLine(s);
                sw.WriteLine(lautstaerke.ToString());
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
                
            }
        }

        public void muteMusic()
        {
            waveOutSetVolume(IntPtr.Zero, 0);
        }

        public void aendereLautstaerke(int l)
        {
            lautstaerke = l;
            waveOutSetVolume(IntPtr.Zero,((Convert.ToUInt32(((ushort.MaxValue / 10) * l)) & 0x0000ffff) | Convert.ToUInt32(((ushort.MaxValue / 10) * l)) << 16));

        }


    }
}
