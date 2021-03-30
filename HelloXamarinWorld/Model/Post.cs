using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloXamarinWorld.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Experience { get; set; }
        public string VenueName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }

        public static List<Post> GetAllPosts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                return conn.Table<Post>().ToList();
            }
        }

        public static List<Post> GetAllPosts(string userId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                return conn.Table<Post>().Where(e => e.Address == userId).ToList();
            }
        }
    }
}
