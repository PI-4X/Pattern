using SplitMap.Animal.Base;
using SplitMap.Animal.BridgeDraw;
using SplitMap.Animal.Interface;
using System.Drawing;
using System.Threading.Tasks;

namespace SplitMap.Animal.Action
{
    public class ClimbToRockAction : BaseAction
    {
        private IDrawMaster drawMaster = new DrawConsole();
        public override BaseDescribeAction baseDescribeAction { get; set; }
        public ClimbToRockAction(int _size = 45) : base(_size) { }
        public ClimbToRockAction(IDrawMaster _drawMaster, int _size = 45) : base(_size) { drawMaster = _drawMaster;  }
        public override async Task<bool> StartActionAsync()
        {
            return await Task.Factory.StartNew(() => true);
        }
        public override bool StartAction()
        {
            return true;
        }
        public override void DrawAbilities()
        {
            toolTip.SetToolTip(pictureBox, $"{baseDescribeAction.GetNameAction}");
        }
        public override void DrawObject()
        {
            drawMaster.DrawObject(this);
            //var _graphic = pictureBox.CreateGraphics();
            //_graphic.DrawImage(baseDescribeAction.Sprite, ExternalCoordinate.X, ExternalCoordinate.Y, SizeBitmap, SizeBitmap);
        }
        public override void DestroyObject()
        {
            pictureBox.Image = null;
        }

     
    }
}
