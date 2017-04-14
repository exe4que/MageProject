﻿using System.Collections;
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
    public const int UNITMAXHEIGHT = 10;
    public enum TileMaterial { WATER, GRASS, ROCK, BLANK, EMPTY };

    public static Pair Index1to2(int _value,int _arrayWidth) {
        int y = (int)(_value / _arrayWidth);
        float x = ((((float)_value/(float)_arrayWidth)-(_value/_arrayWidth))*_arrayWidth);
        Pair ret = new Pair((int)x,y);
        return ret;
    }

    public static Vector3 ToIsometric(Pair _gridPos, float _spacing, int _height, float _unitHeight) {
        float x = (_gridPos.x * _spacing) + (_gridPos.y * _spacing);
        float y = (_gridPos.x * ((-_spacing) * 0.5f)) + (_gridPos.y * (_spacing * 0.5f));
        float z = y + (_unitHeight-(_unitHeight/UNITMAXHEIGHT)*_height);
        y += (_height - 1) * _unitHeight;
        Vector3 pos = new Vector3(x,y,z);
        return pos;
    }
}
