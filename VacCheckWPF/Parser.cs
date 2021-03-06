﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VacCheckWPF
{
    static class Parser
    {

        static string temppath;
        //string fmt = "0000";
        //static string csgopath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        static string csgopath = Directory.GetCurrentDirectory();
        

        //static string csgopath=@"E:\Visual Studio Projects\C#\VAc\VacCheck\VacCheck";
        public static void read_condumps(VCdbDataContext db)
        {
            //csgopath = Properties.Settings.Default.csgopath;
            string filedata;
            var files = Directory.EnumerateFiles(csgopath, "*.*", SearchOption.TopDirectoryOnly)
            .Where(s => s.StartsWith(csgopath + @"\condump") && s.EndsWith(".txt"));

            if (!Directory.Exists("CondumpArchieve"))
            {
                Directory.CreateDirectory("CondumpArchieve");
            }

            foreach (var file in files)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    filedata = sr.ReadToEnd();
                }



                try
                {
                    filedata = cleanGrundliste(filedata);
                    Console.WriteLine(filedata);
                }

                catch
                {
                    System.Windows.MessageBox.Show("File: " + file + " is empty/damaged");
                    continue;
                }

                Game newgame = new Game
                {
                    map = parseMap(filedata),
                    date = File.GetLastWriteTime(file)
                };



                db.Games.InsertOnSubmit(newgame);
                db.SubmitChanges();

                List<Int64> steamids = parseSteamIds64(filedata);

                foreach (var steamid in steamids)
                {
                    int playerid;

                    if (db.Ids.Any(entry => entry.Steam_ID == steamid))
                    {
                        playerid = db.Ids.First(entry => entry.Steam_ID == steamid).Id1;
                    }
                    else
                    {
                        Id newsteamid = new Id
                        {
                            Steam_ID = steamid
                        };
                        db.Ids.InsertOnSubmit(newsteamid);
                        db.SubmitChanges();
                        playerid = newsteamid.Id1;

                    }

                    ////int playerid= db.Ids.FirstOrDefault(entry => entry.Steam_ID == steamid).Id1;
                    //int playerid= from entry in db.Ids where entry.Steam_ID == steamid

                    //if (playerid==0)
                    //{
                    //    Id newsteamid= new Id
                    //    {
                    //        Steam_ID=steamid

                    //    };
                    //    db.Ids.InsertOnSubmit(newsteamid);
                    //    db.SubmitChanges();
                    //    playerid = newsteamid.Id1;
                    //}

                    db.Relations.InsertOnSubmit(new Relation { Game_Id = newgame.Id, Player_Id = playerid });

                    


                }

                temppath = file.ToString();
                temppath = temppath.Remove(temppath.Length - 14, 14);

                temppath = temppath + @"CondumpArchieve\" + "ConDumpVacChecked" + Properties.Settings.Default.DumpNumber.ToString("0000") + ".txt";



                File.Move(file.ToString(), temppath);
                //+ @"Condump Archieve\" + "ConDumpVacChecked" + Properties.Settings.Default.DumpNumber.ToString("0000") + ".txt");

                Properties.Settings.Default.DumpNumber++;

            }

            Properties.Settings.Default.Save();


        }


        static string parseMap(string grundliste)
        {
            
            
            // MAP PARSE ==============================                                            
            //declare search terms
            string suchbegriff = "map     : ";
           // string suchbegriff2 = "players";
            string suchbegriff2 = "\r\n";
            string map;

            //Search for index of searchterms
            int firstCharacter = grundliste.IndexOf(suchbegriff);

            try
            {

            int lastCharacter = grundliste.IndexOf(suchbegriff2, firstCharacter);
            //int lastCharacter = grundliste.IndexOf(suchbegriff2);

            //Index correction
            firstCharacter = firstCharacter + 10;
            //lastCharacter = lastCharacter + 2;



            //generate substring and return
           
                map = grundliste.Substring(firstCharacter, lastCharacter - firstCharacter);
            }
            catch (Exception)
            {

                map = "Error";
            }
            return map;

        }

        static List<long> parseSteamIds64(string grundliste)
        {
            // STEAM ID PARSE ===============================
            List<long> steamlist = new List<long>();

            //variables   
            string suchbegriff3 = "STEAM";
            int endpunkt = 0;
            int startpunkt = 0;
            long steamid64;

            while (true)
            {

                startpunkt = grundliste.IndexOf(suchbegriff3, endpunkt);

                //break if there are no more "STEAM" (-1)
                if (startpunkt == -1)
                {
                    break;
                }

                //finding first space after STEAM ID
                for (int i = startpunkt; ; i++)
                {
                    if (grundliste[i] == ' ')
                    {
                        endpunkt = i;
                        break;
                    }

                }

                //write found steamid32/substring into steamid variable
                string steamid = grundliste.Substring(startpunkt, endpunkt - startpunkt);

                //convert found steamid32 to steamid64
                steamid64 = SteamUser.getSteamId64(steamid);

                //add steamid64 to list
                steamlist.Add(steamid64);


            }

            return steamlist;
        }

        static string cleanGrundliste(string grundliste)
        {


            string suchbegriff = "\"";
            string suchbegriff2 = "***VAC Check Console Dump***";


            //test for valid VAC Checker log
            int startpunkt = grundliste.IndexOf(suchbegriff2);

            if (startpunkt == -1)
            {
                //    throw new ArgumentException("A non valid VAC Checker log was used.");
            }

            //Deleting of the playernames in the grundliste
            startpunkt = 0;
            int endpunkt = 0;

            while (true)
            {

                startpunkt = grundliste.IndexOf(suchbegriff, endpunkt);
                endpunkt = grundliste.IndexOf(suchbegriff, startpunkt + 1);

                if (startpunkt == -1)
                {
                    Console.WriteLine(grundliste);
                    return grundliste;
                }

                grundliste = grundliste.Remove(startpunkt, endpunkt - startpunkt);


            }



        }

        




        }
    }

