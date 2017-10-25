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
    public class DrawAnimal : IDrawMaster
    {
        public void DestroyObject(PictureBox control)
        {
            control.Image = null;
        }

        public void DrawAbilities(PictureBox control, ToolTip toolTip, BaseObject baseObject)
        {
            toolTip.RemoveAll();
            string info = string.Empty;
            foreach (var item in (baseObject as BaseAnimal).AnimalCharacteristics)
                info += $"{item.Key} - {item.Value}\n";
            //foreach (var item in (baseObject as BaseAnimal).GetAllKnowAction())
            //    info += $"I can {item}\n";
            info += (baseObject as BaseAnimal).GetState;
            toolTip.SetToolTip(control, info);
        }

        public void DrawObject(PictureBox control, BaseObject baseObject)
        {
            
            var monkey = (baseObject as BaseAnimal);
            //control.Image = new Bitmap(monkey.GetSprite, new Size(monkey.SizeBitmap, monkey.SizeBitmap));


            var g = control.CreateGraphics();
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 5);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 5, 5);

            g.DrawRectangle(blackPen, rect);
            g.DrawImage(new Bitmap(monkey.GetSprite, new Size(monkey.SizeBitmap, monkey.SizeBitmap)),0,0);
            g.Dispose();
        }
    }
}
