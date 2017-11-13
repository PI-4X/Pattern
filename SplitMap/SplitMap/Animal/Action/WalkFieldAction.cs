using SplitMap.Animal.Base;
using SplitMap.Animal.BridgeDraw;
using SplitMap.Animal.Interface;
using System.Drawing;
using System.Threading.Tasks;

namespace SplitMap.Animal.Action
{
    public class WalkFieldAction : BaseAction
    {
        private IDrawMaster drawMaster = new DrawConsole();
        public override BaseDescribeAction baseDescribeAction { get; set; }
        public WalkFieldAction(IDrawMaster _drawMaster, int _size = 45) : base(_size) { drawMaster = _drawMaster; }
        public WalkFieldAction(int _size = 45) : base( _size)
        {

        }

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
            //pictureBox.Image = null;
            //pictureBox.BackColor = Color.Transparent;
        }

        public override void DestroyObject()
        {
            pictureBox.Image = null;
        }

       
    }
}
