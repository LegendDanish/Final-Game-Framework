using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameFramework.Core;
using System.Windows.Forms;

namespace GameFramework.Fire
{
    public interface IFire
    {
        PictureBox Move(IGame game,PictureBox Pb);
    }
}
