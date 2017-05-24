using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Login
{
    class Client
    {
        TcpClient aClient;
        NetworkStream stream;
        Thread t;
        Form1 f;
        Boolean verbunden;
        Account a;
        DateTime timeout;
        const char TRENN = ';';
        byte[] buffer = new byte[1024];

        #region Getter/Setter

        public TcpClient AClient
        {
            get
            {
                return aClient;
            }

            set
            {
                aClient = value;
            }
        }
        #endregion

        public Client(String ip, String port, Form1 f)
        {

            try
            {
                AClient = new TcpClient(ip, Convert.ToInt32(port));
                stream = AClient.GetStream();
                this.f = f;
                verbunden = true;
                t = new Thread(new ThreadStart(empfangeNachricht));
                t.Start();
                
            }
            catch (Exception)
            {
                new Error("Fehler beim Verbindungsaufbau.").ShowDialog();
            }
        }



        private void checkNachricht(String s)
        {
            String []mes = s.Split(TRENN);
            switch(mes[0])
            {
                case "DBL":
                    if(pruefeTimeout())
                    {
                        if(mes[1].Equals("0"))
                        {
                            f.bestLogin(true);
                        }
                        else
                        {
                            f.bestLogin(false);
                        }
                    }
                    break;
                case "DRN":
                    if (pruefeTimeout())
                    {
                        if (mes[1].Equals("0"))
                        {
                            f.serverUserName(true);
                        }
                        else
                        {
                            f.serverUserName(false);
                        }
                    }
                    else
                    {
                        new Error("Verzögerung bei Übertragung.").ShowDialog();
                    }
                    break;
            }
        }
        private Boolean pruefeTimeout()
        {
            if(timeout.AddSeconds(1).CompareTo(DateTime.Now)==1)
            {
                return false;
            }
            return true;
        }

        public void sendeNachricht(String s)
        {
            try
            {
                
                if (s.Substring(0, 3).Equals("DBL") || s.Substring(0, 3).Equals("DRN"))
                {
                    timeout = DateTime.Now;
                }
                Byte[] mes = Encoding.ASCII.GetBytes(s);
                stream.Write(mes,0, mes.Length);
                   
            }
            catch (Exception)
            {
                new Error("Fehler bei Senden der Nachricht.").ShowDialog();
            }
        }

        public void empfangeNachricht()
        {
            while (verbunden)
            {
                try
                {
                
                    stream.Read(buffer, 0, buffer.Length);
                    checkNachricht(Encoding.ASCII.GetString(buffer));
               
                }
                catch (Exception e)
                {
                    t.Interrupt();
                }
            }
        }

        public void stoppeClient()
        {
            try
            {
                verbunden = false;
                t.Interrupt();
                stream.Close();
                AClient.Close();
            }
            catch (Exception)
            {
            }

        }

    }
}
