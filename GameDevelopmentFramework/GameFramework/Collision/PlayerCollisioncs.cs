using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Core;
using GameFramework.ObjectsTypes;
namespace GameFramework.Collision
{
    public class PlayerCollision : ICollision
    {
        public void PerformAction(IGame game, gameObjects source1 , gameObjects source2)
        {
            gameObjects player;
            if(source1.Otype1 == ObjectType.Player)
            {
               player = source1;
            }
            else
            {
                player = source2;
            }
            game.PlayerDieAction(player.PictureBox);
        }
    }
}
