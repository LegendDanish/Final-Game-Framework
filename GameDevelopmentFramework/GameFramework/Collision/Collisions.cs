using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.ObjectsTypes;
namespace GameFramework.Collision
{
    public class Collisions
    {
        private ObjectType g1;
        private ObjectType g2;

        private ICollision behavior;

        public Collisions(ObjectType g1, ObjectType g2, ICollision behavior)
        {
            G1 = g1;
            G2 = g2;
            Behavior = behavior;
        }
       
        public ObjectType G1 { get => g1; set => g1 = value; }
        public ObjectType G2 { get => g2; set => g2 = value; }
        public ICollision Behavior { get => behavior; set => behavior = value; }    
    }
}
