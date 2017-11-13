using SplitMap.Animal.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Decorator
{
    public abstract class ActionDecorator : BaseAction
    {
        protected BaseAction baseAction;
        public ActionDecorator(Color color, double amount, BaseAction _baseAction): base()
        {
            this.baseAction = _baseAction;
            baseAction.pictureBox.BackColor = Blend(color, amount);
        }
        private Color Blend(Color color, double amount)
        {
            var currentColor = baseAction.pictureBox.BackColor;
            byte r = (byte)((color.R * amount) + currentColor.R * (1 - amount));
            byte g = (byte)((color.G * amount) + currentColor.G * (1 - amount));
            byte b = (byte)((color.B * amount) + currentColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }
    }
}
