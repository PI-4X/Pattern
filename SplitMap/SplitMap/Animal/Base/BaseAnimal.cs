using SplitMap.Animal.Composite;
using SplitMap.Animal.Interface;
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
        protected Bitmap Sprite { get; set; }
        public virtual Bitmap GetSprite => Sprite;
        protected virtual StateAnimalEmotion State { get;  set; } = StateAnimalEmotion.Typical;
        public virtual StateAnimalEmotion GetState => State;
        protected abstract void ChangeEmotionalState();       
        #endregion
        #region Protected field
        protected ConcurrentDictionary<Type, string> SetAction;
        public ConcurrentDictionary<string, string> AnimalCharacteristics { get; private set; }
        #endregion
        #region  Constructor
        public BaseAnimal(IDrawMaster drawMaster, int _x = 0, int _y = 0, int _size = 50) : base(drawMaster,_x, _y, _size)
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
        public override void DestroyObject()
        {
            this.drawMaster.DestroyObject(this.pictureBox);
        }
        public override void DrawAbilities()
        {
            this.drawMaster.DrawAbilities(this.pictureBox, this.toolTip, this);
        }
        public override void DrawObject()
        {
            this.drawMaster.DrawObject(this.pictureBox, this);
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
