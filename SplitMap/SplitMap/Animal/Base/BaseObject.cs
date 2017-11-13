using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SplitMap.Animal.Base
{
    public abstract class BaseObject
    {
        public Guid GuidAction { get;  set; } = Guid.NewGuid();
        protected ToolTip toolTip { get; set; } = new ToolTip();
        public PictureBox pictureBox { get; set; } = new PictureBox();
        public virtual Point Coordinate { get; set; } = new Point(0, 0);
        public virtual int IndexBlock => (Coordinate.X * 10)  + Coordinate.Y;
        public int SizeBitmap { get; set; }
       
        public BaseObject(int _size = 45)
        {
            SizeBitmap = _size;
        }

        public abstract void DrawAbilities();
       
        public abstract void DestroyObject();

        public abstract void DrawObject();
        
    }
}
