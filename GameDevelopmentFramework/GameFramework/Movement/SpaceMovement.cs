using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameFramework.Movement
{
    public class SpaceMovement : IMovement
    {
        private int speed;
        private Point boundary;
     

        public SpaceMovement(int speed, Point boundary)
        {
            Speed = speed;
            Boundary = boundary;
        }

        public int Speed { get => speed; set => speed = value; }
        public Point Boundary { get => boundary; set => boundary = value; }

        public Point Move(Point Location)
        {
            Location.Y += speed;
            if(Location.Y > Boundary.Y)
            {
                Location.Y = -Boundary.Y;
            }
            return Location;
        }
    }
}
