using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitMap.Animal.BridgeDraw
{
    public static class Containers
    {
        struct Container
        {
            public int Id;
            public int X;
            public int Y;
            public string Content;
        }
        private static Container[,] Items = new Container[80, 25];
        

        private static int Identity = 0;

        public static int Add(string text, int x,int y)
        {
            var c = new Container
            {
                Id = Identity++,
                X = x,
                Y = y,
                Content = text
            };
            Console.Write(text);
            Items[x,y] = c;
            return c.Id;
        }
        public static int Add(string text)
        {
            var c = new Container
            {
                Id = Identity++,
                X = Console.CursorLeft,
                Y = Console.CursorTop,
                Content = text
            };
            Console.Write(text);
            Items[Console.CursorLeft, Console.CursorTop] = c;
            return c.Id;
        }


        public static void Remove(int x, int y)
        {
            var _temp = Items[x, y];
            Items[x, y] = new Container
            {
                Id = _temp.Id,
                X = x,
                Y = y,
                Content = " "
            };
        }

        public static void Replace(string text,int _x, int _y)
        {
            if((_y < 25 || _y > 0) && (_x > 0 || _x < 81 ))
            {
                int x = Console.CursorLeft, y = Console.CursorTop;
                Container c = Items[_x, _y];
                Console.SetCursorPosition(_x, _y);
                Console.Write(text);
                c.Content = text;
                Console.SetCursorPosition(x, y);

            }
            
        }

        public static void Clear()
        {
            Array.Clear(Items,0,Items.Length);
            Identity = 0;
        }
    }
}
