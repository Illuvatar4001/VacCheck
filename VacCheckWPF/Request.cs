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
                long temp;
                string banstatus;

                if (long.TryParse(u.Steam_ID.ToString(), out temp))
                {
                    banstatus = SteamUser.isbanned(temp);
                }
                else
                {
                    banstatus = SteamUser.isbanned(0);
                }

                string banstatusVac = banstatus.Substring(0, 1);
                string banstatusGame = banstatus.Substring(1, 1);

                // ban status VAC
                if (!long.TryParse(banstatusVac, out temp))
                    {
                        temp = 0;
                    }

                if (temp != 0)
                    {
                        u.VACban = true;
                    }
                else
                    {
                        u.VACban = false;
                    }

                // ban status Game
                if (!long.TryParse(banstatusGame, out temp))
                    {
                        temp = 0;
                    }

                if (temp != 0)
                    {
                        u.OWban = true;
                    }
                else
                    {
                        u.OWban = false;
                    }

              

                // u.VACban = banstatusVac;
                // u.OWban = banstatusGame;

            }

            mydb.SubmitChanges();


        }

    }
}
