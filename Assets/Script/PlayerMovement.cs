using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float velocity = 80f;
    new SpriteRenderer renderer;
    CharacterController controller;
    Vector3 direction;

    void Awake() {
        renderer = this.GetComponentInChildren<SpriteRenderer>();
        controller = this.GetComponent<CharacterController>();
    }
    void FixedUpdate() {
        direction = CustomInputManager.GetDirection().XYtoXZ();
        direction = Quaternion.Euler(0, -45, 0) * direction;
        controller.SimpleMove(direction * velocity * Time.deltaTime);

    }
}
