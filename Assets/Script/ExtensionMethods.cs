﻿

using UnityEngine;

public static class ExtensionMethods {
    //Even though they are used like normal methods, extension
    //methods must be declared static. Notice that the first
    //parameter has the 'this' keyword followed by a Transform
    //variable. This variable denotes which class the extension
    //method becomes a part of.
    public static Vector3 XYtoXZ(this Vector3 _vector) {
        return new Vector3(_vector.x, _vector.z, _vector.y);
    }
}
