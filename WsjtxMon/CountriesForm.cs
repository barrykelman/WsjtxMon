using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSJTXMon;

namespace WsjtxMon
{

    public partial class CountriesForm : Form
    {
        public CountriesForm()
        {
            InitializeComponent();
            foreach (string country in Form1.WorkedCountryList.Values)
            {
                if (country != "?")
                {
                    bool confirmed = !Form1.WsjtxResource.UnconfirmedCountries.Contains(country);
                    int itemNum = CountryList.Items.Add(country, confirmed);
                }
            }
        }
    }
}
