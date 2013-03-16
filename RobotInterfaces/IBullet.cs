using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RobotInterfaces
{
    public delegate void BulletMainHandler(object sender, RobotEventArgs e);
    public interface IBullet
    {
        Int32 Damage { set; get; }
        Vector Position { set; get; }
        Vector Velocity { get; set; }
        Rectangle Rect { set; get; }
        Size Dim { set; get; }

       // event BulletMainHandler FireEvent;

        void Main();
    }
}
