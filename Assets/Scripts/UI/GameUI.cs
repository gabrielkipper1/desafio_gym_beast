using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private CharacterController character;

    private Text stackText;
    private Text startText;


    void Start()
    {
        if (character == null)
        {
            character = FindFirstObjectByType<CharacterController>();
        }

        character.stack.OnStackUpdated.AddListener(OnStackUpdated);
    }

    private void OnStarUpdated(int starts)
    {
        startText.text = starts.ToString();
    }

    private void OnStackUpdated(int stack)
    {
        stackText.text = stack.ToString();
    }

    private void OnDisable()
    {
        character.stack.OnStackUpdated.RemoveListener(OnStackUpdated);
    }
}
