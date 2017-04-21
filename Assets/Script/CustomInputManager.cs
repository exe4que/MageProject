using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomInputManager : MonoBehaviour {

    public bool isVirtual = false;
    public static bool _isVirtual=false;
    public static VirtualJoystick virtualJoystick;
    private static Vector3 inputDirection { get; set; }
    private static Button aButton, bButton, xButton, yButton, selectButton, startButton;
    private ScrollRect aSwipe, bSwipe, xSwipe, ySwipe;

    void Awake() {
        _isVirtual = isVirtual;
        virtualJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<VirtualJoystick>();
        aButton = GameObject.FindGameObjectWithTag("AButton").GetComponent<Button>();
        aSwipe = GameObject.FindGameObjectWithTag("AButton").GetComponent<ScrollRect>();
    }

    public static Vector3 GetDirection() {
        if (_isVirtual) {
            inputDirection = virtualJoystick.inputDirection;
        } else {
            Vector3 _PhysicalJoystick = new Vector3(Input.GetAxis("LeftJoystickHorizontal"), Input.GetAxis("LeftJoystickVertical"), 0);
            inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;
            inputDirection = _PhysicalJoystick;
        }
        return inputDirection;
    }
    public static bool GetButtonUp(string _buttonName) {
        if (_isVirtual) return aButton.;
        else return Input.GetButtonUp(_buttonName);
    }

    public static bool GetButtonDown(string _buttonName) {
        if (_isVirtual) return false;
        else return Input.GetButtonDown(_buttonName);
    }

    public static bool GetButton(string _buttonName) {
        if (_isVirtual) return false;
        else return Input.GetButton(_buttonName);
    }

}
