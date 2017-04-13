using UnityEngine;

[System.Serializable]
public class Cell {
    public GameManager.TileMaterial material;
    [Range(1,10)]
    public int height=1;

}
