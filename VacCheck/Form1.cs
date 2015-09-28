using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VacCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loaddumps_Click(object sender, EventArgs e)
        {
            SteamUser me = new SteamUser("STEAM_0:1:79591186");
            loaddumps.Text = me.isbanned();
        }

        private void vacs_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {



            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("c:\\condump001.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String grundliste = sr.ReadToEnd();
                    Console.WriteLine(grundliste);

                    string suchbegriff = "map     : ";

                    int firstCharacter = grundliste.IndexOf(suchbegriff);

                    Console.WriteLine("First occurrence: {0}", firstCharacter);
                    firstCharacter = firstCharacter + 10;
                    int lastCharacter = firstCharacter;
                    for (int i = lastCharacter; ; i++)
                    {
                        if (grundliste[i] == 'p')
                        {
                            lastCharacter = i - 1;
                            break;
                        }

                    }
                       
			                

                    string map = grundliste.Substring(firstCharacter,lastCharacter);
                    
                    Console.WriteLine(map);
                    //Console.WriteLine(grundliste[197]);

                }
            }
        }
    }
}
