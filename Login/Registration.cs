using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Login
{
    class Registration
    {
        static public Boolean pruefeBenutzerChar(String s, Label label)
        {
            
            Boolean ok = true;
            foreach (char c in s.ToArray())
            {
                
                if (!((int)c >= (int)'a' && (int)c <= (int)'z' || (int)c >= (int)'A' && (int)c <= (int)'Z'))
                {
                    ok = false;
                }
            }
            if (ok == true)
            {
                label.ResetText();
            }
            else
            {
                
                label.Text = "Nur Buchstaben.";
            }
            return ok;
        }

        static public Boolean pruefeBenutzerNamen(String s, Label label)
        {
            if (s.Length < 3)
            {
                label.Text = "Benutzername ist zu kurz.";
                return false;
            }
            else
            {
                
            }
            return true;
        }

        static public void erstelleOkIcon(PictureBox p)
        {
            p.BackColor = Color.Transparent;
            p.Image = Image.FromFile("Ok.png");
            p.Visible = true;
        }

        static public Boolean  pruefePw1(String s, Label label)
        {
            if(s.Length<5)
            {
                label.Text = "Passwort zu kurz.";
                    return false;
            }
            else
            {
                label.ResetText();
            }
            return true;
        }

        static public Boolean pruefePw2(String pw1, String pw2, Label label)
        {
            if(pw1.Equals(pw2))
            {
                label.ResetText();
                return true;
            }
            else
            {
                label.Text = "Passwörter stimmen nicht überein.";
                return false;
            }
        }
    }

    
}
