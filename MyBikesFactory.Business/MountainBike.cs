using MyBikesFactory.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBikesFactory.Business
{
    public class MountainBike:Bike
    {
        private ESuspensionType _suspensionType;


        public ESuspensionType SuspensionType { get => _suspensionType; set => _suspensionType = value; }

        public MountainBike() : base()
        {
            _suspensionType = ESuspensionType.Front;
        }
        public MountainBike(ESuspensionType suspensionType) : base()
        {
            _suspensionType = suspensionType;
        }

        public override string ToString()
        {
            return "Bike Type:Mountain" + base.ToString() + $", Suspension Type: {_suspensionType}";
        }
    
}
}
