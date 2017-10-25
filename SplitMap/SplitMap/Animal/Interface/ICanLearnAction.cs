using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.Interface
{
    public interface ICanLearnAction
    {
        Task<bool> LearningActionAsync(Type _actionType, string name);
        bool LearningAction(Type _actionType, string name);
    }
}
