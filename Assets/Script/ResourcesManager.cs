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
    public TileMaterialMapping[] _tileMaterials;
    public Dictionary<Utils.TileMaterial, TileMaterialMapping> tileMaterials;

    //public DirectionalSpriteMapping[] _characterSprites;
    //public Dictionary<Utils.IsometricDirections, DirectionalSpriteMapping> characterSprites;



    void Awake() {
        tileMaterials = new Dictionary<Utils.TileMaterial, TileMaterialMapping>();
        for (int i = 0; i < _tileMaterials.Length; i++) {
            tileMaterials.Add(_tileMaterials[i].id, _tileMaterials[i]);
        }
        //characterSprites = new Dictionary<Utils.IsometricDirections, DirectionalSpriteMapping>();
        //for (int i = 0; i < _characterSprites.Length; i++) {
        //    characterSprites.Add(_characterSprites[i].id, _characterSprites[i]);
        //}
    }

    public Sprite GetTile(Utils.TileMaterial _tileEnum) {
        return tileMaterials[_tileEnum].sprite;
    }
    public Sprite GetTile(Utils.TileMaterial _tileEnum, bool _isTop) {
        return _isTop ? tileMaterials[_tileEnum].spriteTop : tileMaterials[_tileEnum].sprite;
    }

    private void OnValidate() {
        if (update) {
            ResizeTileMaterialMapping();
            update = false;
        }
    }

    private void ResizeTileMaterialMapping() {
        Array enums = Enum.GetValues(typeof(Utils.TileMaterial));
        Array.Resize<TileMaterialMapping>(ref _tileMaterials, enums.Length);
        for (int i = 0; i < _tileMaterials.Length; i++) {
            if (_tileMaterials[i] == null) _tileMaterials[i] = new TileMaterialMapping();
            _tileMaterials[i].id = (Utils.TileMaterial) i;
        }
    }

    private void ResizeDirectionalSpriteMapping(ref DirectionalSpriteMapping[] _mappingSet) {
        Array enums = Enum.GetValues(typeof(Utils.IsometricDirections));
        Array.Resize<DirectionalSpriteMapping>(ref _mappingSet, enums.Length);
        for (int i = 0; i < _mappingSet.Length; i++) {
            if (_mappingSet[i] == null) _mappingSet[i] = new DirectionalSpriteMapping();
            _mappingSet[i].id = (Utils.IsometricDirections) i;
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
}

[System.Serializable]
public class DirectionalSpriteMapping {
    public Utils.IsometricDirections id;
    public Sprite sprite;

    public DirectionalSpriteMapping() {
        this.id = Utils.IsometricDirections.NONE;
        this.sprite = null;
    }
}
