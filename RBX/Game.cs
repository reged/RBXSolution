﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RobotInterfaces;


namespace RBX
{
    public class Game
    {
        #region Fields
        private Field field;
       
        private Graphics graph;
        #endregion
        
        #region Properties
        public Bitmap Bmp { get; set; }
        static public List<IRobot> Robots { set; get; }        
        static public List<IBullet> Bullets { set; get; }
        public String str { set; get; }
        #endregion

        

        public Game (Int32 fieldw, Int32 fieldh, String dll1="", String dll2="", String dll3="")
        {
            Robots = new List<IRobot>();
            Bullets = new List<IBullet>();
            field = new Field(fieldw, fieldw);
            Random rand = new Random();

            str = "";
            Assembly AI1 = Assembly.LoadFrom(@dll1);
            Assembly AI2 = Assembly.LoadFrom(@dll2);
            Robots.Add((IRobot)AI1.CreateInstance("Robot1.Robot"));
            Robots.Add((IRobot)AI2.CreateInstance("Robot2.Robot"));          
            MyHandler1 d1 = new MyHandler1(OnHandler1);
            Robots[0].Build();
            Robots[0].FireEvent += d1;
           Robots[1].Build();
           Robots[1].FireEvent += d1;

            
            /*
            Robots.Add(new Robot(dll1, new Vector((float)rand.Next(20, 580), (float)rand.Next(20, 580))));
            Robots.Add(new Robot(dll2, new Vector((float)rand.Next(20, 580), (float)rand.Next(20, 580))));
            Robots.Add(new Robot(dll3, new Vector((float)rand.Next(20, 580), (float)rand.Next(20, 580))));
            */
            field = new Field(fieldw, fieldh);
            Bmp = new Bitmap(Field.width, Field.height);
            graph = Graphics.FromImage(Bmp);
            Draw();
        }

     
        #region Public methods

        public void OnHandler1(object sender, RobotEventArgs e)
        {
            Bullets.Add(e.Bullet);
            str = "MyEvent" + e.Bullet.Position.ToString();
        }

        public void NextStep()
        {
            for (int i = 0; i < Robots.Count; i++)
            {
                if (Robots[i].Alive)
                {
                    IRobot robot = Robots[i];
                    robot.Main();
                    robot.Enemies = new List<IRobot>(Robots);
                    robot.Enemies.Remove(robot);
                    if (robot.HP <= 0)
                    {
                        DestroyRobot(robot);
                        robot.Alive = false;
                    }
                }
            }

            
            for (int i = 0; i < Bullets.Count; i++)
            {
                Bullets[i].Main();
            }
            
            Draw();
        }
        #endregion

        #region Private methods
        private void Draw()
        {
            graph.Clear(Color.White);
            foreach (IRobot robot in Robots)
            {
                if (robot.Alive)
                {
                    graph.DrawRectangle(new Pen(Color.Red, 2), robot.Rect);
                }
                else
                {
                    graph.DrawRectangle(new Pen(Color.Black, 2), robot.Rect);
                }
            }

            
            foreach (IBullet bullet in Bullets)
            {
                graph.DrawEllipse(new Pen(Color.Black, 2), bullet.Rect);
            }
        }
       
        private void DestroyRobot(IRobot robot)
        {
            graph.FillRectangle(new SolidBrush(Color.Black), robot.Rect);
        }

        private void Finish(IRobot robot)
        {
            graph.FillRectangle(new SolidBrush(Color.Gold), robot.Rect);           
        }
        #endregion
    }
}
