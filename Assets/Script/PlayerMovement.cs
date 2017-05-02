using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float velocity = 80f;
    new SpriteRenderer renderer;
    Animator animator;
    CharacterController controller;
    Vector3 direction;

    Utils.IsometricDirections lastDirection = Utils.IsometricDirections.NONE;

    void Awake() {
        renderer = this.GetComponentInChildren<SpriteRenderer>();
        controller = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }
    void Update() {
        Utils.IsometricDirections current = Utils.AngleToIsometricDirection(CustomInputManager.GetAngleDirection());
        if (current != lastDirection) {
            animator.SetTrigger(current.ToString());
            lastDirection = current;
        }
    }
    void FixedUpdate() {
        direction = CustomInputManager.GetDirection().XYtoXZ();
        direction = Quaternion.Euler(0, -45, 0) * direction;
        controller.SimpleMove(direction * velocity * Time.deltaTime);

    }
}
