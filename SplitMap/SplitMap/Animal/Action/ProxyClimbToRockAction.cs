using SplitMap.Animal.Base;
using SplitMap.Animal.BridgeDraw;
using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Action
{
    public class ProxyClimbToRockAction : BaseAction
    {
        public int ClimbHeight { get; set; } = 25;

        private readonly BaseAction RealyClimb;

        public override BaseDescribeAction baseDescribeAction { get; set; }

        private IDrawMaster drawMaster = new DrawConsole();


        public ProxyClimbToRockAction(IDrawMaster _drawMaster, int _size = 45) : base(_size) { drawMaster = _drawMaster; }

        public ProxyClimbToRockAction(int _size = 45) : base(_size)
        {
            RealyClimb = new ClimbToRockAction();

        }

        public override async Task<bool> StartActionAsync()
        {
            var ascend = false;
            if (ClimbHeight <= 25)
                ascend = await RealyClimb.StartActionAsync();
            return ascend;
        }

        public override bool StartAction()
        {
            var ascend = false;
            if (ClimbHeight <= 25)
                ascend = RealyClimb.StartAction();
            return ascend;
        }

        public override void DrawAbilities()
        {
            toolTip.SetToolTip(pictureBox, $"{baseDescribeAction.GetNameAction}");
        }

        public override void DrawObject()
        {
            drawMaster.DrawObject(this);
            //var _graphic = pictureBox.CreateGraphics();
            //_graphic.DrawImage(RealyClimb.baseDescribeAction.Sprite, ExternalCoordinate.X, ExternalCoordinate.Y, SizeBitmap, SizeBitmap);
        }

        public override void DestroyObject()
        {
            pictureBox.Image = null;
        }
     
    }
}
