using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RobotInterfaces
{
    public delegate void FireToHandler(object sender, RobotEventArgs e);
    public interface IRobot
    {
        bool Alive { set; get; }
        Int32 HP { set; get; }
        Vector Position { set; get; }
        Rectangle Rect { set; get; }
        Size Dim { set; get; }
        List<IRobot> Enemies { set; get; }
        
        event FireToHandler FireEvent;
        void Build();
        void Main();    
        
    }
}
