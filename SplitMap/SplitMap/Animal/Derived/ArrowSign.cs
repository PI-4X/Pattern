using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Derived
{
    public class ArrowSign
    {
        public ArrowEnum CurrentArrow { get; set; } = ArrowEnum.Up;
        protected Dictionary<ArrowEnum, Bitmap> ArrowSet;
        public ArrowSign()
        {
            ArrowSet = new Dictionary<ArrowEnum, Bitmap>
            {
                [ArrowEnum.Up] = (new Bitmap(@"Picture\Arrow\Up.png")),
                [ArrowEnum.Down] = (new Bitmap(@"Picture\Arrow\Down.png")),
                [ArrowEnum.Left] = (new Bitmap(@"Picture\Arrow\Left.png")),
                [ArrowEnum.Right] = (new Bitmap(@"Picture\Arrow\Right.png"))
            };

        }
        public Bitmap GetBitmap => ArrowSet[CurrentArrow];
    }
    public enum ArrowEnum
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }
}
