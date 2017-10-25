using SplitMap.Animal.Base;
using System.Drawing;
using System.Threading.Tasks;

namespace SplitMap.Animal.Decorator
{
    public class RedActionDecorator : ActionDecorator
    {
        public RedActionDecorator(BaseAction baseAction) : base(Color.Red, 0.5, baseAction)
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
