using SplitMap.Animal.Base;
using SplitMap.Animal.Interface;
using System;
using System.Drawing;


namespace SplitMap
{
    /// <summary>
    /// Defines the parameters which will be used to find a path across a section of the map
    /// </summary>
    public class SearchParameters
    {
        private static readonly object locker = new object();

        public Point StartLocation { get; set; }

        public Point EndLocation { get; set; }

        public static bool[,] Map { get; set; }

        public static IAnimalAction[,] TypesMap { get; set; }

        public SearchParameters(Point startLocation, Point endLocation)
        {
            this.StartLocation = startLocation;
            this.EndLocation = endLocation;

        }
        public static void InitilizeMap(bool[,] map, IAnimalAction[,] type_map)
        {
            Map = map;
            TypesMap = type_map;
        }
        public void UpdateNode(int x, int y, bool value)
        {
            lock (locker)
            {
                Map[x, y] = value;
            }
        }
        public void UpdateTypeNode(int x, int y, IAnimalAction action)
        {
            lock (locker)
            {
                TypesMap[x, y] = action;
            }

        }

    }
}
