using System;
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
}
public static class Utils {
    public const int UNITMAXHEIGHT = 10;
    public static Quaternion ISODEFAULTROTATION = Quaternion.identity, WORLDDEFAULTROTATION = Quaternion.Euler(90, 0, 45);
    public static Vector3 ISODEFAULTSCALE = Vector3.one, WORLDDEFAULTSCALE = new Vector3(0.7072f, 1.4143f, 1f);
    public enum TileMaterial { WATER, GRASS, ROCK, BLANK, EMPTY };
    public enum IsometricDirections { UP, UPRIGHT, RIGHT, DOWNRIGHT, DOWN, DOWNLEFT, LEFT, UPLEFT, NONE };

    public static Vector2 IsometricDirectionToPortion(Utils.IsometricDirections _direction) {
        if (_direction == Utils.IsometricDirections.UP) return new Vector2(67.5f, 112.5f);
        if (_direction == Utils.IsometricDirections.UPRIGHT) return new Vector2(112.5f, 157.5f);
        if (_direction == Utils.IsometricDirections.RIGHT) return new Vector2(157.5f, 202.5f);
        if (_direction == Utils.IsometricDirections.DOWNRIGHT) return new Vector2(202.5f, 247.5f);
        if (_direction == Utils.IsometricDirections.DOWN) return new Vector2(247.5f, 292.5f);
        if (_direction == Utils.IsometricDirections.DOWNLEFT) return new Vector2(292.5f, 337.5f);
        if (_direction == Utils.IsometricDirections.LEFT) return new Vector2(-22.5f, 22.5f);
        if (_direction == Utils.IsometricDirections.UPLEFT) return new Vector2(22.5f, 67.5f);
        return Vector2.zero;
    }

    public static Utils.IsometricDirections AngleToIsometricDirection(float _angle) {
        _angle = _angle >= 337.5f ? _angle - 360f : _angle;
        foreach (Utils.IsometricDirections dir in Enum.GetValues(typeof(Utils.IsometricDirections))) {
            Vector2 portion = IsometricDirectionToPortion(dir);
            if (_angle >= portion.x && _angle < portion.y) return dir;
        }
        return Utils.IsometricDirections.NONE;
    }



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

