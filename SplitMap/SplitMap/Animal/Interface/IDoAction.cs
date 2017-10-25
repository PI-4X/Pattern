using System;
using System.Threading.Tasks;
namespace SplitMap.Animal.Interface
{
    public interface IDoAction
    {
        Task<bool> MakeActionAsync(IAnimalAction _action);
        bool MakeAction(IAnimalAction _action);
    }
}
