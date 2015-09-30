using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VacCheck
{
    static class Parser
    {

        static string csgopath=@"E:\Visual Studio Projects\C#\VAc\VacCheck\VacCheck";

        public static void read_condumps(Id_GameDataContext db)
        {
            string filedata;
            var files = Directory.EnumerateFiles(csgopath, "*.*", SearchOption.TopDirectoryOnly)
            .Where(s => s.StartsWith("condump") || s.EndsWith(".txt"));

            foreach (var file in files)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    filedata = sr.ReadToEnd();
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

                    if(db.Ids.Any(entry => entry.Steam_ID==steamid))
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
            }



        }


        static string parseMap(string grundliste)
        {
            // MAP PARSE ==============================                                            
            //declare search terms
            string suchbegriff = "map     : ";
            string suchbegriff2 = "players";

            //Search for index of searchterms
            int firstCharacter = grundliste.IndexOf(suchbegriff);
            int lastCharacter = grundliste.IndexOf(suchbegriff2);

            //Index correction
            firstCharacter = firstCharacter + 10;
            lastCharacter = lastCharacter - 2;

            //generate substring and return
            string map = grundliste.Substring(firstCharacter, lastCharacter - firstCharacter);
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
    }
}
    
