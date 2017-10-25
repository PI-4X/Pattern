using SplitMap.Animal.Base;
using SplitMap.Animal.Interface;
using System.Drawing;
using System.Threading.Tasks;

namespace SplitMap.Animal.Action
{
    public class ClimbToRockAction : BaseAction
    {

        public override BaseDescribeAction baseDescribeAction { get; set; }
        public ClimbToRockAction(IDrawMaster drawMaster, int _x = 0, int _y = 0, int _size = 45) : base(drawMaster,_x, _y,_size)
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
            Coordinate = new Point(pictureBox.Location.Y / 50, pictureBox.Location.X / 50);
            pictureBox.Image = baseDescribeAction.Sprite;
        }

        public override void DestroyObject()
        {
            pictureBox.Image = null;
        }
    }
}
