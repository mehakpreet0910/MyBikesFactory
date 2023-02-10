using MyBikesFactory.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyBikesFactory.Business
{
    [Serializable]
    [XmlInclude(typeof(MountainBike))]
    [XmlInclude(typeof(RoadBike))]
    public abstract class Bike
    {
        private int _serialnumber;
        private string _name;
        private string _model;
        private EColor _color;
        private float _manufacturingyear;

        public int SerialNumber { get => _serialnumber; set => _serialnumber = value; }
        public string Name { get => _name; set => _name = value; }
        public string Model { get => _model; set => _model = value; }
        public EColor Color { get => _color; set => _color = value; }
        public float ManufacturingYear { get => _manufacturingyear; set => _manufacturingyear= value; }

        public Bike()
        {
            _serialnumber= 0;
            _name = "";
            _model = "";
            _color = EColor.Blue;
            _manufacturingyear = 0;
        }

        public Bike(int initialSerialNumber) : this()
        {
            _serialnumber = initialSerialNumber;
        }

        public override string ToString()
        {
            return $"SerialNumber:{_serialnumber},Name:{_name},Model: { _model},Color: { _color}, ManufaturingYear: { _manufacturingyear}";
        }
    }
}
