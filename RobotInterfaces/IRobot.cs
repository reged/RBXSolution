using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RobotInterfaces
{
    public delegate void MyHandler1(object sender, RobotEventArgs e);
    public interface IRobot
    {
        
        Vector Position { set; get; }
        Rectangle Rect { set; get; }
        Size Dim { set; get; }

        event MyHandler1 FireEvent;
        void Build();
        void Main();    
        
    }
}
