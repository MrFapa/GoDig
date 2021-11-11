using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NeighbourValues
{
    public enum NeighbourValueType
    {
        TopLeft = 0,
        Top = 1,
        TopRight = 2,
        Left = 3,
        Right = 4,
        BottomLeft = 5,
        Bottom = 6,
        BottomRight = 7
    }

    public class NeighbourValueTypeFunctions
    {
        public static Vector2Int Offset(NeighbourValueType dir)
        {
            Vector2Int Result = new Vector2Int(0, 0);
            switch (dir)
            {
                case NeighbourValueType.TopLeft:
                    Result.Set(-1, -1);
                    break;
                case NeighbourValueType.Top:
                    Result.Set(0, -1);
                    break;
                case NeighbourValueType.TopRight:
                    Result.Set(1, -1);
                    break;
                case NeighbourValueType.Left:
                    Result.Set(-1, 0);
                    break;
                case NeighbourValueType.Right:
                    Result.Set(1, 0);
                    break;
                case NeighbourValueType.BottomLeft:
                    Result.Set(-1, 1);
                    break;
                case NeighbourValueType.Bottom:
                    Result.Set(0, 1);
                    break;
                case NeighbourValueType.BottomRight:
                    Result.Set(1, 1);
                    break;
            }
            return Result;
        }
    }

}
