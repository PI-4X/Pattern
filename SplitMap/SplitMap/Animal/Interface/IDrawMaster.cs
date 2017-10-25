using SplitMap.Animal.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitMap.Animal.Interface
{
    public interface IDrawMaster
    {
        void DrawAbilities(PictureBox control, ToolTip toolTip, BaseObject baseObject);
        void DrawObject(PictureBox control, BaseObject baseObject);
        void DestroyObject(PictureBox control);
    }
}
