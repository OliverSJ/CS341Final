//
// BusinessTier:  business logic, acting as interface between UI and data store.
//

using System;
using System.Collections.Generic;
using System.Data;


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
    private string _DBFile;
    private DataAccessTier.Data dataTier;


    //
    // Constructor:
    //
    public Business(string DatabaseFilename)
    {
      _DBFile = DatabaseFilename;

      dataTier = new DataAccessTier.Data(DatabaseFilename);
    }


    //
    // TestConnection:
    //
    // Returns true if we can establish a connection to the database, false if not.
    //
    public bool TestConnection()
    {
      return dataTier.TestConnection();
    }


   // get all the info for each line
    public IReadOnlyList< Lines> getLines()
    {
            List<Lines> lines = new List<Lines>();
            

            string sqlMsg = "Select * From Lines"; 
            DataSet ds = dataTier.ExecuteNonScalarQuery(sqlMsg); // get all the info for the Lines

            // if we did retrieve data
            if(ds != null)
            {
                //format the data that was retrieved and add it to the list lines
                foreach (DataRow row in ds.Tables["TABLE"].Rows)
                {
                    Lines newAdd = new Lines(Convert.ToInt32(row["LineID"]), Convert.ToString( row["Color"]));
                    lines.Add(newAdd);
                }

                return lines;
            }

            return null;
    }

    public Coordinates getCoordinates(int stopID)
    {
            string sqlMsg = string.Format("Select Latitude,Longitude From Stops Where StopID = {0}",stopID);
            DataSet ds = dataTier.ExecuteNonScalarQuery(sqlMsg); // get coordinats for a specifc bus stop
            Coordinates coord;

            if (ds != null)
            {
                //format the data that was retrieved and add it to the list lines
                foreach (DataRow row in ds.Tables["TABLE"].Rows)
                {
                    coord = new Coordinates(Convert.ToDouble(row["Latitude"]), Convert.ToDouble(row["Longitude"]));
                    return coord;
                }

                
            }

            return null;
    }

        /*
        //
        // GetNamedUser:
        //
        // Retrieves User object based on USER NAME; returns null if user is not
        // found.
        //
        // NOTE: there are "named" users from the Users table, and anonymous users
        // that only exist in the Reviews table.  This function only looks up "named"
        // users from the Users table.
        //
        public User GetNamedUser(string UserName)
        {
          //
          // TODO!
          //

          return null;
        }


        //
        // GetAllNamedUsers:
        //
        // Returns a list of all the users in the Users table ("named" users), sorted 
        // by user name.
        //
        // NOTE: the database also contains lots of "anonymous" users, which this 
        // function does not return.
        //
        public IReadOnlyList<User> GetAllNamedUsers()
        {
          List<User> users = new List<User>();

          //
          // TODO!
          //

          return users;
        }

        public IReadOnlyList<BusinessTier.Movie> GetAllMovies()
        {
                return null;

        }


        //
        // GetMovie:
        //
        // Retrieves Movie object based on MOVIE ID; returns null if movie is not
        // found.
        //
        public Movie GetMovie(int MovieID)
        {
          //
          // TODO!
          //

          return null;      
        }


        //
        // GetMovie:
        //
        // Retrieves Movie object based on MOVIE NAME; returns null if movie is not
        // found.
        //
        public Movie GetMovie(string MovieName)
        {
          //
          // TODO!
          //

          return null;
        }


        //
        // AddReview:
        //
        // Adds review based on MOVIE ID, returning a Review object containing
        // the review, review's id, etc.  If the add failed, null is returned.
        //
        public Review AddReview(int MovieID, int UserID, int Rating)
        {
          //
          // TODO!
          //

          return null;
        }


        //
        // GetMovieDetail:
        //
        // Given a MOVIE ID, returns detailed information about this movie --- all
        // the reviews, the total number of reviews, average rating, etc.  If the 
        // movie cannot be found, null is returned.
        //
        public MovieDetail GetMovieDetail(int MovieID)
        {
          //
          // TODO!
          //

          return null;
        }


        //
        // GetUserDetail:
        //
        // Given a USER ID, returns detailed information about this user --- all
        // the reviews submitted by this user, the total number of reviews, average 
        // rating given, etc.  If the user cannot be found, null is returned.
        //
        public UserDetail GetUserDetail(int UserID)
        {
          //
          // TODO!
          //

          return null;
        }


        //
        // GetTopMoviesByAvgRating:
        //
        // Returns the top N movies in descending order by average rating.  If two
        // movies have the same rating, the movies are presented in ascending order
        // by name.  If N < 1, an EMPTY LIST is returned.
        //
        public IReadOnlyList<Movie> GetTopMoviesByAvgRating(int N)
        {
          List<Movie> movies = new List<Movie>();

          //
          // TODO!
          //

          return movies;
        }


        //
        // GetTopMoviesByNumReviews
        //
        // Returns the top N movies in descending order by number of reviews.  If two
        // movies have the same number of reviews, the movies are presented in ascending
        // order by name.  If N < 1, an EMPTY LIST is returned.
        //
        public IReadOnlyList<Movie> GetTopMoviesByNumReviews(int N)
        {
          List<Movie> movies = new List<Movie>();

          //
          // TODO!
          //

          return movies;
        }


        //
        // GetTopUsersByNumReviews
        //
        // Returns the top N users in descending order by number of reviews.  If two
        // users have the same number of reviews, the users are presented in ascending
        // order by user id.  If N < 1, an EMPTY LIST is returned.
        //
        // NOTE: not all user ids map to users in the Users table.  User ids that don't
        // map over are considered "anonymous" users, and returned with their name =
        // to their userid ("<UserID>") and no occupation ("").
        //
        public IReadOnlyList<User> GetTopUsersByNumReviews(int N)
        {
          List<User> users = new List<User>();

          //
          // execute query to rank users:
          //
          // NOTE: some reviews are anonymous, i.e. we don't have a username.  So we
          // use a "RIGHT JOIN" to capture those as well.
          //
          string sql = string.Format(@"SELECT TOP {0} Temp.UserID, Users.UserName, Users.Occupation
                FROM Users
                RIGHT JOIN
                (
                  SELECT UserID, COUNT(*) AS RatingCount
                  FROM Reviews
                  GROUP BY UserID
                ) AS Temp
                On Temp.UserID = Users.UserID
                ORDER BY Temp.RatingCount DESC, Users.UserName Asc;",
            N);

          //
          // Now execute this query...  In the resulting dataset, the anonymous users will
          // have a UserName of "" because the result of the join was NULL.  So when you
          // come across a user with "" as their name, create a new based on their user id,
          // i.e. string.Foramt(""<{0}>", userid);
          //


          //
          // TODO:
          //


          return users;
        }
        */
    }//class


}//namespace
