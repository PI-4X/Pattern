using SplitMap.Animal.Base;
using SplitMap.Animal.Bridge;
using SplitMap.Animal.Facade;
using SplitMap.Animal.Information_Expert;
using SplitMap.Animal.Iterator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitMap.Animal.Interface;
using SplitMap.Animal.Adapter;

namespace SplitMap.Animal.Composite
{
    public class ZooComposite : BaseAction
    {
        private List<BaseAction> components = new List<BaseAction>();
        private IIterator<BaseAction> iterator;
        private Aggregate<BaseAction> aggregator = new Aggregate<BaseAction>();
        private BaseAction Parent;
        public override void AddAction(BaseAction baseAction)
        {
            components.Add(baseAction);
        }
        public ZooComposite(BaseAction parent)
        {
            Parent = parent;
        }
        public override void DestroyObject()
        {
            aggregator.SetCollection(components);
            iterator = aggregator.GetIterator();
            for (var item = iterator.FirstItem; iterator.IsDone == false; item = iterator.NextItem)
            {
                item.DestroyObject();
            }
        }

        public override void DrawAbilities()
        {
            aggregator.SetCollection(components);
            iterator = aggregator.GetIterator();
            toolTip.RemoveAll();
            string info = string.Empty;
            for (var item = iterator.FirstItem; iterator.IsDone == false; item = iterator.NextItem)
            {            
                info += $"{baseDescribeAction.GetNameAction}";
            }
            toolTip.SetToolTip(pictureBox, info);
        }

        public override void DrawObject()
        {
            int pro_size = 2;
            aggregator.SetCollection(components);
            iterator = aggregator.GetIterator();
            Graphics _graphic = Parent.pictureBox.CreateGraphics();
            _graphic.DrawImage(Parent.baseDescribeAction.Sprite, 0, 0, 45, 45);
            for (var item = iterator.FirstItem; iterator.IsDone == false; item = iterator.NextItem)
            {
                item.SizeBitmap -= 6 * pro_size;
                item.ExternalCoordinate = new Point(item.ExternalCoordinate.X + 5, item.ExternalCoordinate.Y + 5);
                item.DrawObject();
                pro_size += 1;
            }
            _graphic.Dispose();
        }

        public override bool StartAction()
        {
            aggregator.SetCollection(components);
            iterator = aggregator.GetIterator();
            bool isCan = true;
            for (var item = iterator.FirstItem; iterator.IsDone == false; item = iterator.NextItem)
            {
                isCan = isCan && item.StartAction();
            }
            return isCan;
        }

        public override async Task<bool> StartActionAsync()
        {
            aggregator.SetCollection(components);
            iterator = aggregator.GetIterator();
            bool isCan = true;
            for (var item = iterator.FirstItem; iterator.IsDone == false; item = iterator.NextItem)
            {
                isCan = isCan && (await item.StartActionAsync());
            }
            return isCan;
        }
    }
}
