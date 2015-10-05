using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace VacCheckWPF
{
    partial class Id
    {
        public override string ToString()
        {
            return "muh";
        }

        public void isbanned()
        {

            WebRequest request = WebRequest.Create(
              "https://api.steampowered.com/ISteamUser/GetPlayerBans/v1/?key=12A1D1DE83F9932934EDD6DF2BA00463&steamids=" + Convert.ToString(this.Steam_ID));


            request.Credentials = CredentialCache.DefaultCredentials;


            WebResponse response = request.GetResponse();


            Console.WriteLine(((HttpWebResponse)response).StatusDescription);


            Stream dataStream = response.GetResponseStream();


            StreamReader reader = new StreamReader(dataStream);


            string responseFromServer = reader.ReadToEnd();

            var ser = new JavaScriptSerializer();
            GetPlayerBansRespons resp = ser.Deserialize<GetPlayerBansRespons>(responseFromServer);
            this.VACban = (resp.players[0].NumberOfVACBans!=0);
            this.OWban = (resp.players[0].NumberOfGameBans != 0);
            

        }
    }
}
