using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : CharacterInput
{
    public override Vector2 movementInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
