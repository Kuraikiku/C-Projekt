using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Login
{
    class Account
    {
        private String name;
        private Image bild;
        private int soloCount;
        private int win;
        private int lose;
        private int spielzeit;
        private int highscore;
        private DateTime login;

        public Account(String s)
        {

        }
        #region Getter/Setter
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Image Bild
        {
            get
            {
                return bild;
            }

            set
            {
                bild = value;
            }
        }

        public int SoloCount
        {
            get
            {
                return soloCount;
            }

            set
            {
                soloCount = value;
            }
        }

        public int Win
        {
            get
            {
                return win;
            }

            set
            {
                win = value;
            }
        }

        public int Lose
        {
            get
            {
                return lose;
            }

            set
            {
                lose = value;
            }
        }

        public int Spielzeit
        {
            get
            {
                return spielzeit;
            }

            set
            {
                spielzeit = value;
            }
        }

        public int Highscore
        {
            get
            {
                return highscore;
            }

            set
            {
                highscore = value;
            }
        }

        public DateTime Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }
        #endregion

    }
}
