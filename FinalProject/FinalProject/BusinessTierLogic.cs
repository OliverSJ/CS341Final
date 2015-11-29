//
// BusinessTier:  business logic, acting as interface between UI and data store.
//

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using FinalProject;

namespace BusinessTier
{

  //
  // Business:
  //
  public class Business
  {
    //
    // Fields:
    //
    private CTADataContext m_CTA;


    //
    // Constructor:
    //
    public Business()
    {
            m_CTA = new CTADataContext();
    }


    // get all the info for stops at a particular stations
    public IReadOnlyList<Stops> getAllStopsbyStationID(int stationID)
    {
            List<Stops> lines = new List<Stops>();

            var query = from stop in m_CTA.Stops
                        where stop.StationID == stationID
                        select stop;

            // if we did retrieve data
            if(query != null)
            {
                //format the data that was retrieved and add it to the list lines
                foreach (var row in query)
                {
                    Stops newAdd = new Stops(Convert.ToInt32(row.StopID), Convert.ToInt32(row.StationID), Convert.ToString(row.Name), Convert.ToString(row.Direction), Convert.ToInt32(row.ADA), Convert.ToInt32(row.Latitude), Convert.ToInt32(row.Longitude));
                    lines.Add(newAdd);
                }

                return lines;
            }

            return null;
    }
   
    // get a particular stop's info by its stop id
    public Stops getStopInfo(int stopID)
    {
            var query = from stop in m_CTA.Stops
                        where stop.StopID == stopID
                        select stop;

            Stops stopInfo;

            if (query != null)
            {
                //format the data that was retrieved
                foreach (FinalProject.Stop row in query) 
                {
                    stopInfo = new Stops(Convert.ToInt32(row.StopID), Convert.ToInt32(row.StationID), Convert.ToString(row.Name), Convert.ToString(row.Direction), Convert.ToInt32(row.ADA), Convert.ToDouble(row.Latitude), Convert.ToDouble(row.Longitude));
                    return stopInfo;
                }
            }
            return null;

    }

    // get the stations info
    public IReadOnlyList<Stations> getStations()
    {
        List<Stations> lines = new List<Stations>();

        var query = from stop in m_CTA.Stations
                    select stop;

        // if we did retrieve data
        if (query != null)
        {
            //format the data that was retrieved and add it to the list lines
            foreach (var row in query)
            {
                
                Stations newAdd = new Stations(Convert.ToInt32(row.StationID), Convert.ToString(row.Name));
                lines.Add(newAdd);
            }

            return lines;
        }

        return null;
    }

    // get the coordinates at a particular station
    public Coordinates getCoordinates(int stationID)
    {
        var query = from stop in m_CTA.Stops
                    where stop.StationID == stationID
                    select stop;

        Coordinates coord;
        if (query != null)
        {
            //format the data that was retrieved and add it to the list lines
            foreach (FinalProject.Stop row in query) //ds.Tables["TABLE"].Rows)
            {
                coord = new Coordinates(Convert.ToDouble(row.Latitude), Convert.ToDouble(row.Longitude));
                return coord;
            }   
        }

        return null;
    }

        
 }//class


}//namespace
