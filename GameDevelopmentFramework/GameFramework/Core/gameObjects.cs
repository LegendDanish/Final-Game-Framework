using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GameFramework.Movement;
using GameFramework.Collision;
using GameFramework.ObjectsTypes;
using GameFramework.Fire;
namespace GameFramework.Core
{
    public class gameObjects
    {
     
        private PictureBox pictureBox;
        private IMovement movement;
        private IFire Fire;
        private ObjectType Otype;

        public gameObjects()
        {

        }
        public gameObjects(Image img,int Top, int Left, Size size,ObjectType Otype,IMovement movement)
        {
            PictureBox = new PictureBox();
            PictureBox.Image = img;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.Top = Top;
            PictureBox.Left = Left;
            PictureBox.Size = size;
            PictureBox.BackColor = Color.Transparent;
            Movement = movement;
            Otype1 = Otype;
        }

        public gameObjects(Image img,int Top, int Left,Size size,IMovement movement)
        {
            PictureBox = new PictureBox();
            PictureBox.Image = img;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.Top = Top;
            PictureBox.Left = Left;
            PictureBox.Size = size;
            PictureBox.BackColor = Color.Transparent;
            Movement = movement;

        }
        public gameObjects(Image img, int Top, int Left, Size size, ObjectType Otype)
        {
            PictureBox = new PictureBox();
            PictureBox.Image = img;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.Top = Top;
            PictureBox.Left = Left;
            PictureBox.Size = size;
            PictureBox.BackColor = Color.Transparent;
            Otype1 = Otype;
        }
        public gameObjects(Image img, int Top, int Left, Size size, ObjectType Otype, IFire Fire)
        {
            PictureBox = new PictureBox();
            PictureBox.Image = img;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.Top = Top;
            PictureBox.Left = Left;
            PictureBox.Size = size;
            PictureBox.BackColor = Color.Transparent;
            Fire1 = Fire;
            Otype1 = Otype;
        }

        public PictureBox PictureBox { get => pictureBox; set => pictureBox = value; }
        public IMovement Movement { get => movement; set => movement = value; }
        public ObjectType Otype1 { get => Otype; set => Otype = value; }
        public IFire Fire1 { get => Fire; set => Fire = value; }

        public void Update()
        {
            PictureBox.Location = Movement.Move(PictureBox.Location);
        }
        public void MovePlayerFire(IGame game)
        {
            PictureBox = Fire.Move(game, PictureBox);
        }
    }
}
