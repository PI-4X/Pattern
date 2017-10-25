using SplitMap.Animal.Base;
using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitMap.Animal.BridgeObject
{
    class DrawBabyAnimal : IDrawMaster
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


            var image = new Bitmap(monkey.GetSprite, new Size(25, 25));
            var g = monkey.pictureBox.CreateGraphics();
            // Create pen.
            Pen blackPen = new Pen(Color.Red, 15);
            // Create rectangle.
            Rectangle rect = new Rectangle(20, 20, 10, 10);

            g.DrawRectangle(blackPen, rect);
            g.DrawImage(image, 25, 20);
            g.Dispose();
        }
    }
}
