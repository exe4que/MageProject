using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float velocity = 80f;
    Animator animator;
    CharacterController controller;
    Vector3 direction;

    Utils.IsometricDirections lastDirection = Utils.IsometricDirections.NONE;

    void Awake() {
        controller = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }
    void Update() {
        Utils.IsometricDirections current = Utils.AngleToIsometricDirection(CustomInputManager.GetAngleDirection());
        if (current != lastDirection) {
            if (current== Utils.IsometricDirections.NONE) {
                //animator.SetTrigger(lastDirection.ToString());
                //animator.SetTrigger("STANDING");
                animator.Play("STANDING-" + lastDirection.ToString(),0);
            } else {
                AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
                animator.Play("WALKING-" + current.ToString(), 0, info.normalizedTime);
                //animator.SetFloat("CycleOffset", info.normalizedTime - (int) info.normalizedTime);
                //animator.SetTrigger(current.ToString());
                //animator.SetTrigger("WALKING");
            }
            lastDirection = current;
        }
    }
    void FixedUpdate() {
        direction = CustomInputManager.GetDirection().XYtoXZ();
        direction = Quaternion.Euler(0, -45, 0) * direction;
        controller.SimpleMove(direction * velocity * Time.deltaTime);

    }
}
