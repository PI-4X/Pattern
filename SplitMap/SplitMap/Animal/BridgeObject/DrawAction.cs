using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitMap.Animal.Base;
using System.Windows.Forms;
using System.Drawing;

namespace SplitMap.Animal.BridgeObject
{
    public class DrawAction : IDrawMaster
    {
        public void DestroyObject(PictureBox control)
        {
            control.Image = null;
        }

        public void DrawAbilities(PictureBox control, ToolTip toolTip, BaseObject baseObject)
        {
            toolTip.SetToolTip(control, $"{(baseObject as BaseAction).baseDescribeAction.GetNameAction}");
        }

        public void DrawObject(PictureBox control, BaseObject baseObject)
        {
            baseObject.Coordinate = new Point(control.Location.Y / 50, control.Location.X / 50);
            control.Image = (baseObject as BaseAction).baseDescribeAction.Sprite;
        }
    }
}
