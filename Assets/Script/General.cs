using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Pair {
    public int x, y;
    public Pair(int _x,int _y) {
        x = _x;
        y = _y;
    }

    public int sqrMagnitude {
        get { return x * y; }
    }
}
public static class Utils {
    public enum TileMaterial { WATER, GRASS, ROCK, BLANK };

    public static Pair Index1to2(int _value,int _arrayWidth) {
        int y = (int)(_value / _arrayWidth);
        float x = ((((float)_value/(float)_arrayWidth)-(_value/_arrayWidth))*_arrayWidth);
        Pair ret = new Pair((int)x,y);
        return ret;
    }
}
