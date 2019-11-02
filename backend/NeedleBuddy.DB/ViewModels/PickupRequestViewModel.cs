using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedleBuddy.DB.ViewModels
{
    public class PickupRequestViewModel
    {
        public int ID { get; set; }
        public string Phone_Number { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public Enums.PickupStatus Status { get; set; }
        public float Location_Lat { get; set; }
        public float Location_Long { get; set; }

//        ID: Integer
//Phone_Number: String
//Description: String(could be almost anything)
//Count: Integer(usually 0 except when in reporting-mode)
//Status: Enum.PickupStatus
//Location_Lat: Float
//Location_Long: Float


            
    }
}
