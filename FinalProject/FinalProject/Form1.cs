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
       
    public Form1()
    {
      InitializeComponent();
      
    }
        BusinessTier.Business bt = new BusinessTier.Business();



        private void button1_Click(object sender, EventArgs e)
        {
            IReadOnlyList<BusinessTier.Stops> lines = bt.getStops();
            IEnumerator<BusinessTier.Stops> lineEn = lines.GetEnumerator();

            BusinessTier.Stops curLine;

            // format the content
            while (lineEn.MoveNext())
            {
                curLine = lineEn.Current;
                string msg = string.Format(" {0}: {1}", curLine.StopID, curLine.Name);
                this.listBox1.Items.Add(msg); // once formatted , add it to listbox1
            }

           

        }


        // get the coordinates
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //parse the item the user selected
            string[] words = listBox1.SelectedItem.ToString().Split(':');
            BusinessTier.Coordinates coord = bt.getCoordinates(Convert.ToInt32(words[0]));
            string newMsg = string.Format("Latitude: {1}  Longitude: {0}", coord.Longitude, coord.Latitude);
            MessageBox.Show(newMsg);
        }
    }
}
