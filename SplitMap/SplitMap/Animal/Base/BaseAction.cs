using SplitMap.Animal.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplitMap.Animal.Base
{
    public abstract class BaseAction : BaseObject, IComparable, IAnimalAction
    {
        public Point ConsolePoint { get; set; }
        public virtual BaseDescribeAction baseDescribeAction { get; set; }
        public int CompareTo(object obj)
        {
            if (this.baseDescribeAction.GetNameAction == (obj as BaseAction).baseDescribeAction.GetNameAction)
                return 0;
            else
                return 1;
        }
        public abstract Task<bool> StartActionAsync();
        public abstract bool StartAction();
        public BaseAction(int _size = 45) : base(_size) { }
        public override Point Coordinate { get => new Point(pictureBox.Location.X / 50, pictureBox.Location.Y / 50); set => base.Coordinate = value; }
        public Point ExternalCoordinate { get; set; } = new Point(0, 0);
        public virtual void AddAction(BaseAction baseAction)
        {
            throw new NotImplementedException();
        }

    }
    /// <summary>
    /// Level of difficulty of action
    /// </summary>
    public enum LevelAction
    {
        Easy = 0,
        Medium = 1,
        Hard = 2,
        ExstraHard = 3
    }
}
