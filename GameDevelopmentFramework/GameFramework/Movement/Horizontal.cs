using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameFramework.Movement
{
    public class Horizontal : IMovement
    {
        private int speed;
        private string direction;
        private Point boundary;
        private int offset = 20;

        public Horizontal(int speed, string direction, Point boundary)
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
            if(Location.X <0)
            {
                Direction = "right";
            }
            else if(Location.X + offset > Boundary.X)
            {
                Direction = "left";
            }
            if(Direction == "left")
            {
                Location.X -= Speed;
            }
            if(Direction == "right")
            {
                Location.X += Speed;
            }
            return Location;
        }
    }
}
