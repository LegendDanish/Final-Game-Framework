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
using GameFramework.Collision;
using GameFramework.Fire;
using GameFramework.Movement;
using GameFramework.ObjectsTypes;
namespace GardiensOfGlaxy
{
    public partial class GameForm : Form
    {
        Game gO;
        Point Boundary;
        ProgressBar Playerbar;
        ProgressBar enemy1Bar;
        ProgressBar enemy2Bar;
        Label PlayerLbl;
        Label enemy1Lbl;
        Label enemy2Lbl;
        Label PlayerLives;
        Label PlayerLiveName;
        Label ScoreLabel;
        Label Scorecount;
        int PlayerScore = 0;
        bool BigEnemyDie = false;
        public GameForm()
        {
            InitializeComponent();
        }
        int count;
        int count1;
        int EnemyCount;
        int PlayerCount;


        public ProgressBar ProgressBar(int left, int top)
        {
            ProgressBar Playerbar = new ProgressBar();
            Playerbar.Left = left;
            Playerbar.Top = top;
            Playerbar.Width = 200;
            Playerbar.Height = 20;
            Playerbar.Value = 100;
            Playerbar.Show();
            Playerbar.BackColor = Color.Red;
            return Playerbar;

        }
        public Label NameLabel(string Name,string LblName,int Left,int Top,int width, int height,Color color)
        {
            Label Player = new Label();
            Player.Name = Name;
            Player.Text = LblName;
            Player.Left = Left;
            Player.Top = Top;
            Player.Width = width;
            Player.Height = height;
            Player.BackColor = Color.Transparent;
            Player.ForeColor = color;
            return Player;
        }

        public void AddLabel(Label lbl)
        {
            this.Controls.Add(lbl);
        }
        public void AddProgressBar(ProgressBar bar)
        {
            this.Controls.Add(bar);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gO = new Game();
            Playerbar = ProgressBar(this.Left+80, this.Top + 10);
            PlayerLbl = NameLabel("PlayerLBL", "Player Health", this.Left, this.Top + 10,80,20, Color.GreenYellow);
            enemy1Bar = ProgressBar(this.Left+80, this.Top + 35);
            enemy1Lbl = NameLabel("EnemeyLbl", "Enemy1 Health", this.Left, this.Top + 35,80,20,Color.GreenYellow);
            enemy2Bar = ProgressBar(this.Left + 80, this.Top + 60);
            enemy2Lbl = NameLabel("EnemeyLbl", "Enemy2 Health", this.Left, this.Top + 60,80,20, Color.GreenYellow);
            ScoreLabel = NameLabel("ScoreLbl", "SCORE",this.Right - 300,this.Top+10,100,20,Color.GreenYellow);
            Scorecount = NameLabel("ScoreCountLbl", "0", this.Right - 250, this.Top + 10, 100, 20, Color.Red);
            PlayerLiveName = NameLabel("LiveLbl", "PLAYER LIVES", this.Right - 150, this.Top + 10, 100, 20, Color.GreenYellow);
            PlayerLives = NameLabel("LiveCountLbl", "3", this.Right - 60, this.Top + 10, 100, 20, Color.Red);

            AddLabel(PlayerLbl);
            AddProgressBar(Playerbar);
            AddLabel(enemy1Lbl);
            AddProgressBar(enemy1Bar);
            AddLabel(enemy2Lbl);
            AddProgressBar(enemy2Bar);
            AddLabel(ScoreLabel);
            AddLabel(Scorecount);
            AddLabel(PlayerLives);
            AddLabel(PlayerLiveName);
            Scorecount.BringToFront();
            PlayerLives.BringToFront();
            gO.onAddObjects += new EventHandler(onAddgameObjects);
            gO.onAddFire += new EventHandler(onAddingFire);
            gO.onPlayerDie += new EventHandler(RemovePlayer);
            gO.onRemoveFire += new EventHandler(onDeleteFire);
            gO.onAddingSpace += new EventHandler(onAddingSpace);
            gO.onEnemyDie += new EventHandler(onDeleteEnemy);
            gO.onEnemyDie2 += new EventHandler(onDeleteEnemy2);
            gO.onEnemyfireDelete += new EventHandler(DeleteEnemyFire);
            gO.ToIncreaseScore += new EventHandler(IncreaseScore);
            Boundary = new Point(this.Width, this.Height);
            CreatSpace();
            CreatePlayer();
            CreateEnemies();
            Collisions c = new Collisions(ObjectType.Player, ObjectType.BigEnemy1, new PlayerCollision());
            Collisions c1 = new Collisions(ObjectType.Player, ObjectType.Bigenemy2, new PlayerCollision());
            Collisions c2 = new Collisions(ObjectType.Fire, ObjectType.BigEnemy1, new Firecollision());
            Collisions c3= new Collisions(ObjectType.Fire, ObjectType.Bigenemy2, new Firecollision());
            Collisions c4 = new Collisions(ObjectType.enemyfire, ObjectType.Player, new EnemyfireColllision());
            Collisions c5 = new Collisions(ObjectType.enemyfire, ObjectType.Fire, new EnemyorPlayerFireAction());
            gO.AddCollision(c);
            gO.AddCollision(c1);
            gO.AddCollision(c2);
            gO.AddCollision(c3);
            gO.AddCollision(c4);
            gO.AddCollision(c5);
        }

        private void IncreaseScore(object sender, EventArgs e)
        {
            PlayerScore++;
            Scorecount.Text = PlayerScore.ToString();
        }

        private void DeleteEnemyFire(object sender, EventArgs e)
        {
           
            gO.RemoveEnemyFireFromList((PictureBox)sender);
            this.Controls.Remove((PictureBox)sender);
        }

        private void onDeleteEnemy2(object sender, EventArgs e)
        {
            
            if (count1 >= 1 && count1 <= 10)
            {
               
                enemy2Bar.Value = enemy2Bar.Value - 10;
            }
            if (count1 == 10)
            {
                BigEnemyDie = true;
                gO.RemoveEnemyFromList((PictureBox)sender);
                this.Controls.Remove((PictureBox)sender);
            }
            count1++;
        }

        private void onDeleteEnemy(object sender, EventArgs e)
        {
           
            if (count >= 1 && count<=10)
            {
               
                enemy1Bar.Value = enemy1Bar.Value - 10;
            }
            if (count == 10)
            {
                BigEnemyDie = true;
                gO.RemoveEnemyFromList((PictureBox)sender);
                this.Controls.Remove((PictureBox)sender);
            }
            count++;
        }

        private void onAddingSpace(object sender, EventArgs e)
        {
            this.Controls.Add((PictureBox)sender);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Createbullet();
            }
            else
            {
                gO.KeyPressed(e.KeyCode);
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            gO.Update();
            if(EnemyCount == 10)
            {
                CreateEnemyBullet();
                EnemyCount = 0;
            }
            EnemyCount++;
        }
        private void onAddgameObjects(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            this.Controls.Add(pb);
        }

        private void RemovePlayer(object sender, EventArgs e)
        {
            PlayerCount++; 
            if (PlayerCount >= 1 && PlayerCount <3)
            {
                CreatePlayer();
            }
            if (PlayerCount == 1)
            {
                PlayerLives.Text = "2";
                Playerbar.Value -= 30;
            }
            if(PlayerCount == 2)
            {
                Playerbar.Value -= 30;
                PlayerLives.Text = "1";
            }
            if(PlayerCount == 3)
            {
                Playerbar.Value -= 40;
                PlayerLives.Text = "0";
                this.Controls.Remove((PictureBox)sender);
            }
          
        }


        private void onDeleteFire(object sender, EventArgs e)
        {
            gO.RemovePlayerFormList((PictureBox)sender);
            this.Controls.Remove((PictureBox)sender);
        }

        private void onAddingFire(object sender, EventArgs e)
        {
            this.Controls.Add((PictureBox)sender);
        }

        public void CreatSpace()
        {
            gO.AddRaodObjects(GardiensOfGlaxy.Properties.Resources.Bakground, -Top, 0, new Size(this.Width, this.Height), new SpaceMovement(10,Boundary));
            gO.AddRaodObjects(GardiensOfGlaxy.Properties.Resources.Bakground, 957, 0, new Size(this.Width, this.Height), new SpaceMovement(10, Boundary));
        }
        public void CreateEnemies()
        {
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.SmallEnemies, this.Top, this.Width / 2 - 90, new Size(70, 60), ObjectType.enemy1, new NoMove());
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.Enemy, 150, 10, new Size(150, 120), ObjectType.BigEnemy1, new Horizontal(5, "left", Boundary));
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.Enemy2, 250, this.Width, new Size(150, 120), ObjectType.Bigenemy2, new Horizontal(5, "right", Boundary));
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.thanos, this.Top, this.Width / 2, new Size(70, 70), ObjectType.Diamond, new NoMove());
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.SmallEnemies, this.Top, this.Width / 2 + 90, new Size(70, 60), ObjectType.enemy2, new NoMove());
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.SmallEnemies, this.Top + 40, this.Width / 2 + 150, new Size(70, 60), ObjectType.enemy3, new NoMove());
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.SmallEnemies, this.Top + 40, this.Width / 2 - 150, new Size(70, 60), ObjectType.enemy4, new NoMove());
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.SmallEnemies, this.Top, this.Width / 2 + 200, new Size(70, 60), ObjectType.enemy5, new NoMove());
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.SmallEnemies, this.Top, this.Width / 2 - 200, new Size(70, 60), ObjectType.enemy6, new NoMove());
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.SmallEnemies, this.Top + 80, this.Width / 2, new Size(70, 60), ObjectType.enemy7, new NoMove());
        }
        public void CreatePlayer()
        {
            gO.AddGameObjects(GardiensOfGlaxy.Properties.Resources.PlayerShip__2_,this.Height-100, this.Width / 2, new Size(100, 90), ObjectType.Player, new Keyboard(10, Boundary));
        }

        public void CreateEnemyBullet()
        {
            gameObjects enemy = gO.GiveCurrentPlayer("Enemy1");
            gameObjects enemy2 = gO.GiveCurrentPlayer("Enemy2");
            gameObjects Senemy1 = gO.GiveCurrentPlayer("Senemy1");
            gameObjects Senemy2 = gO.GiveCurrentPlayer("Senemy2");
            gameObjects Senemy3 = gO.GiveCurrentPlayer("Senemy3");
            gameObjects Senemy4 = gO.GiveCurrentPlayer("Senemy4");
            gameObjects Senemy5 = gO.GiveCurrentPlayer("Senemy5");
            gameObjects Senemy6 = gO.GiveCurrentPlayer("Senemy6");
            gameObjects Senemy7 = gO.GiveCurrentPlayer("Senemy7");


            if (enemy != null)
            {
                gO.AddFireObject(GardiensOfGlaxy.Properties.Resources.laserBlue14, enemy.PictureBox.Bottom, enemy.PictureBox.Location.X + 70, new Size(5, 30), ObjectType.enemyfire, new DownFire(10, Boundary));
            }
            if (enemy2 != null)
            {
                gO.AddFireObject(GardiensOfGlaxy.Properties.Resources.laserBlue14, enemy2.PictureBox.Bottom, enemy2.PictureBox.Location.X + 70, new Size(5, 30), ObjectType.enemyfire, new DownFire(10, Boundary));
            }
            if (BigEnemyDie == true)
            {
                if (Senemy1 != null)
                {
                    gO.AddFireObject(GardiensOfGlaxy.Properties.Resources.laserGreen07, Senemy1.PictureBox.Bottom, Senemy1.PictureBox.Location.X + 30, new Size(5, 10), ObjectType.enemyfire, new DownFire(10, Boundary));
                }
                if (Senemy2 != null)
                {
                    gO.AddFireObject(GardiensOfGlaxy.Properties.Resources.laserGreen07, Senemy2.PictureBox.Bottom, Senemy2.PictureBox.Location.X + 30, new Size(5, 20), ObjectType.enemyfire, new DownFire(10, Boundary));
                }
                if (Senemy3 != null)
                {
                    gO.AddFireObject(GardiensOfGlaxy.Properties.Resources.laserGreen07, Senemy3.PictureBox.Bottom, Senemy3.PictureBox.Location.X + 30, new Size(5, 20), ObjectType.enemyfire, new DownFire(10, Boundary));
                }
                if (Senemy4 != null)
                {
                    gO.AddFireObject(GardiensOfGlaxy.Properties.Resources.laserGreen07, Senemy4.PictureBox.Bottom, Senemy4.PictureBox.Location.X + 30, new Size(5, 20), ObjectType.enemyfire, new DownFire(10, Boundary));
                }
                if (Senemy5 != null)
                {
                    gO.AddFireObject(GardiensOfGlaxy.Properties.Resources.laserGreen07, Senemy5.PictureBox.Bottom, Senemy5.PictureBox.Location.X + 30, new Size(5, 20), ObjectType.enemyfire, new DownFire(10, Boundary));
                }
                if (Senemy6 != null)
                {
                    gO.AddFireObject(GardiensOfGlaxy.Properties.Resources.laserGreen07, Senemy6.PictureBox.Bottom, Senemy6.PictureBox.Location.X + 30, new Size(5, 20), ObjectType.enemyfire, new DownFire(10, Boundary));

                    if (Senemy7 != null)
                    {
                        gO.AddFireObject(GardiensOfGlaxy.Properties.Resources.laserGreen07, Senemy7.PictureBox.Bottom, Senemy7.PictureBox.Location.X + 30, new Size(5, 20), ObjectType.enemyfire, new DownFire(10, Boundary));
                    }
                }
            }
        }
        
            public void Createbullet()
        {
            gameObjects Player = gO.GiveCurrentPlayer("Player");
            if (Player != null)
            {
                gO.AddFireObject(GardiensOfGlaxy.Properties.Resources.laserRed01, Player.PictureBox.Location.Y - 10, Player.PictureBox.Location.X + 45, new Size(5, 40), ObjectType.Fire, new UpFire(10, Boundary));
            }
        }
    }
}
