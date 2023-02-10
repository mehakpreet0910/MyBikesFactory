using MyBikesFactory.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBikesFactory.Business
{
    public class RoadBike:Bike
    {
        private ETireType _tireType;


        public ETireType TireType { get => _tireType; set => _tireType = value; }

        public RoadBike() : base()
        {
            _tireType = ETireType.Regular;
        }
        public RoadBike(ETireType tireType) : base()
        {
            _tireType = tireType;
        }

        public override string ToString()
        {
            return "Bike Type:Road" + base.ToString() + $", Tire Type: {_tireType}";
        }
    }
}
