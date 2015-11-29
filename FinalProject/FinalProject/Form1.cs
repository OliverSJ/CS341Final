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
        BusinessTier.Business bt = new BusinessTier.Business("CTA.mdf");

        private void button1_Click(object sender, EventArgs e)
        {
            IReadOnlyList<BusinessTier.Lines> lines = bt.getLines();
            IEnumerator<BusinessTier.Lines> lineEn = lines.GetEnumerator();

            BusinessTier.Lines curLine;

            // format the content
            while (lineEn.MoveNext())
            {
                curLine = lineEn.Current;
                string msg = string.Format(" {0}: {1}", curLine.LineID, curLine.Color);
                this.listBox1.Items.Add(msg); // once formatted , add it to listbox1
            }

            BusinessTier.Coordinates coord = bt.getCoordinates(30001);
            string newMsg = string.Format("Latitude: {1}  Longitude: {0}", coord.Longitude,coord.Latitude);
            MessageBox.Show(newMsg);

        }
    }
}
