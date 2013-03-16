using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using RobotInterfaces;

namespace Robot1
{
    public class Robot : IRobot
    {
        
        public event MyHandler1 FireEvent;
        public bool Alive { set; get; }
        public Int32 HP { set; get; }
        public List<IRobot> Enemies { set; get; }
        public Vector Position { set; get; }
        public Rectangle Rect { set; get; }
        public Size Dim { set; get; }

        public void Build()
        {
            Alive = true;
            HP = 100;
            Dim = new Size(20, 20);
            Position = new Vector(300, 300);
            List<IRobot> Enemies = new List<IRobot>();
            calcRect();
        }
        public void Main()
        {
            GoTo(new Vector(10, 10));
            FireTo(new Vector(500, 50));
        }
        public void GoTo(Vector pos) 
        {
            Vector velocity = (pos - Position).GetNormalize() * 5;
            Position = Position + velocity;
            calcRect();     
        }
        public void FireTo(Vector pos) 
        {
            RobotEventArgs e = new RobotEventArgs();
            e.Bullet = new Bullet(Position + (pos - Position).GetNormalize() * 20, (pos - Position).GetNormalize(), 5);
            FireEvent(this, e);        
        }
        void calcRect()
        {
            Rect = new Rectangle((int)Position.X - Dim.Width / 2, (int)Position.Y - Dim.Height / 2, Dim.Width, Dim.Height);

        }
       
    }
}
