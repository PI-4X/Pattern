using SplitMap.Animal.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitMap.Animal.Facade
{
    public interface IFacade
    {
        void CreateMap(Panel control);
        Task CreateAction(KindAction kindAction, int x, int y);
        Task<BaseAnimal> CreateAnimal(KindAnimal kindAnimal, int x, int y);
    }
}
