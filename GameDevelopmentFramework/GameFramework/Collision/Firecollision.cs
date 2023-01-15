using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Core;
using GameFramework.ObjectsTypes;
namespace GameFramework.Collision
{
    public class Firecollision : ICollision
    {
        public void PerformAction(IGame game, gameObjects source1, gameObjects source2)
        {
            gameObjects Enemy = new gameObjects();
            gameObjects fire = new gameObjects();
            if (source1.Otype1 == ObjectType.BigEnemy1 || source1.Otype1 == ObjectType.Bigenemy2)
            {
                Enemy = source1;
            }
            if(source2.Otype1 == ObjectType.BigEnemy1 || source2.Otype1 == ObjectType.Bigenemy2)
            {
                Enemy = source2;
            }
            if(source1.Otype1 == ObjectType.Fire)
            {
                fire = source1;
            }
            if(source2.Otype1 == ObjectType.Fire)
            {
                fire = source2;
            }
            if (Enemy.Otype1 == ObjectType.BigEnemy1)
            {
                game.Enemy1DieAction(Enemy.PictureBox);
            }
            if(Enemy.Otype1 == ObjectType.Bigenemy2)
            {
                game.Enemy2DieAction(Enemy.PictureBox);
            }
            game.CountScore();
            game.FireDeleteAction(fire.PictureBox);
        }
    }
}
