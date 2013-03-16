using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RobotInterfaces
{
    public interface IBullet
    {
        Vector Position { set; get; }
        Vector Velocity { get; set; }
        Rectangle Rect { set; get; }
        Size Dim { set; get; }
        void Main();
    }
}
