using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace GameFramework.Movement
{
    public class Keyboard : IMovement
    {
        private int speed;
        private string KeyAction;
        private Point boundary;
        private int offset = 100;

        public Keyboard(int speed, Point boundary)
        {
            Speed = speed;
            Boundary = boundary;
            KeyAction = null;
        }

        public int Speed { get => speed; set => speed = value; }
        public Point Boundary { get => boundary; set => boundary = value; }
        public string KeyAction1 { get => KeyAction; set => KeyAction = value; }

        public void KeyPressedByME(Keys KeyCode)
        {
            if(KeyCode == Keys.Up)
            {
                KeyAction = "up";
            }
            if(KeyCode == Keys.Down)
            {
                KeyAction = "down";
            }
            if(KeyCode == Keys.Left)
            {
                KeyAction = "left";
            }
            if(KeyCode == Keys.Right)
            {
                KeyAction = "right";
            }
        }
        public Point Move(Point Location)
        {
            if (KeyAction != null)
            {
                if (KeyAction == "left")
                {
                    if (Location.X > 0)
                    {
                        Location.X -= Speed;
                    }
                }
                if (KeyAction == "right")
                {
                    if (Location.X + offset <= Boundary.X)
                    {
                        Location.X += Speed;
                    }
                }
                if (KeyAction == "up")
                {
                    if (Location.Y > 0)
                    {
                        Location.Y -= Speed;
                    }
                }
                if (KeyAction == "down")
                {
                    if (Location.Y < Boundary.Y)
                    {
                        Location.Y += Speed;
                    }
                }
                KeyAction = null;
            }
            return Location;
        }
    }
}
