using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            loaddumps.Text= me.isbanned();
        }

        private void vacs_Click(object sender, EventArgs e)
        {


        }
    }
}
