using UnityEngine;

[System.Serializable]
public class Cell {
    public Utils.TileMaterial material=Utils.TileMaterial.GRASS;
    [Range(0,10)]
    public int height=1;
}
