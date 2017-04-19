using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {

    SpriteRenderer renderer;
    void Awake() {
        renderer = this.GetComponent<SpriteRenderer>();
    }
	void FixedUpdate () {
        this.transform.position = this.transform.position + CustomInputManager.GetDirection();
        //Debug.Log(CustomInputManager.Instance.inputDirection);

        if (CustomInputManager.GetButtonUp("AButton")) {
            this.renderer.color = Color.green;
        }
        if (CustomInputManager.GetButtonUp("BButton")) {
            this.renderer.color = Color.red;
        }
        if (CustomInputManager.GetButtonUp("XButton")) {
            this.renderer.color = Color.blue;
        }
    }
}
