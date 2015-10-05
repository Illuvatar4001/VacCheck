using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacCheckWPF
{
    class Request
    {
        

        public static void RequestAPI()
        {
            VCdbDataContext mydb = new VCdbDataContext();

            var steamids = from u in mydb.Ids  select u;

            //where !u.OWban || !u.VACban
            foreach (var u in steamids)
            {


                string banstatus = SteamUser.isbanned(u.steamid);


                string banstatusVac = banstatus.Substring(1, 1);
                string banstatusGame = banstatus.Substring(2, 1);

                u.VACban = Convert.ToBoolean(banstatusVac);
                u.OWban = Convert.ToBoolean(banstatusGame);

               // u.VACban = banstatusVac;
               // u.OWban = banstatusGame;

            }
            
            mydb.SubmitChanges();


        }

    }
}
