//
// BusinessTier objects:  these classes define the objects serving as data 
// transfer between UI and business tier.  These objects carry the data that
// is normally displayed in the presentation tier.  The classes defined here:
//
//    Lines
//    RiderShips
//    Stations
//    StopDetails
//    Stops
//    MovieDetail
//
// NOTE: the presentation tier should not be creating instances of these objects,
// but instead calling the BusinessTier logic to obtain these objects.  You can 
// create instances of these objects if you want, but doing so has no impact on
// the underlying data store --- to change the data store, you have to call the
// BusinessTier logic.
//

using System;
using System.Collections.Generic;


namespace BusinessTier
{

    //
    // Lines:
    //
    public class Lines
    {
        public readonly int LineID;
        public readonly string Color;

        public Lines(int lineId, string color)
        {
            LineID = lineId;
            Color = color;
        }

    }//class

    //
    // RiderShips:
    //
    public class RiderShips
    {
        public readonly int RiderID;
        public readonly int StationID;
        public readonly string TheDate;
        public readonly string TypeOfDay;
        public readonly int DailyTotal;

        public RiderShips(int rID, int sID, string date, string type, int total)
        {
            RiderID = rID;
            StationID = sID;
            TheDate = date;
            TypeOfDay = type;
            DailyTotal = total;
        }

    }//class


    //
    // Stations:
    //
    public class Stations
    {
        public readonly int StationID;
        public readonly string Name;

        public Stations(int statId, string name)
        {
            StationID = statId;
            Name = name;
        }

    }//class

    public class Sum_Avg
    {
        public readonly long Sum;
        public readonly double Average;

        public Sum_Avg(long sum, double average)
        {
            Sum = sum;
            Average = average;
        }
    }

    //
    // StopDetails:
    //
    public class StopDetails
    {
        public readonly int StopID;
        public readonly int LineID;

        public StopDetails(int stopId, int lineID)
        {
            StopID = stopId;
            LineID = lineID;
        }

    }//class


    //
    // StopDetails:
    //
    public class Stops
    {
        public readonly int StopID;
        public readonly int StationID;
        public readonly string Name;
        public readonly string Direction;
        public readonly int ADA;
        public readonly double Latitude;
        public readonly double Longitude;

        public Stops(int stopId, int sID, string name, string dir, int ada, double lat, double longitude)
        {
            StopID = stopId;
            StationID = sID;
            Name = name;
            Direction = dir;
            ADA = ada;
            Latitude = lat;
            Longitude = longitude;
        }

    }//class

    //
    // Coordinates:
    //
    public class Coordinates
    {
        public readonly double Latitude;
        public readonly double Longitude;

        public Coordinates(double lat, double longitude)
        {
            Latitude = lat;
            Longitude = longitude;
        }
    }


}//namespace
