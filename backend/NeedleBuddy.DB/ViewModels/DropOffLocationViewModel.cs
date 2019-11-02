using System;
using System.Collections.Generic;
using System.Text;

namespace NeedleBuddy.DB.ViewModels
{
    public class DropOffLocationViewModel
    {
        public string Description { get; set; }
        public bool IsInsideBuilding { get; set; }
        public float Location_Lat { get; set; }
        public float Location_Long { get; set; }

    }
}
