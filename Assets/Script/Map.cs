using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[System.Serializable]
public class Map : MonoBehaviour
{
    public Pair size;
    public Cell[] mapGrid;

    private Pair last;

    void OnValidate()
    {
        if (size.sqrMagnitude != last.sqrMagnitude)
        {
            Cell[] temp = new Cell[size.sqrMagnitude];
            General.ArrayUtils.FillArray(ref temp, ref mapGrid);
            mapGrid = new Cell[size.sqrMagnitude];
        }
    }
}
