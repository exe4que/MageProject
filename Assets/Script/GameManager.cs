using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum TileMaterial { Blank, Wood, Rock };

}

[System.Serializable]
public struct Pair
{
    public int x, y;
    public Pair(int[] xy)
    {
        x = xy[0];
        y = xy[1];
    }

    public int sqrMagnitude
    {
        get { return x * y; }
    }
}

namespace General
{
    public static class ArrayUtils {
        public static void FillArray(ref Object[] _array, ref Object[] _arrayToFillWith) {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_arrayToFillWith.Length - 1 >= i) break;
                _array[i] = _arrayToFillWith[i];
            }
        }
    }
    
}

