using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    public class Vector
    {
        private double x;
        private double y;

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual Vector Resize(double coef)
        {
            x = x * coef;
            y = y * coef;
            return this;
        }

        public virtual double GetMagnitude()
        {
            return Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Method that changes X coord sign to "-" or "+"
        /// </summary>
        /// <returns></returns>
        public Vector MirrorX()
        {
            x = -x;
            return this;
        }

        /// <summary>
        /// Method that changes Y coord sign to "-" or "+"
        /// </summary>
        /// <returns></returns>
        public Vector MirrorY()
        {
            y = -y;
            return this;
        }

        public override string ToString()
        {
            return (String.Format("Vector coords are x = {0}, y = {1}", x, y));
        }

         public override bool Equals(Object obj)
         {
             Vector v = obj as Vector;
             return (v != null && v.x == x && v.y == y);
         }

         public override int GetHashCode()
         {
             return x.GetHashCode();
         }

         public bool Equals(Vector v)
         {
             return (v != null && v.x == x && v.y == y);
         }
    }


    /// <summary>
    /// Derived class for class Vector
    /// </summary>
    public class Vector3D : Vector
    {
        public double z;


        /// <summary>
        /// Parent and derived class constructors
        /// </summary>

        public Vector3D(double x, double y, double z)
            : base(x, y)
        {
            this.z = z;
        }

        /// <summary>
        /// New method that overrides parent Resize()
        /// </summary>
        /// <param name="coeff"></param>
        /// <returns></returns>
        public override Vector Resize(double coeff)
        {
            base.Resize(coeff);
            z *= coeff;
            return this;
        }
        /// <summary>
        /// Method that overrides Vector Magnitude()
        /// </summary>
        /// <returns></returns>
        /*public override double Magnitude()
        {
            
        }*/

        public override string ToString()
        {
            string s = base.ToString();
            return String.Format("{0}, z = {1}", s, z);
        }

        /*
        // method that overrides parent GetVectorCoords()
        public override void GetVectorCoords()
        {
            Console.WriteLine("Vector3D coords areee x =" + " " + x + " " + ", y =" + " " + y + " " + "and z" + " " + "="  + " " + z);

        }
        // method that overrides parent VectorResize
        public override void VectorResize(double ratio)
        {
            Console.WriteLine("Vector3D resized coords are x =" + " " + x * ratio + " " + ", y =" + " " + y * ratio + " " + "and z" + " " + "=" + " " + z * ratio);
        }
        // method that override parent VectorMagnitude()
        public override void VectorMagnitude()
        {
            double doubleX = x * x;
            double doubleY = y * y;
            double doubleZ = z * z;
            Console.WriteLine("Vector3D magnitude is " + Math.Sqrt(doubleX + doubleY + doubleZ));
        }
        // method that override parent VectorMirrorX
        public override void VectorMirrorX()
        {
            double mirrorX = -x;
            double mirrorY = -y;
            double mirrorZ = -z;
            Console.WriteLine("Vector3D mirrored x, y and z coords are:" + " "+ mirrorX + " " + mirrorY + " " + mirrorZ);
        }
         * */


    }


    class Test
    {
        public static readonly Test Empty = new Test(0);

        private static int count = 0;

        private readonly int value;

        public Test(int i)
        {
            this.value = i;
        }

        public int Value
        {
            get { return value; }
        }

        public static Test GetEmpty()
        {
            return Empty;
        }

        public static Test Next()
        {
            return new Test(++count);
        }

        public static Test operator +(Test t1, Test t2)
        {
            return new Test(t1.Value + t2.Value);
        }

        public static Test operator *(Test t, int value)
        {
            return new Test(t.Value * value);
        }
    }


    public class Program
    {

        static void Main(string[] args)
        {
            Test t = Test.Empty;
            Test t1 = Test.Next();
            Test t2 = Test.Next();
            Test tt = t1 + t2;
            Test ttt = tt * 6;
            Vector z1 = new Vector(1, 9);
            Vector3D v1 = new Vector3D(3, 1, 2);
            Console.WriteLine(v1);
            Console.ReadLine();
            object[] vectors = new object[] {
                new Vector(0,1),
                new Vector3D(1,2,3),
                "vektor"
            };
            foreach (object obj in vectors)
            {
                if (z1.Equals(obj))
                {
                    break;
                }
            }
            Vector[] vectors1 = new Vector[] {
                new Vector(0,1),
                new Vector(1,4),
                new Vector3D(1,2,3)
            };
            foreach (Vector v in vectors1)
            {
                if (z1.Equals(v))
                {
                    break;
                }
            }
        }
    }
}
