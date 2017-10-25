using System.Threading.Tasks;

namespace SplitMap.Animal.Interface
{
    public interface IAnimalAction
    {
        Task<bool> StartActionAsync();
        bool StartAction();
    }
}
