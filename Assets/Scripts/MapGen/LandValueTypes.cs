using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LandTypes
{
    public enum LandValueType
    {
        undefined,
        land,
        coast,
        water,
        border
    }

    public class LandValueTypeFunctions
    {
        public static bool isLandType(LandValueType tileType)
        {
            return (tileType == LandValueType.land || tileType == LandValueType.coast);
        }
    }

}
