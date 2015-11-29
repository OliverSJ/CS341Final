﻿using System;
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

            // number of stations
            this.textBox6.Text = bt.num_Stat();

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
            // get coordinates
            BusinessTier.Coordinates coord = bt.getCoordinates(Convert.ToInt32(words[0]));

            // display coordinates
            string newMsg = string.Format("({1},{0})", coord.Longitude, coord.Latitude);
            this.textBox1.Text = newMsg;


            // now get the stops at this station
            IReadOnlyList<BusinessTier.Stops> lines = bt.getAllStopsbyStationID(Convert.ToInt32(words[0]));
            IEnumerator<BusinessTier.Stops> lineEn = lines.GetEnumerator();

            BusinessTier.Stops curLine;

            // if listbox contains items. then clear it
            if (listBox2.Items.Count != 0) { listBox2.Items.Clear(); }


            // format the content
            while (lineEn.MoveNext())
            {
                curLine = lineEn.Current;
                string msg = string.Format(" {0}: {1}", curLine.StopID, curLine.Name);
                this.listBox2.Items.Add(msg); // once formatted , add it to listbox2
            }

            // total riderships and average per day
            BusinessTier.Sum_Avg myResult = bt.totalRiders(Convert.ToInt32(words[0]));
            this.textBox4.Text = Convert.ToString(myResult.Sum);
            this.textBox5.Text = Convert.ToString(myResult.Average);

        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            //parse the item the user selected
            string[] words = listBox2.SelectedItem.ToString().Split(':');
            
            // get stop info
            BusinessTier.Stops stopInfo = bt.getStopInfo(Convert.ToInt32(words[0]));

            // display coordinates of stop
            string newMsg = string.Format("({1},{0})", stopInfo.Longitude, stopInfo.Latitude);
            this.textBox1.Text = newMsg;
            
            // handicap accessible ?
            if(stopInfo.ADA == 0)
            {
                newMsg = "No";
            }
            else
            {
                newMsg = "Yes";
                
            }
            
            this.textBox2.Text = newMsg;
            //direction
            this.textBox3.Text = stopInfo.Direction;

            //detail
            this.textBox7.Text = bt.getDetail(stopInfo.StopID);

        }
    }
}
