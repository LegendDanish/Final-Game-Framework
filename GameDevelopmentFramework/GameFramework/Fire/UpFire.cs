using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using GameFramework.Core;
namespace GameFramework.Fire
{
    public class UpFire : IFire
    {
        private int speed;
        private Point boundary;
         
        public UpFire(int speed, Point boundary)
        {
            Speed = speed;
            Boundary = boundary;
        }

        public int Speed { get => speed; set => speed = value; }
        public Point Boundary { get => boundary; set => boundary = value; }


        public PictureBox Move(IGame game,PictureBox pb)
        {
            Point Location = pb.Location;
            if(Location.Y <=0)
            {
                game.FireDeleteAction(pb);
            }
            Location.Y-= Speed;
            pb.Location = Location;
            return pb;
            
        }
    }
}
