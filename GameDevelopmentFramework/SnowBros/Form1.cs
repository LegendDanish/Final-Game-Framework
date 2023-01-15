using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameFramework.Core;
using GameFramework.Movement;
using GameFramework.ObjectsTypes;
using GameFramework.Collision;
namespace SnowBros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Game gO;
        private void GameTimerLoop_Tick(object sender, EventArgs e)
        {
            gO.Update();
        }

        private void onAddgameObjects(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            this.Controls.Add(pb);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gO = new Game();
            gO.onAddObjects += new EventHandler(onAddgameObjects);
            gO.onPlayerDie += new EventHandler(RemovePlayer);
            Point Boundary = new Point(this.Width, this.Height);
            gO.AddGameObjects(SnowBros.Properties.Resources.Player, 10, 100, new Size(70, 60),ObjectType.Player, new Vertical(5, "down", Boundary));
            gO.AddGameObjects(SnowBros.Properties.Resources.Player, 150, 10, new Size(70, 60), ObjectType.OtherObject, new Horizontal(5, "left", Boundary));
            gO.AddGameObjects(SnowBros.Properties.Resources.PlayerShip, this.Height + 50, this.Width/2, new Size(100, 90), ObjectType.OtherObject, new Keyboard(10, Boundary));
            Collisions c = new Collisions(ObjectType.Player, ObjectType.OtherObject, new PlayerCollision());
            gO.AddCollision(c);
        }

        private void RemovePlayer(object sender, EventArgs e)
        {
            this.Controls.Remove((PictureBox)sender);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            gO.KeyPressed(e.KeyCode);    
        }
    }
}
