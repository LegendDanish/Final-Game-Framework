using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameFramework.Movement
{
    public class Vertical : IMovement
    {
        private int speed;
        private string direction;
        private Point boundary;
        private int offset = 100;

        public Vertical(int speed, string direction, Point boundary)
        {
            Speed = speed;
            Direction = direction;
            Boundary = boundary;
        }

        public int Speed { get => speed; set => speed = value; }
        public string Direction { get => direction; set => direction = value; }
        public Point Boundary { get => boundary; set => boundary = value; }

        public Point Move(Point Location)
        {
            if (Location.Y <= 0)
            {
                Direction = "down";
            }
            if (Location.Y + offset >= Boundary.Y)
            {
                Direction = "up";
            }
            if (Direction == "up")
            {
                Location.Y -= Speed;
            }
            if (Direction == "down")
            {
                Location.Y += Speed;
            }
            return Location;
        }
    }
}
