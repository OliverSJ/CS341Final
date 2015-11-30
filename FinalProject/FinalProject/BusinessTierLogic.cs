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
            // list that will contain stop objects
            List<Stops> stops = new List<Stops>();

            // query all stops' info
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
                    stops.Add(newAdd);
                }

                // return list
                return stops;
            }

            return null;
    }
   
    // number of stations 
    public string num_Stat()
    {
            int total = (from stations in m_CTA.Stations
                         select stations).Count();
            return Convert.ToString(total);
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
        List<Stations> stations = new List<Stations>();

        var query = from stats in m_CTA.Stations
                    select stats;

        // if we did retrieve data
        if (query != null)
        {
            //format the data that was retrieved and add it to the list stations
            foreach (var row in query)
            {
                
                Stations newAdd = new Stations(Convert.ToInt32(row.StationID), Convert.ToString(row.Name));
                stations.Add(newAdd);
            }

            return stations;
        }

        return null;
    }

    // get the coordinates at a particular station
    public Coordinates getCoordinates(int stationID)
    {
        // query for the coordinates
        var query = from stop in m_CTA.Stops
                    where stop.StationID == stationID
                    select stop;

        // object that will hold the coordinates
        Coordinates coord;

        if (query != null)
        {
            //format the data that was retrieved and store it into coord
            foreach (FinalProject.Stop row in query)
            {
                coord = new Coordinates(Convert.ToDouble(row.Latitude), Convert.ToDouble(row.Longitude));
                return coord;
            }


        }

        return null;
    }
    
    // find station by its id
    public Stations findStation(int stationID)
    {
            var query = from station in m_CTA.Stations
                        
                        where station.StationID == stationID
                        select station;

            // if we did retrieve data
            if (query != null)
            {
                //format the data that was retrieved and add it to myStation
                foreach (var row in query)
                {
                    Stations myStation = new Stations(Convert.ToInt32(row.StationID), Convert.ToString(row.Name));
                    return myStation;
                }
            }

            return null;
        }


        // get total riders
        public Sum_Avg totalRiders(int stationID)
        {
            int pas = 0;
            int days = 0;

            // query for the number of riders
            var query = from riders in m_CTA.Riderships
                        where riders.StationID == stationID
                        select riders;
                        

            // got total riders
            foreach (var row in query)
            {
                pas = pas + row.DailyTotal;
            }

            // query for total days
            var query2 = from riders in m_CTA.Riderships
                         where riders.StationID == stationID
                         group riders by riders.TheDate into grp
                         select new { key = grp.Key, count = grp.Count() };

            // got total days
            foreach (var row in query2)
            {
                days = days + row.count;
            }

            double average = pas / days;

            Sum_Avg myResult = new Sum_Avg(pas,average);
            return myResult;
        }
    
        // get the detail for a stop
        public string getDetail(int stopID )
        {
            var query = from color in m_CTA.Lines
                        join detail in m_CTA.StopDetails on color.LineID equals detail.LineID
                        where detail.StopID == stopID
                        select color;
            
            // get color
            foreach (var row in query)
            {
                return Convert.ToString(row.Color);
            }

            return null;
        }

        // get all the info for stops at a particular stations
        public IReadOnlyList<Stops> getAllStopsbyLocation(double latitude, double longitude)
        {
          List<Stops> stops = new List<Stops>();

          var query = from stop in m_CTA.Stops
                      where stop.Latitude == latitude && stop.Longitude == longitude
                      select stop;

          // if we did retrieve data
          if (query != null)
          {
            //format the data that was retrieved and add it to the list lines
            foreach (var row in query)
            {
              Stops newAdd = new Stops(Convert.ToInt32(row.StopID), Convert.ToInt32(row.StationID), Convert.ToString(row.Name), Convert.ToString(row.Direction), Convert.ToInt32(row.ADA), Convert.ToInt32(row.Latitude), Convert.ToInt32(row.Longitude));
              stops.Add(newAdd);
            }

            return stops;
          }

          return null;
        }
   

        
 }//class


}//namespace
