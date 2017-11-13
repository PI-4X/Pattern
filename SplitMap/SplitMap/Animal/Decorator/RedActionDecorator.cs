using SplitMap.Animal.Base;
using System.Drawing;
using System.Threading.Tasks;

namespace SplitMap.Animal.Decorator
{
    public class RedActionDecorator : ActionDecorator
    {
        public RedActionDecorator(BaseAction baseAction) : base(Color.Red, 0.5, baseAction)
        { }

        public override void DestroyObject()
        {
            baseAction.DestroyObject();
        }

        public override void DrawAbilities()
        {
            baseAction.DrawAbilities();
        }

        public override void DrawObject()
        {
            baseAction.DrawObject();
        }

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
