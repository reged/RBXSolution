using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotInterfaces
{
    public class RobotEventArgs : EventArgs
    {
        public IBullet Bullet { set; get; }
    }
}
