using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInputManager : MonoBehaviour {

    public bool isVirtual = false;
    public static bool _isVirtual=false;
    public VirtualJoystick virtualJoystick;
    private static Vector3 inputDirection { get; set; }

    void Awake() {
        _isVirtual = isVirtual;
        virtualJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<VirtualJoystick>();
    }

    // Update is called once per frame
    void LateUpdate() {
        if (_isVirtual) {
            inputDirection = virtualJoystick.inputDirection;
        } else {
            Vector3 _PhysicalJoystick = new Vector3(Input.GetAxis("LeftJoystickHorizontal"), Input.GetAxis("LeftJoystickVertical"), 0);
            inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;
            inputDirection = _PhysicalJoystick;
        }
    }

    public static Vector3 GetDirection() {
        return inputDirection;
    }
    public static bool GetButtonUp(string _buttonName) {
        if (_isVirtual) return false;
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
