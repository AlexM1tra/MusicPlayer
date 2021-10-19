using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public double calculateAngleFromNormal()
        {
            if (this.X == 0 && this.Y == 0)
            {
                return 0;
            }
            else if (this.Y == 0)
            {
                return this.X > 0 ? 90 : 270;
            }
            else if (this.X == 0)
            {
                return this.Y >= 0 ? 0 : 180;
            }
            double angle = Math.Atan2(Math.Abs(this.X), Math.Abs(this.Y)) * 180;
            angle = angle / Math.PI;
            angle = angle < 0 ? angle + 180 : angle;
            if (this.X > 0 && this.Y < 0)
            {
                return angle;
            }
            else if (this.X > 0 && this.Y > 0)
            {
                return 180 - angle;
            }
            else if (this.X < 0 && this.Y < 0)
            {
                return 360 - angle;
            }
            else if (this.X < 0 && this.Y > 0)
            {
                return 180 + angle;
            }
            return 0;
        }
    }
}
