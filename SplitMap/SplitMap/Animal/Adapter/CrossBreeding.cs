using SplitMap.Animal.Base;
using SplitMap.Animal.Derived;
using SplitMap.Animal.Interface;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace SplitMap.Animal.Adapter
{
    public class CrossBreeding : BaseAction
    {
        public override BaseDescribeAction baseDescribeAction { get; set; } = new ArrowDescribeAction();
        public ArrowSign Arrow { get; }
        public CrossBreeding(IDrawMaster drawMaster,  ArrowSign _arrow) : base(drawMaster)
        {
            Arrow = _arrow;
        }
       

        #region Implements IDrawMaster
        public override void DestroyObject()
        {
            this.pictureBox.Image = null;
        }

        public override void DrawAbilities()
        {
            toolTip.SetToolTip(pictureBox, $"{Arrow.CurrentArrow}");
        }
        public override void DrawObject()
        {
            Coordinate = new Point(pictureBox.Location.Y / 50, pictureBox.Location.X / 50);
            pictureBox.Image = new Bitmap(Arrow.GetBitmap, new Size(SizeBitmap, SizeBitmap));
        }


        #endregion


        public override async Task<bool> StartActionAsync()
        {
            return await Task.Factory.StartNew(() => true);
        }

        public override bool StartAction()
        {
            return true;
        }


    }
}
