﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[System.Serializable]
public class Map : MonoBehaviour {
    public General.Pair size;
    [Range(0,5)]
    public float unitHeight = 0.5f;
    public Cell[] mapGrid;
    
    private General.Pair last;

    void OnValidate() {
        if (size.sqrMagnitude != last.sqrMagnitude) {
            Array.Resize<Cell>(ref mapGrid,size.sqrMagnitude);
            last = size;
        }
    }
}
