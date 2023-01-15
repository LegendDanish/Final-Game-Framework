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
    public class Game : IGame
    {
        private List<gameObjects> Go;
        private List<Collisions> collision;
        private List<gameObjects> playerFire;
        private List<gameObjects> Space;
        private List<gameObjects> EnemyFire;
        public event EventHandler onAddObjects;
        public event EventHandler onPlayerDie;
        public event EventHandler onAddFire;
        public event EventHandler onRemoveFire;
        public event EventHandler onAddingSpace;
        public event EventHandler onEnemyDie;
        public event EventHandler onEnemyDie2;
        public event EventHandler onEnemyfireDelete;
        public event EventHandler ToIncreaseScore;


        public Game()
        {
            Go = new List<gameObjects>();
            Collision = new List<Collisions>();
            PlayerFire = new List<gameObjects>();
            Space1 = new List<gameObjects>();
            EnemyFire = new List<gameObjects>();

        }
        public List<gameObjects> Go1 { get => Go; set => Go = value; }
        public List<Collisions> Collision { get => collision; set => collision = value; }
        public List<gameObjects> PlayerFire { get => playerFire; set => playerFire = value; }
        public List<gameObjects> Space1 { get => Space; set => Space = value; }

        public void RemovePlayerFireFromList(PictureBox PFire)
        {
            for (int i = PlayerFire.Count-1; i>=0; i--)
            {
                if (PlayerFire[i].PictureBox == PFire)
                {
                    PlayerFire.RemoveAt(i);
                }
            }
        }

        public void RemoveEnemyFireFromList(PictureBox EFire)
        {
            for (int i = EnemyFire.Count - 1; i >= 0; i--)
            {
                if (EnemyFire[i].PictureBox == EFire)
                {
                    EnemyFire.RemoveAt(i);
                }
            }
        }
        public void EnemeyfireDelete(PictureBox pb)
        {
            onEnemyfireDelete?.Invoke(pb, EventArgs.Empty);
        }
        public void Enemy2DieAction(PictureBox pb)
        {
            onEnemyDie2?.Invoke(pb, EventArgs.Empty);
        }
        public void Enemy1DieAction(PictureBox pb)
        {
            onEnemyDie?.Invoke(pb, EventArgs.Empty);
        }
        public void RemovePlayerFormList(PictureBox Player)
        {
            for (int i = Go.Count-1; i>=0; i--)
            {
                if (Go[i].PictureBox == Player)
                {
                    Go.RemoveAt(i);
                }
            }
        }

        public void RemoveEnemyFromList(PictureBox enemy)
        {
            for (int i = Go.Count-1; i >= 0; i--)
            {
                if (Go[i].PictureBox == enemy)
                {
                    Go.RemoveAt(i);
                }
            }
        }
        public void AddGameObjects(Image img, int Top, int Left, Size size, ObjectType Otype, IMovement movement)
        {
            gameObjects go = new gameObjects(img, Top, Left, size, Otype, movement);
            Go1.Add(go);
            onAddObjects?.Invoke(go.PictureBox, EventArgs.Empty);
        }

        public void AddRaodObjects(Image img, int Top, int Left, Size size, IMovement Movement)
        {
            gameObjects go = new gameObjects(img, Top, Left, size, Movement);
            Space1.Add(go);
            onAddingSpace?.Invoke(go.PictureBox, EventArgs.Empty);
        }

        public void CountScore()
        {
            ToIncreaseScore?.Invoke(EventArgs.Empty, EventArgs.Empty);
        }
        public void AddFireObject(Image img, int Top, int Left, Size size, ObjectType Otype, IFire Fire)
        {
            gameObjects go = new gameObjects(img, Top, Left, size, Otype, Fire);
            if (Otype == ObjectType.Fire)
            {
                PlayerFire.Add(go);
            }
            if(Otype == ObjectType.enemyfire)
            {
                EnemyFire.Add(go);
            }
            onAddFire?.Invoke(go.PictureBox, EventArgs.Empty);
        }
        public gameObjects GiveCurrentPlayer(string Character)
        {

            foreach (gameObjects Go in Go1)
            {
                if (Character == "Player")
                {
                    if (Go.Otype1 == ObjectType.Player)
                    {
                        return Go;
                    }
                }
                else if(Character == "Enemy1")
                {
                    if (Go.Otype1 == ObjectType.BigEnemy1)
                    {
                        return Go;
                    }
                }
                else if(Character == "Enemy2")
                {
                    if (Go.Otype1 == ObjectType.Bigenemy2)
                    {
                        return Go;
                    }
                }
                else if (Character == "Senemy1")
                {
                    if (Go.Otype1 == ObjectType.enemy1)
                    {
                        return Go;
                    }
                }
                else if (Character == "Senemy2")
                {
                    if (Go.Otype1 == ObjectType.enemy2)
                    {
                        return Go;
                    }
                }
                else if (Character == "Senemy3")
                {
                    if (Go.Otype1 == ObjectType.enemy3)
                    {
                        return Go;
                    }
                }
                else if (Character == "Senemy4")
                {
                    if (Go.Otype1 == ObjectType.enemy4)
                    {
                        return Go;
                    }
                }
                else if (Character == "Senemy5")
                {
                    if (Go.Otype1 == ObjectType.enemy5)
                    {
                        return Go;
                    }
                }
                else if (Character == "Senemy6")
                {
                    if (Go.Otype1 == ObjectType.enemy6)
                    {
                        return Go;
                    }
                }
                else if (Character == "Senemy7")
                {
                    if (Go.Otype1 == ObjectType.enemy7)
                    {
                        return Go;
                    }
                }

            }
            return null;
        }
        public void AddCollision(Collisions c)
        {
            Collision.Add(c);
        }

        public void DetectCollison()
        {
            for (int i = Go.Count-1; i>=0; i--)
            {
                for (int j = Go.Count-1; j>=0; j--)
                {
                    if (Go[i].PictureBox.Bounds.IntersectsWith(Go[j].PictureBox.Bounds))
                    {
                        foreach (Collisions c in Collision)
                        {
                            if (Go[i].Otype1 == c.G1 && Go[j].Otype1 == c.G2)
                            {
                                c.Behavior.PerformAction(this, Go[i], Go[j]);
                                return;
                            }
                        }
                    }
                }
            }
            if (PlayerFire.Count > 0 && Go.Count>0)
                {
                for (int i = PlayerFire.Count - 1; i >= 0; i--)
                {
                    for (int j = Go.Count - 1; j >= 0; j--)
                    {
                        if (PlayerFire[i].PictureBox.Bounds.IntersectsWith(Go[j].PictureBox.Bounds))
                        {
                            foreach (Collisions c in Collision)
                            {
                                if (Go[j].Otype1 == c.G2 && PlayerFire[i].Otype1 == c.G1)
                                {
                                    c.Behavior.PerformAction(this, Go[j], PlayerFire[i]);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            if (EnemyFire.Count > 0 && Go.Count > 0)
            {
                for (int i = EnemyFire.Count - 1; i >= 0; i--)
                {
                    for (int j = Go.Count - 1; j >= 0; j--)
                    {
                        if (EnemyFire[i].PictureBox.Bounds.IntersectsWith(Go[j].PictureBox.Bounds))
                        {
                            foreach (Collisions c in Collision)
                            {
                                if (Go[j].Otype1 == c.G2 && EnemyFire[i].Otype1 == c.G1)
                                {
                                    c.Behavior.PerformAction(this, Go[j], EnemyFire[i]);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            if (EnemyFire.Count > 0 && PlayerFire.Count > 0)
            {
                for (int i = PlayerFire.Count - 1; i >= 0; i--)
                {
                    for (int j = EnemyFire.Count - 1; j >= 0; j--)
                    {
                        if (PlayerFire[i].PictureBox.Bounds.IntersectsWith(EnemyFire[j].PictureBox.Bounds))
                        {
                            foreach (Collisions c in Collision)
                            {
                                if (EnemyFire[j].Otype1 == c.G1 && PlayerFire[i].Otype1 == c.G2)
                                  {
                                    c.Behavior.PerformAction(this, EnemyFire[j], PlayerFire[i]);
                                    return;
                                }
                            }
                        }
                    }
                }
            }

        }
        public void PlayerDieAction(PictureBox pb)
        {
           
            onPlayerDie?.Invoke(pb, EventArgs.Empty);
        }

        public void FireDeleteAction(PictureBox pb)
        {
            RemovePlayerFireFromList(pb);
            onRemoveFire?.Invoke(pb, EventArgs.Empty);
        }
        public void Update()
        {
            DetectCollison();
            foreach (gameObjects Space in Space1)
            {
                Space.Update();
            }
            foreach (gameObjects go in Go)
            {
                go.PictureBox.BringToFront();
                go.Update();
            }

            for (int i = 0; i < PlayerFire.Count; i++)
            {
                PlayerFire[i].PictureBox.BringToFront();
                PlayerFire[i].MovePlayerFire(this);
            }
            for (int i = 0; i < EnemyFire.Count; i++)
            {
                EnemyFire[i].PictureBox.BringToFront();
                EnemyFire[i].MovePlayerFire(this);
            }



        }

        public void KeyPressed(Keys Keycode)
        {
            foreach (gameObjects gameObjects in Go1)
            {
                if (gameObjects.Movement.GetType() == typeof(Keyboard))
                {
                    Keyboard KeyHandle = (Keyboard)gameObjects.Movement;
                    KeyHandle.KeyPressedByME(Keycode);
                }
            }
        }
    }
}
