using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VirtualJoystickInput : CharacterInput
{
    public DynamicJoystick joystick;

    public override Vector2 movementInput()
    {
        return joystick.Direction;
    }
}
