using SplitMap.Animal.Adapter;
using SplitMap.Animal.Base;
using SplitMap.Animal.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SplitMap.Animal.Facade;
using SplitMap.Animal.BridgeDraw;

namespace SplitMap.Animal.Derived
{
    public class Monkey : BaseAnimal, ICanLearnAction, IDoAction
    {
        private IDrawMaster drawMaster = new DrawConsole();
        #region Constructor
        public Monkey(int _size = 50) : base(_size)
        {

            this.Sprite = new Bitmap(@"Picture/Animal/Monkey/Monkey.png");
            SetAction = new ConcurrentDictionary<Type, string>();

        }
        public Monkey(IDrawMaster _drawMaster, int _size = 50) : base(_size)
        {
            this.Sprite = new Bitmap(@"Picture/Animal/Monkey/Monkey.png");
            SetAction = new ConcurrentDictionary<Type, string>();
            drawMaster = _drawMaster;
        }
        #endregion
        #region Base class                  
        protected override void ChangeBitmap()
        {
            switch (State)
            {
                case StateAnimalEmotion.Happy:
                    {
                        Sprite = new Bitmap(@"Picture/Animal/Monkey/Happymonkey.png");
                        break;
                    }
                case StateAnimalEmotion.Sad:
                    {
                        Sprite = new Bitmap(@"Picture/Animal/Monkey/Sadmonkey.png");
                        break;
                    }
                case StateAnimalEmotion.Learning:
                    {
                        Sprite = new Bitmap(@"Picture/Animal/Monkey/Learningmonkey.png");
                        break;
                    }
                case StateAnimalEmotion.Typical:
                    {
                        Sprite = new Bitmap(@"Picture/Animal/Monkey/Monkey.png");
                        break;
                    }
                case StateAnimalEmotion.Moving:
                    {
                        Sprite = new Bitmap(@"Picture/Animal/Monkey/MonkeyClimb.png");
                        break;
                    }
            }
        }
        #endregion
        #region Implements IDrawMaster
        public override void DestroyObject()
        {
            drawMaster.DestroyObject(this);
            pictureBox.Image = null;
        }
        public override void DrawAbilities()
        {
            drawMaster.DrawAbilities(this);
            toolTip.RemoveAll();
            string info = string.Empty;
            foreach (var item in AnimalCharacteristics)
                info += $"{item.Key} - {item.Value}\n";
            foreach (var item in GeneratorAction())
                info += $"I can {item}\n";
            info += State;
            toolTip.SetToolTip(pictureBox, info);
        }
        public override void DrawObject()
        {
            drawMaster.DrawObject(this);
            //toolTip.RemoveAll();
           // pictureBox.Image = new Bitmap(Sprite, new Size(SizeBitmap, SizeBitmap));
        }
        #endregion
        #region Implements ICanLearnAction
        public async Task<bool> LearningActionAsync(Type _actionType, string name)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var contains = SetAction.ContainsKey(_actionType);
                if (!contains)
                {
                    SetAction[_actionType] = name;

                }
                return contains;
            });
            return await task;
        }
        public bool LearningAction(Type _actionType, string name)
        {
            var contains = SetAction.ContainsKey(_actionType);
            if (!contains)
            {
                SetAction[_actionType] = name;


            }
            return contains;
        }
        #endregion
        #region Implements IDoAction
        public async Task<bool> MakeActionAsync(IAnimalAction _action)
        {
            var actionType = _action.GetType();
            if (actionType == typeof(CrossBreeding))
                return true;
           
                if (SetAction.ContainsKey(actionType))
                {
                    var result = await _action.StartActionAsync();
                    if (result)
                        State = StateAnimalEmotion.Happy;
                    else
                        State = StateAnimalEmotion.Sad;

                    ChangeBitmap();
                    return result;
                }
            
            State = StateAnimalEmotion.Learning;
            ChangeBitmap();
            return false;
        }
        public bool MakeAction(IAnimalAction _action)
        {
            var actionType = _action.GetType();
            
            if (actionType == typeof(CrossBreeding))
                return true;
           
                if (SetAction.ContainsKey(actionType))
                {
                    var result = _action.StartAction();
                    if (result)
                        State = StateAnimalEmotion.Happy;
                    else
                        State = StateAnimalEmotion.Sad;

                    ChangeBitmap();
                    return result;
                }

            
            State = StateAnimalEmotion.Learning;
            ChangeBitmap();
            return false;
        }

    


        #endregion
    }
}
