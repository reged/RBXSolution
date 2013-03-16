using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace RobotInterfaces
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector

    {
        float x;
        float y;

        public static readonly Vector Zero = new Vector(0.0f, 0.0f);
        public static readonly Vector XAxis = new Vector(1.0f, 0.0f);
        public static readonly Vector YAxis = new Vector(0.0f, 1.0f);

        public Vector(Vector a)
        {
            x = a.x;
            y = a.y;
        }

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        [DefaultValue(0.0f)]
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        [DefaultValue(0.0f)]
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public static Vector Parse(string text)
        {
            if (text == null || text.Length == 0)
                throw new ArgumentNullException("Invalid format.");

            string[] vals = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (vals.Length != 2)
                throw new FormatException("Invalid format");

            try
            {
                return new Vector(
                  float.Parse(vals[0]),
                  float.Parse(vals[1]));
            }
            catch (Exception)
            {
                throw new FormatException("Invalid format.");
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", x, y);
        }

        public string ToString(int precision)
        {
            string format = "";
            format = format.PadLeft(precision, '#');
            format = "{0:0." + format + "} {1:0." + format + "}";
            return string.Format(format, x, y);
        }

        public override bool Equals(object obj)
        {
            return (obj is Vector && this == (Vector)obj);
        }

        public override int GetHashCode()
        {
            return (x.GetHashCode() ^ y.GetHashCode());
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.x * b.x, a.y * b.y);
        }

        public static Vector operator *(Vector a, float s)
        {
            return new Vector(a.x * s, a.y * s);
        }

        public static Vector operator /(Vector a, float s)
        {
            float invS = 1.0f / s;
            return new Vector(a.x * invS, a.y * invS);
        }

        public static Vector operator /(Vector a, Vector b)
        {
            return new Vector(a.x / b.x, a.y / b.y);
        }

        public static Vector operator *(float s, Vector b)
        {
            return new Vector(b.x * s, b.y * s);
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return (a.x == b.x && a.y == b.y);
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return (a.x != b.x || a.y != b.y);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.x, -v.y);
        }

      /*  public unsafe float this[int index]
        {
            get
            {
                if (index < 0 || index > 1)
                    throw new ArgumentOutOfRangeException("index");
                fixed (float* v = &this.x)
                {
                    return v[index];
                }
            }
            set
            {
                if (index < 0 || index > 1)
                    throw new ArgumentOutOfRangeException("index");
                fixed (float* v = &this.x)
                {
                    v[index] = value;
                }
            }
        }*/

        public float Dot(Vector v)
        {
            return x * v.x + y * v.y;
        }

        public static float Dot(Vector a, Vector b)
        {
            return a.Dot(b);
        }

        public Vector Cross(Vector v)
        {
            return new Vector((y * v.x) - (x * v.y), (x * v.y) - (y * v.x));
        }

        public static Vector Cross(Vector a, Vector b)
        {
            return a.Cross(b);
        }

        public bool Equals(Vector a, float epsilon)
        {
            if (Math.Abs(x - a.x) > epsilon)
                return false;
            if (Math.Abs(y - a.y) > epsilon)
                return false;
            return true;
        }

        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public float LengthSqr()
        {
            return x * x + y * y;
        }

        public float Normalize()
        {
            float sqrLength = LengthSqr();
            float invLength = 1/(float)Math.Sqrt(sqrLength);
            x *= invLength;
            y *= invLength;
            return invLength * sqrLength;
        }

        public void Clamp(Vector min, Vector max)
        {
            if (x < min.x)
                x = min.x;
            else if (x > max.x)
                x = max.x;

            if (y < min.y)
                y = min.y;
            else if (y > max.y)
                y = max.y;
        }

        public Vector GetNormalize()
        {
            Vector vec = new Vector(this);
            vec.Normalize();
            return vec;
        }

        public static Vector Normalize(Vector v)
        {
            return v.GetNormalize();
        }

    }
}