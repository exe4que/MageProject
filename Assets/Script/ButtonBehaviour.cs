using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour {

    public string buttonName;
    private bool isDown, isUp, isPressed, nd, nu;

    private void Update() {
        if (nd) nd = false;
        else isDown = false;
        if (nu) nu = false;
        else isUp = false;
    }

    public void PointerUp() {
        nu = true;
        isUp = true;
        isPressed = false;
    }

    public void PointerDown() {
        nd = true;
        isDown = true;
        isPressed = true;
    }

    public bool GetButtonDown() {
        return isDown;
    }

    public bool GetButtonUp() {
        return isUp;
    }

    public bool GetButton() {
        return isPressed;
    }
}
