using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameFramework.Movement
{
    public class Up
    {
        private int speed;
        private Point boundary;
        

        public Up(int speed, Point boundary)
        {
            Speed = speed;
            Boundary = boundary;
        }

        public int Speed { get => speed; set => speed = value; }
        public Point Boundary { get => boundary; set => boundary = value; }

        public Point Move(Point Location)
        {
            if (Location.Y >= 0)
            {
               Location.Y-=Speed;
            }
            return Location;
        }
    }
}
