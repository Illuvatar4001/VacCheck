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

namespace VacCheckWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void readbut_Click(object sender, RoutedEventArgs e)
        {
            VacCheckWPF.VCdbDataContext mydb = new VacCheckWPF.VCdbDataContext();
            //VCdbDataContext mydb = new VCdbDataContext();
            Parser.read_condumps(mydb);
            var results = from u in mydb.Ids select u;
            foreach (var result in results)
            {
                textbox1.Text = textbox1.Text + "\n" + "  " + Convert.ToString(result.Id1) + "  " + Convert.ToString(result.Steam_ID) + "  ";
            }
            datagrid1.DataContext = mydb.Ids;
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

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}




 //private void loaddumps_Click(object sender, EventArgs e)
 //       {
 //           Id_GameDataContext mydb = new Id_GameDataContext();
 //           Parser.read_condumps(mydb);
 //           var results = from u in mydb.Ids select u;
 //           foreach (var result in results)
 //           {
 //               textBox1.Text = textBox1.Text + "\n" + "  " + Convert.ToString(result.Id1) + "  " + Convert.ToString(result.Steam_ID) + "  ";
 //           }
 //       }

 //       private void vacs_Click(object sender, EventArgs e)
 //       {
 //           Game mygame = new Game
 //           {
 //               map = "de_nuke",
 //               date = new DateTime(2000,2,2),

 //           };
 //           Id_GameDataContext mydb = new Id_GameDataContext();
 //           mydb.Games.InsertOnSubmit(mygame);
 //           mydb.SubmitChanges();
 //           textBox1.Text = Convert.ToString(mygame.Id);
 //           var result = from u in mydb.Ids where u.OWban == true select u;
 //           foreach (var item in result)
 //           {
 //               var gameids = from u in mydb.Relations where u.Player_Id == item.Id1 select u.Game_Id;
 //               foreach (var gameid in gameids)
 //               {
 //                   var map = (from u in mydb.Games where u.Id == gameid select u.map).First();
 //                   textBox1.Text = textBox1.Text + " " + map;
 //               }
 //               textBox1.Text = textBox1.Text + " " + item.Steam_ID;
 //           }
 //           SqlCommand cmd = new SqlCommand();
 //           SqlDataReader dr;


 //       }

 //       private void settings_Click(object sender, EventArgs e)
 //       {
 //           Game mygame = new Game
 //           {
 //               map = "de_nuke2",
 //               date = new DateTime(2001, 2, 2),

 //           };
 //           Id_GameDataContext mydb = new Id_GameDataContext();
 //           mydb.Games.InsertOnSubmit(mygame);
 //           textBox1.Text = Convert.ToString(mygame.Id) + mygame.map;
 //           mydb.SubmitChanges();
   

 //           {   // Open the text file using a stream reader.
 //               using (StreamReader sr = new StreamReader("c:\\condump001.txt"))
 //               {
 //                   String grundliste = sr.ReadToEnd();
                    
 //                   Use of parseMap function
 //                   string mapname;
 //                   mapname = Parser.parseMap(grundliste);

 //                   test output map
 //                   Console.WriteLine("Map played: {0}", mapname);
                    


 //                   Use of ParseSteamIds64 function
 //                   List<long> steamidlist;
 //                   steamidlist = Parser.parseSteamIds64(grundliste);

 //                   test output steam id list
 //                   steamidlist.ForEach(i => Console.WriteLine(i));   
                   


 //                 }
                        
                                                              

 //                   }
 //               }
