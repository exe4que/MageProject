using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour {

    public Map map;
    [Range(0, 5)]
    public float tileSpacing = 1f;


    private const float yTileSpacingRelation = 0.5f;
    private GameObject father;

    void Awake() {
        father = new GameObject(map.name);
        for (int i = 0; i < map.mapGrid.Length; i++) {
            for (int j = 0; j < map.mapGrid[i].height; j++) {
                DrawTile(i, j, map.mapGrid[i].height == j + 1);
            }
        }
    }

    private void DrawTile(int i, int j, bool isTop) {
        Sprite sprite = ResourcesManager.Instance.GetTile(map.mapGrid[i].material, isTop);
        if (sprite == null) {
            return;
        }
        General.Pair gridPos = Utils.Index1to2(i, map.size.x);
        GameObject tile = new GameObject(i + " - (" + gridPos.x + ", " + gridPos.y + ")" + "(" + j + ")");
        tile.tag = "Tile";
        tile.transform.SetParent(father.transform);
        tile.transform.position = Utils.ToWorldPos(gridPos, tileSpacing, j, map.unitHeight);
        BoxCollider collider = tile.AddComponent<BoxCollider>();
        collider.size = new Vector3(1, map.unitHeight, 1);
        collider.center = new Vector3(0.5f, -(map.unitHeight/2f), 0.5f);

        GameObject tileChild = new GameObject("SpriteContainer");
        tileChild.transform.position = tile.transform.position;
        tileChild.transform.SetParent(tile.transform);
        tileChild.transform.localRotation = Utils.WORLDDEFAULTROTATION;
        tileChild.transform.localScale = Utils.WORLDDEFAULTSCALE;
        SpriteRenderer renderer = tileChild.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
    }
}
