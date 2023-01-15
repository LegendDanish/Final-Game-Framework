using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Core;
using GameFramework.ObjectsTypes;
namespace GameFramework.Collision
{
    public class EnemyfireColllision : ICollision
    {
        public void PerformAction(IGame game, gameObjects source1, gameObjects source2)
        {
            gameObjects Player = new gameObjects();
            gameObjects fire = new gameObjects();
            if (source1.Otype1 == ObjectType.Player)
            {
                Player = source1;
            }
            if(source2.Otype1 == ObjectType.Player)
            {
                Player = source2;
            }
            if(source1.Otype1 == ObjectType.enemyfire)
            {
                fire = source1;
            }
            if(source2.Otype1 == ObjectType.enemyfire)
            {
                fire = source2;
            }
            game.PlayerDieAction(Player.PictureBox);
            game.EnemeyfireDelete(fire.PictureBox);
        }
    }
}
