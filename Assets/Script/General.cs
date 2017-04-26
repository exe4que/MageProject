using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General {
    [System.Serializable]
    public struct Pair {
        public int x, y;
        public Pair(int _x, int _y) {
            x = _x;
            y = _y;
        }

        public int sqrMagnitude {
            get { return x * y; }
        }
    }

    public class Button {
        public bool up, down, pressed;
    }
}
public static class Utils {
    public const int UNITMAXHEIGHT = 10;
    public static Quaternion ISODEFAULTROTATION = Quaternion.identity, WORLDDEFAULTROTATION = Quaternion.Euler(0, 315, 0);
    public static Vector3 ISODEFAULTSCALE = Vector3.one, WORLDDEFAULTSCALE = new Vector3(0.7f, 0.7f , 0.7f);
    public enum TileMaterial { WATER, GRASS, ROCK, BLANK, EMPTY };

    public static General.Pair Index1to2(int _value, int _arrayWidth) {
        int y = (int) (_value / _arrayWidth);
        float x = ((((float) _value / (float) _arrayWidth) - (_value / _arrayWidth)) * _arrayWidth);
        General.Pair ret = new General.Pair((int) x, y);
        return ret;
    }

    public static Vector3 ToIsometric(General.Pair _gridPos, float _spacing, int _height, float _unitHeight) {
        float x = (_gridPos.x * _spacing) + (_gridPos.y * _spacing);
        float y = (_gridPos.x * ((-_spacing) * 0.5f)) + (_gridPos.y * (_spacing * 0.5f));
        float z = y + (_unitHeight - (_unitHeight / UNITMAXHEIGHT) * _height);
        y += (_height - 1) * _unitHeight;
        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }

    public static Vector3 ToWorldPos(General.Pair _gridPos, float _spacing, int _height, float _unitHeight) {
        float x = _gridPos.x * _spacing;
        float y = _height * _unitHeight;
        float z = _gridPos.y * _spacing;
        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }
}

