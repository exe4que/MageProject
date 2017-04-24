using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomInputManager : MonoBehaviour {

    public bool isVirtual = false;
    public static bool _isVirtual = false;
    public VirtualJoystick _virtualJoystick;
    public static VirtualJoystick virtualJoystick;
    private static Vector3 inputDirection { get; set; }
    public ButtonBehaviour[] _virtualButtons;
    private static ButtonBehaviour[] buttons;
    //private ScrollRect aSwipe, bSwipe, xSwipe, ySwipe;

    void Awake() {
        _isVirtual = isVirtual;
        //virtualJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<VirtualJoystick>();
        //aButton = GameObject.FindGameObjectWithTag("AButton").GetComponent<Button>();
        //aSwipe = GameObject.FindGameObjectWithTag("AButton").GetComponent<ScrollRect>();
        virtualJoystick = _virtualJoystick;
        buttons = _virtualButtons;
        if(virtualJoystick==null) Debug.Log("Virtual joystick not assigned in input manager");
        NullCheck();
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
        if (_isVirtual) {
            ButtonBehaviour btn = ButtonByName(_buttonName);
            if (btn == null) return false;
            else return btn.GetButtonUp();
        } else return Input.GetButtonUp(_buttonName);
    }

    public static bool GetButtonDown(string _buttonName) {
        if (_isVirtual) {
            ButtonBehaviour btn = ButtonByName(_buttonName);
            if (btn == null) return false;
            else return btn.GetButtonDown();
        } else return Input.GetButtonDown(_buttonName);
    }

    public static bool GetButton(string _buttonName) {
        if (_isVirtual) {
            ButtonBehaviour btn = ButtonByName(_buttonName);
            if (btn == null) return false;
            else return btn.GetButton();
        } else return Input.GetButton(_buttonName);
    }

    private static ButtonBehaviour ButtonByName(string _name) {
        foreach (ButtonBehaviour btn in buttons) {
            if (btn != null && btn.name.Equals(_name)) {
                return btn;
            }
        }
        return null;
    }

    private void NullCheck() {
        foreach (ButtonBehaviour btn in buttons) {
            if (btn == null) Debug.Log("Virtual button not assigned in input manager");
        }
    }
}