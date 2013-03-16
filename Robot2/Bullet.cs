using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using RobotInterfaces;

namespace Robot2
{
    public class Bullet : IBullet
    {
        public Vector Position { get; set; }
        public Vector Velocity { get; set; }
        public Int32 Damage { get; set; }
        public Size Dim { get; set; } 
        public Rectangle Rect { get; set; }

        public Bullet(Vector position, Vector velocity, Int32 damage)
        {
            Position = position;
            Velocity = velocity;
            Damage = damage;
            Dim = new Size(5, 5);
        }
        public void Main()
        {
            Position = Position + Velocity;
            calcRect();
        }
        void calcRect()
        {
            Rect = new Rectangle((int)Position.X, (int)Position.Y, Dim.Width, Dim.Height);
        }
    }
}