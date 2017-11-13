using SplitMap.Animal.Bridge;
using SplitMap.Animal.Facade;
using SplitMap.Animal.Information_Expert;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace SplitMap.Animal.Base
{
    public abstract class BaseAnimal : BaseObject
    {
        #region Protected properties
        public Bitmap Sprite { get;  set; }
        public TravelExpert travelExpert = new TravelExpert(new Wanderer());
        protected virtual StateAnimalEmotion State { get;  set; } = StateAnimalEmotion.Typical;
        protected abstract void ChangeBitmap();
        public Point ConsolePoint { get; set; }
        #endregion
        #region Protected field
        protected ConcurrentDictionary<Type, string> SetAction;
        protected ConcurrentDictionary<string, string> AnimalCharacteristics { get; set; }
        #endregion
        #region  Constructor
        public BaseAnimal(int _size = 50) : base(_size)
        {
            SetAction = new ConcurrentDictionary<Type, string>();
            AnimalCharacteristics = new ConcurrentDictionary<string, string>();
        }
        #endregion
        #region Public method    
        public override Point Coordinate { get => new Point(pictureBox.Location.X / 50, pictureBox.Location.Y / 50); set => base.Coordinate = value; }
        public virtual async Task AddCharacteristic(string type, string _characteristic)
        {
            var task = Task.Factory.StartNew(() =>
            {
                AnimalCharacteristics[type] = _characteristic;
            });
            await task;
        }
        public virtual  void AddCharacteristicSync(string type, string _characteristic)
        {
            AnimalCharacteristics[type] = _characteristic;           
        }



        public virtual IEnumerable<KeyValuePair<string,string>> GeneratorCharacteristics()
        {
            foreach (var e in AnimalCharacteristics)
            {
                yield return e;
            }
        }
        public virtual IEnumerable<string> GeneratorAction()
        {
            foreach (var e in SetAction)
            {
                yield return e.Value;
            }
        }

        public void DoStep(KindStep kindStep, List<FieldMap> PictureControls)
        {
            travelExpert.DoStep(this, PictureControls[this.IndexBlock], PictureControls, kindStep);
        }
        public void DoStep(KindStep kindStep)
        {
            //travelExpert.DoStep(this, kindStep);
        }


        #endregion
    }
    public enum StateAnimalEmotion
    {
        Sad = 0,
        Hungry = 1,
        Ill = 2,
        Moving = 3,
        Happy = 4,
        Learning = 5,
        Typical = 6,
    }
}
