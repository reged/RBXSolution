using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBX
{
    public class Field
    {
        static public Int32 width { get; set; }
        static public Int32 height { get; set; }
        static public Vector center { get; set; }
        static public Vector corner_left_top { get; set; }
        static public Vector corner_right_top { get; set; }
        static public Vector corner_left_bottom { get; set; }
        static public Vector corner_rigth_bottom { get; set; }
        static public Vector side_left_center { get; set; }
        static public Vector side_top_center { get; set; }
        static public Vector side_rigth_center { get; set; }
        static public Vector side_bottom_center { get; set; }



        public Field(Int32 field_width, Int32 field_height)
        {
            width = field_width;
            height = field_height;
            center = new Vector(width / 2, height / 2);
            corner_left_top = new Vector(0, 0);
            corner_right_top = new Vector(width, 0);
            corner_left_bottom = new Vector(0, height);
            corner_rigth_bottom = new Vector(width, height);
            side_left_center = new Vector(0, height / 2);
            side_rigth_center = new Vector(width, height / 2);
            side_bottom_center = new Vector(width / 2, height);
            side_top_center = new Vector(width / 2, 0);
        }

    }
}