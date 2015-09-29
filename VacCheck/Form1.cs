using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
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
            Id_GameDataContext mydb = new Id_GameDataContext();
            var result = from u in mydb.Ids where u.OWban == true select u;
            foreach (var item in result)
            {
                var gameids = from u in mydb.Relations where u.Player_Id == item.Id1 select u.Game_Id;
                foreach (var gameid in gameids)
                {
                    var map = (from u in mydb.Games where u.Id == gameid select u.map).First();
                    textBox1.Text = textBox1.Text + " " + map;
                }
                textBox1.Text = textBox1.Text + " " + item.Steam_ID;
            }
            //SqlCommand cmd = new SqlCommand();
            //SqlDataReader dr;


        }

        private void settings_Click(object sender, EventArgs e)
        {

            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("c:\\condump001.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String grundliste = sr.ReadToEnd();
                    // Console.WriteLine(grundliste);

                    // MAP NAME PARESE
                    string suchbegriff = "map     : ";
                    int firstCharacter = grundliste.IndexOf(suchbegriff);

                    string suchbegriff2 = "players";
                    int lastCharacter = grundliste.IndexOf(suchbegriff2);

                    firstCharacter = firstCharacter + 10;
                    lastCharacter = lastCharacter - 2;

                    Console.WriteLine("First occurrence: {0}", firstCharacter);
                    Console.WriteLine("Last occurrence: {0}", lastCharacter);

                    string map = grundliste.Substring(firstCharacter, lastCharacter - firstCharacter);

                    Console.WriteLine("Map played: {0}", map);
                    Console.WriteLine("=========================");

                    // STEAM ID PARSE ==============================================

                    List<long> steamlist = new List<long>();
                    
                    string suchbegriff3 = "STEAM";
                    int endpunkt = 0;
                    int startpunkt = 0;
                    long steamid64;

                    while (true)
                    {
                        

                        
                        startpunkt = grundliste.IndexOf(suchbegriff3, endpunkt);

                        if (startpunkt == -1)
                        {
                            break;
                        }
                        

                            for (int i = startpunkt; ; i++)
                            {
                                

                                if (grundliste[i] == ' ')
                                {
                                    endpunkt = i;
                                    break;
                                }

                            }

                        string steamid = grundliste.Substring(startpunkt, endpunkt - startpunkt);
                        steamid64 = SteamUser.getSteamId64(steamid);

                        steamlist.Add(steamid64);
                        Console.WriteLine("STEAM id: {0}", steamid);
                                         

                     }
                        


                        Console.WriteLine("third occurrence: {0}", startpunkt);
                        Console.WriteLine("fourth occurrence: {0}", endpunkt);
                      
                        steamlist.ForEach(i => Console.WriteLine(i));                        
                        

                        
                        


                        //Console.WriteLine("fourth occurrence: {0}", fourthCharacter);
                        //string suchbegriff4 = " ";
                        //int fourthCharacter = grundliste.IndexOf(suchbegriff4);





                        //Console.WriteLine(grundliste[197]);

                    }
                }
            }
        }
    }
