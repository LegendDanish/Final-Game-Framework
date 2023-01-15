using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Core;
namespace GameFramework.Collision
{
    public interface ICollision
    {
        void PerformAction(IGame game, gameObjects source1, gameObjects source2);
    }
}
