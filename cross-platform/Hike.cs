using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace cross_platform
{
    [Table("Hike")]
    public class Hike
    {
        [PrimaryKey, AutoIncrement]
        public int HikeId { get; set; }
        public string HikeName { get; set; }
        public string HikeDesti { get; set; }
        public string HikeLength { get; set; }
        public string HikeStartDate { get; set; }
        public string HikeParking { get; set; }
        public string HikeLevel { get; set; }
        public string HikeDesc { get; set; }
        public Hike() { }
        public Hike(int hikeId, string hikeName, string hikeDesti, string hikeLength, string hikeStartDate, string hikeParking, string hikeLevel, string hikeDesc) {
            HikeId = hikeId;
            HikeName = hikeName;
            HikeDesti = hikeDesti;
            HikeLength = hikeLength;
            HikeStartDate = hikeStartDate;
            HikeParking = hikeParking;
            HikeLevel = hikeLevel;
            HikeDesc = hikeDesc;
        }
    }
}
