using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalProject
{
  public partial class Form1 : Form
  {
        BusinessTier.Business bt;
    public Form1()
    {
      InitializeComponent();

            bt = new BusinessTier.Business();

            IReadOnlyList<BusinessTier.Stations> lines = bt.getStations();
            IEnumerator<BusinessTier.Stations> lineEn = lines.GetEnumerator();

            BusinessTier.Stations curLine;

            // format the content
            while (lineEn.MoveNext())
            {
                curLine = lineEn.Current;
                string msg = string.Format(" {0}: {1}", curLine.StationID, curLine.Name);
                this.listBox1.Items.Add(msg); // once formatted , add it to listbox1
            }

        }
         



        private void button1_Click(object sender, EventArgs e)
        {
           
        }


        // get the coordinates
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //parse the item the user selected
            string[] words = listBox1.SelectedItem.ToString().Split(':');
            BusinessTier.Coordinates coord = bt.getCoordinates(Convert.ToInt32(words[0]));
            string newMsg = string.Format("Latitude: {1}  Longitude: {0}", coord.Longitude, coord.Latitude);
            MessageBox.Show(newMsg);



            // now get the stops at this station
            IReadOnlyList<BusinessTier.Stops> lines = bt.getStops(Convert.ToInt32(words[0]));
            IEnumerator<BusinessTier.Stops> lineEn = lines.GetEnumerator();

            BusinessTier.Stops curLine;

            // if listbox contains items. then clear it
            if (listBox2.Items.Count != 0) { listBox2.Items.Clear(); }


            // format the content
            while (lineEn.MoveNext())
            {
                curLine = lineEn.Current;
                string msg = string.Format(" {0}: {1}", curLine.StationID, curLine.Name);
                this.listBox2.Items.Add(msg); // once formatted , add it to listbox2
            }
        }
    }
}
