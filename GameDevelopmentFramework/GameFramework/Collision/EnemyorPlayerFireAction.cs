using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Core;
using GameFramework.ObjectsTypes;
namespace GameFramework.Collision
{
    public class EnemyorPlayerFireAction : ICollision
    {
        public void PerformAction(IGame game, gameObjects source1, gameObjects source2)
        {
            gameObjects PlayerFire = new gameObjects();
            gameObjects Enemyfire = new gameObjects();
            if (source1.Otype1 == ObjectType.Fire)
            {
                PlayerFire = source1;
            }
            if (source2.Otype1 == ObjectType.Fire)
            {
                PlayerFire = source2;
            }
            if (source1.Otype1 == ObjectType.enemyfire)
            {
                Enemyfire = source1;
            }
            if (source2.Otype1 == ObjectType.enemyfire)
            {
                Enemyfire = source2;
            }
            game.CountScore();
            game.FireDeleteAction(PlayerFire.PictureBox);
            game.EnemeyfireDelete(Enemyfire.PictureBox);
        }
    }
}
