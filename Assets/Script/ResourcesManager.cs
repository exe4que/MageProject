using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ResourcesManager : MonoBehaviour {

    #region SINGLETON_PATERN
    protected static ResourcesManager instance;

    /**
       Returns the instance of this singleton.
    */
    public static ResourcesManager Instance {
        get {
            if (instance == null) {
                instance = (ResourcesManager) FindObjectOfType(typeof(ResourcesManager));

                if (instance == null) {
                    Debug.LogError("An instance of " + typeof(ResourcesManager) +
                       " is needed in the scene, but there is none.");
                }
            }

            return instance;
        }
    }
    #endregion
    public bool update;
    public TileMaterialMapping[] tileMaterials;
    public Dictionary<TileMaterialMapping, Utils.TileMaterial> tileMaterials2;

    public Sprite GetTile(Utils.TileMaterial _tileEnum) {
        foreach (TileMaterialMapping mapping in tileMaterials) {
            if (mapping.id == _tileEnum) {
                return mapping.sprite;
            }
        }
        return null;
    }

    public Sprite GetTile(Utils.TileMaterial _tileEnum, bool _isTop) {
        foreach (TileMaterialMapping mapping in tileMaterials) {
            if (mapping.id == _tileEnum) {
                if (_isTop) {
                    if (mapping.spriteTop!=null) {
                        return mapping.spriteTop;
                    } else {
                        return mapping.sprite;
                    }
                } else {
                    return mapping.sprite;
                }
            }
        }
        return null;
    }

    private void OnValidate() {
        if (update) {
            Array enums = Enum.GetValues(typeof(Utils.TileMaterial));
            Array.Resize<TileMaterialMapping>(ref tileMaterials, enums.Length);
            for (int i = 0; i < enums.Length; i++) {
                if (tileMaterials[i] == null) tileMaterials[i] = new TileMaterialMapping();
                tileMaterials[i].id = (Utils.TileMaterial) i;
            }
            update = false;
        }
    }
}

[System.Serializable]
public class TileMaterialMapping {
    public Utils.TileMaterial id;
    public Sprite sprite;
    public Sprite spriteTop;

    public TileMaterialMapping() {
        this.id = Utils.TileMaterial.BLANK;
        this.sprite = null;
    }

    public TileMaterialMapping(Utils.TileMaterial _id, Sprite _sprite, Sprite _top) {
        this.id = _id;
        this.sprite = _sprite;
        this.spriteTop = _top;
    }
}
