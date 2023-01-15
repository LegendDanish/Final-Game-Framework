using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameFramework.Movement
{
    public class NoMove : IMovement
    {
        public NoMove()
        {

        }

        public Point Move(Point Location)
        {
            return Location;
        }
    }
}
