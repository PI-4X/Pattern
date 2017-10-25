using SplitMap.Animal.Composite;
using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SplitMap.Animal.Base
{
    public abstract class BaseObject :  IMapComponent
    {
        protected IDrawMaster drawMaster;
        public virtual IDrawMaster GetMaster => drawMaster;
        public IDrawMaster SetMaster
        {
            set { drawMaster = value; }
        }
        protected Guid GuidAction;
        public virtual Guid GetGuid => GuidAction;
        protected ToolTip toolTip { get; set; } = new ToolTip();
        public PictureBox pictureBox { get; set; } = new PictureBox();
        public virtual Point Coordinate { get; set; }
        public virtual int IndexBlock => (Coordinate.X * 10)  + Coordinate.Y;
        public int SizeBitmap { get; }
       
        public BaseObject(IDrawMaster drawMaster, int _x = 0, int _y = 0, int _size = 45)
        {
            GuidAction = Guid.NewGuid();
            Coordinate = new Point(_x, _y);
            SizeBitmap = _size;
            this.drawMaster = drawMaster;
        }
        public BaseObject(int _x = 0, int _y = 0, int _size = 45)
        {}


        public virtual IMapComponent FindChild(Guid name)
        {
            return (this.GetGuid == name) ? this : null;
        }
        public IMapComponent Parent { get; set; }


        public virtual void DrawAbilities()
        {
            throw new NotImplementedException();
        }
        public virtual void DrawObject()
        {
            throw new NotImplementedException();
        }
        public virtual void DestroyObject()
        {
            throw new NotImplementedException();
        }
        public virtual void DrawCompositeObject()
        {
            throw new NotImplementedException();
        }
    }
}
