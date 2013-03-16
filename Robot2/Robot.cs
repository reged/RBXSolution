using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using RobotInterfaces;

namespace Robot
{
    public class Robot : IRobot
    {
        
        public event FireToHandler FireEvent;
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
            Position = new Vector(500, 500);
            List<IRobot> Enemies = new List<IRobot>();
            calcRect();
        }
        public void Main()
        {
            Random rand = new Random();
            if ((Position - Enemies[0].Position).Length() < 200)
            {
                GoTo(new Vector(rand.Next(600), rand.Next(600)) - Enemies[0].Position);
            }
            else GoTo(Enemies[0].Position);
            FireTo(Enemies[0].Position);
        }
        public void GoTo(Vector pos) 
        {
            Vector delta = pos - Position;
            float p = 0.5f;
            float length = (int)delta.Length();
            float k = length / 50;
            if (length > 0.5)
            {
                if (k < p)
                {
                    k = p;
                }
                Vector velocity = (pos - Position).GetNormalize() * k;
                Position = Position + velocity;
                calcRect();
            }   
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
