using SplitMap.Animal.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Decorator
{
    public class BlueActionDecorator : ActionDecorator
    {
        public BlueActionDecorator(BaseAction baseAction) : base(Color.Blue, 0.5, baseAction)
        { }
        public override bool StartAction()
        {
            return this.baseAction.StartAction();
        }

        public async override Task<bool> StartActionAsync()
        {
            return await this.baseAction.StartActionAsync();
        }
    }
}
