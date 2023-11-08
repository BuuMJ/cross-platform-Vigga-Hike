using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace cross_platform
{
    public class SQLiteDatabase
    {
        private SQLiteConnection dbConnection;
        public const string DB_HIKE = "MyDB.db3";
        public const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.ReadWrite |
                                             SQLiteOpenFlags.ReadOnly |
                                             SQLiteOpenFlags.SharedCache;
        public string dbPath = "";
        public const string HIKE_TABLE = "Hike";
        public const string ID_COL = "HikeId";
        public const string NAME_COL = "HikeName";
        public const string DESTI_COL = "HikeDesc";
        public const string LENGTH_COL = "HikeLenght";
        public const string STARDATE_COL = "HikeStartDate";
        public const string PARKING_COL = "HikeParking";
        public const string LEVEL_COL = "HikeLevel";
        public const string DESC_COL = "HikeDesc";
        
        public SQLiteDatabase()
        {
            init();
        }

        public void init()
        {
            dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, DB_HIKE);
            dbConnection = new SQLiteConnection(dbPath);
            dbConnection.CreateTable<Hike>();
        }
        public int insertHike(Hike hike)
        {
            return dbConnection.Insert(hike);
        }
        public ObservableCollection<Hike> getHikeList()
        {
            return (new ObservableCollection<Hike>(dbConnection.Table<Hike>().ToList()));
        }
    }
}
