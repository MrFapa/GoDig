using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LandTypes
{
    public enum landValueType
    {
        undefined,
        land,
        coast,
        water,
        border
    }

    public class LandValueTypeFunctions
    {
        public static bool isLandType(landValueType tileType)
        {
            return (tileType == landValueType.land || tileType == landValueType.coast);
        }
    }
    
}
