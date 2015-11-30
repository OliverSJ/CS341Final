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
using Microsoft.Maps.MapControl.WPF;

namespace FinalProject
{
  public partial class Form2 : Form
  {
    // popup constructor for showing user ratings in another listbox
    // after a user double-clicks a user in the output listbox
    public Form2(Pushpin pin, BusinessTier.Business bt)
    {
      InitializeComponent();

      Location loc = pin.Location;

      double latitude = loc.Latitude;
      double longitude = loc.Longitude;

      // now get the stops at this location
      IReadOnlyList<BusinessTier.Stops> lines = bt.getAllStopsbyLocation(latitude, longitude);
      IEnumerator<BusinessTier.Stops> lineEn = lines.GetEnumerator();

      BusinessTier.Stops curLine;

      // format the content
      while (lineEn.MoveNext())
      {
        string stopMsg;
        string coordinates;
        string handicap;

        curLine = lineEn.Current;
        stopMsg = string.Format(" {0}: {1}", curLine.StopID, curLine.Name);

        // get stop info
        BusinessTier.Stops stopInfo = bt.getStopInfo(Convert.ToInt32(curLine.StopID));

        // display coordinates of stop
        coordinates = string.Format("({1},{0})", stopInfo.Longitude, stopInfo.Latitude);

        // handicap accessible ?
        if (stopInfo.ADA == 0)
        {
          handicap = "No";
        }
        else
        {
          handicap = "Yes";
        }

        this.pushPin_listBox.Items.Add(stopMsg);
        this.pushPin_listBox.Items.Add("Location: " + coordinates);
        this.pushPin_listBox.Items.Add("Handicap Accessible: " + handicap);
        this.pushPin_listBox.Items.Add("Direction: " + stopInfo.Direction);
        this.pushPin_listBox.Items.Add("Stop Detail: " + bt.getDetail(stopInfo.StopID));
        this.pushPin_listBox.Items.Add("");
      }

    }

    private void pushPin_listBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }
}
