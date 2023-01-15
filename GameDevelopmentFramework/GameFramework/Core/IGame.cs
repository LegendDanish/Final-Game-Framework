using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GameFramework.Core
{
    public interface IGame
    {
        void PlayerDieAction(PictureBox pb);
        void FireDeleteAction(PictureBox pb);
        void Enemy1DieAction(PictureBox pb);
        void Enemy2DieAction(PictureBox pb);
        void EnemeyfireDelete(PictureBox pb);
        void CountScore();
    }
}

