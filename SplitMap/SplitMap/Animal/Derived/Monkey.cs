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

namespace SplitMap.Animal.Derived
{
    public class Monkey : BaseAnimal, ICanLearnAction, IDoAction
    {
        #region Private members
        private ConcurrentDictionary<Type, string> SetKnowAction;
        #endregion
        #region Constructor
        public Monkey(IDrawMaster drawMaster, int _x = 0, int _y = 0, int _size = 50) : base(drawMaster,_x, _y, _size)
        {

            this.Sprite = new Bitmap(@"Picture/Animal/Monkey/Monkey.png");
            SetKnowAction = new ConcurrentDictionary<Type, string>();
            Sprite.MakeTransparent();

        } 
        #endregion
        #region Private method
        private IEnumerable<string> GetAllKnowAction()
        {
            foreach (var e in SetKnowAction)
            {
                yield return e.Value;
            }
        }
        #endregion

        public override void DrawCompositeObject()
        {
            drawMaster.DrawObject(pictureBox, this);
        }

        #region Base class                  
        protected override void ChangeEmotionalState()
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
                        DrawObject();
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
        //public override void DestroyObject()
        //{
        //    pictureBox.Image = null;
        //}
        //public override void DrawAbilities()
        //{
        //    toolTip.RemoveAll();
        //    string info = string.Empty;
        //    foreach (var item in AnimalCharacteristics)
        //        info += $"{item.Key} - {item.Value}\n";
        //    foreach (var item in GetAllKnowAction())
        //        info += $"I can {item}\n";
        //    info += State;
        //    toolTip.SetToolTip(pictureBox, info);
        //}
        //public override void DrawObject()
        //{
        //    toolTip.RemoveAll();
        //    pictureBox.Image = new Bitmap(Sprite, new Size(SizeBitmap, SizeBitmap));
        //}
        #endregion
        #region Implements ICanLearnAction
        public async Task<bool> LearningActionAsync(Type _actionType, string name)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var contains = SetKnowAction.ContainsKey(_actionType);
                if (!contains)
                {
                    SetKnowAction[_actionType] = name;

                }
                return contains;
            });
            return await task;
        }
        public bool LearningAction(Type _actionType, string name)
        {
            var contains = SetKnowAction.ContainsKey(_actionType);
            if (!contains)
            {
                SetKnowAction[_actionType] = name;


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
           
                if (SetKnowAction.ContainsKey(actionType))
                {
                    var result = await _action.StartActionAsync();
                    if (result)
                        State = StateAnimalEmotion.Happy;
                    else
                        State = StateAnimalEmotion.Sad;

                    ChangeEmotionalState();
                    return result;
                }
            
            State = StateAnimalEmotion.Learning;
            ChangeEmotionalState();
            return false;
        }
        public bool MakeAction(IAnimalAction _action)
        {
            var actionType = _action.GetType();
            
            if (actionType == typeof(CrossBreeding))
                return true;
           
                if (SetKnowAction.ContainsKey(actionType))
                {
                    var result = _action.StartAction();
                    if (result)
                        State = StateAnimalEmotion.Happy;
                    else
                        State = StateAnimalEmotion.Sad;

                    ChangeEmotionalState();
                    return result;
                }

            
            State = StateAnimalEmotion.Learning;
            ChangeEmotionalState();
            return false;
        }
        #endregion
    }
}
