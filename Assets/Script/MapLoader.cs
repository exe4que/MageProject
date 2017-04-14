using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour {

    public Map map;
    [Range(0,5)]
    public float tileSpacing = 1f;
    

    private const float yTileSpacingRelation = 0.5f;
    private Vector3 toIsometric = new Vector3(-0.5f,0.5f,1);
    private GameObject father;

    void Awake() {
        father = new GameObject(map.name);
        for (int i = 0; i < map.mapGrid.Length; i++) {
            Pair gridPos = Utils.Index1to2(i,map.size.x);
            GameObject tile = new GameObject(i + " - (" +gridPos.x + ", " + gridPos.y + ")");
            tile.tag = "Tile";
            tile.transform.SetParent(father.transform);
            float x = (gridPos.x * tileSpacing) + (gridPos.y * tileSpacing);
            float y = (gridPos.x * ((-tileSpacing) * 0.5f)) + (gridPos.y * (tileSpacing * 0.5f));
            Vector3 pos = new Vector3(x,y,y);
            tile.transform.position = pos;
            SpriteRenderer renderer = tile.AddComponent<SpriteRenderer>();
            renderer.sprite = ResourcesManager.Instance.GetTile(map.mapGrid[i].material);
        }
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
