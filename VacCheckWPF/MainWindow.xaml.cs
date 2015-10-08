using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace VacCheckWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        VCdbDataContext mydb;
        public MainWindow()
        {
            InitializeComponent();
            mydb = new VacCheckWPF.VCdbDataContext();
            updategrid();

        }

        private void RequestBans()
        {
            var steamids = from u in mydb.Ids select u;

            //where !u.OWban || !u.VACban
            
            Parallel.ForEach(steamids,
                new ParallelOptions { MaxDegreeOfParallelism=100 },
                u =>
            {
                u.isbanned();
            });

            mydb.SubmitChanges();
            updategrid();


        }
        private void updategrid()
        {
            var results = from u in mydb.Ids
                          join gameid in mydb.Relations on u.Id1 equals gameid.Player_Id into games
                          from game in mydb.Games
                          where game.Id == (int)games.OrderByDescending(x => x.Game_Id).First().Game_Id
                          select new
                          {
                              steamid = u.Steam_ID,
                              vacbanned = u.VACban,
                              owbanned = u.OWban,
                              lastdate = game.date,
                              link = new Uri("http://steamcommunity.com/profiles/" + Convert.ToString(u.Steam_ID))
                          };

            grid.ItemsSource = results;
        }

        private void readbut_Click(object sender, RoutedEventArgs e)
        {
            //VCdbDataContext mydb = new VCdbDataContext();
            Parser.read_condumps(mydb);
            updategrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            VacCheckWPF.VCdbDataSet vCdbDataSet = ((VacCheckWPF.VCdbDataSet)(this.FindResource("vCdbDataSet")));
            // Load data into the table Ids. You can modify this code as needed.
            VacCheckWPF.VCdbDataSetTableAdapters.IdsTableAdapter vCdbDataSetIdsTableAdapter = new VacCheckWPF.VCdbDataSetTableAdapters.IdsTableAdapter();
            vCdbDataSetIdsTableAdapter.Fill(vCdbDataSet.Ids);
            System.Windows.Data.CollectionViewSource idsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("idsViewSource")));
            idsViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebRequest request = WebRequest.Create(
              "https://api.steampowered.com/ISteamUser/GetPlayerBans/v1/?key=12A1D1DE83F9932934EDD6DF2BA00463&steamids=" + Convert.ToString(76561197968389378
));


            request.Credentials = CredentialCache.DefaultCredentials;


            WebResponse response = request.GetResponse();


            Console.WriteLine(((HttpWebResponse)response).StatusDescription);


            Stream dataStream = response.GetResponseStream();


            StreamReader reader = new StreamReader(dataStream);


            string responseFromServer = reader.ReadToEnd();

            var ser = new JavaScriptSerializer();
            GetPlayerBansRespons resp = ser.Deserialize<GetPlayerBansRespons>(responseFromServer);
            if (resp.players.Count == 1)
            {
                bool bool1 = (resp.players[0].NumberOfVACBans != 0);
                bool bool2 = (resp.players[0].NumberOfGameBans != 0);
            }
            return;
        }

        private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)e.OriginalSource;
            Process.Start(link.NavigateUri.AbsoluteUri);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            RequestBans();         
        }
    }
}




 