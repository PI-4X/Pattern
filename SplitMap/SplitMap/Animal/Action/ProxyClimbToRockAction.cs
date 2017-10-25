using SplitMap.Animal.Base;
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

        private readonly IAnimalAction RealyClimb;

        public override BaseDescribeAction baseDescribeAction { get; set; }

        public ProxyClimbToRockAction(IDrawMaster drawMaster, int _x = 0, int _y = 0, int _size = 45) : base(drawMaster, _x, _y, _size)
        {
            RealyClimb = new ClimbToRockAction(drawMaster);

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
            Coordinate = new Point(pictureBox.Location.Y / 50, pictureBox.Location.X / 50);
            pictureBox.Image = baseDescribeAction.Sprite;
        }

        public override void DestroyObject()
        {
            pictureBox.Image = null;
        }
    }
}
