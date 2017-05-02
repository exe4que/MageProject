using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement_rotOnly : MonoBehaviour {
    Vector3 direction;
    new SpriteRenderer renderer;

    void Awake() {
        renderer = this.GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate () {
        direction = CustomInputManager.GetDirection().XYtoXZ();
        direction = Quaternion.Euler(0, -45, 0) * direction;
        this.transform.LookAt(transform.position + direction);
    }

    private void Update() {
        //Debug.Log(Utils.AngleToIsometricDirection(CustomInputManager.GetAngleDirection()));
        if (CustomInputManager.GetButtonUp("AButton")) {
            this.renderer.material.color = Color.green;
            this.renderer.color = Color.green;
        }
        if (CustomInputManager.GetButtonUp("BButton")) {
            this.renderer.material.color = Color.red;
            this.renderer.color = Color.red;
        }
        if (CustomInputManager.GetButtonUp("XButton")) {
            this.renderer.material.color = Color.blue;
            this.renderer.color = Color.blue;
        }
    }
}
