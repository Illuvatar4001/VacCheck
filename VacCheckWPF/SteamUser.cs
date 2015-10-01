using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;

namespace VacCheckWPF
{
    class SteamUser
    {
        Int64 steamid;
        bool is_banned;
        DateTime dumpdate;
        int gameid;

        public static Int64 getSteamId64(string SteamdID32)
        {
            try
            {
                var splitid = SteamdID32.Split(':');
                Int64 lowbit = Convert.ToInt64(splitid[1]);
                Int64 higherbits = Convert.ToInt64(splitid[2]);
                return 76561197960265728 + (2 * higherbits) + lowbit;
            }
            catch
            {
                return -1;
            }
        }

        public SteamUser(string SteamdID32)
        {
            this.steamid = getSteamId64(SteamdID32);
        }

        public string isbanned()
        {

            WebRequest request = WebRequest.Create(
              "https://api.steampowered.com/ISteamUser/GetPlayerBans/v1/?key=12A1D1DE83F9932934EDD6DF2BA00463&steamids="+Convert.ToString(steamid));


            request.Credentials = CredentialCache.DefaultCredentials;
  

            WebResponse response = request.GetResponse();


            Console.WriteLine(((HttpWebResponse)response).StatusDescription);


            Stream dataStream = response.GetResponseStream();


            StreamReader reader = new StreamReader(dataStream);


            string responseFromServer = reader.ReadToEnd();

            var ser = new JavaScriptSerializer();
            GetPlayerBansRespons resp= ser.Deserialize<GetPlayerBansRespons>(responseFromServer);

            return "This Account has" + Convert.ToString(resp.players[0].NumberOfVACBans) + " " + Convert.ToString(resp.players[0].NumberOfGameBans);
        }
    }
}
