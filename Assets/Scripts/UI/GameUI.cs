using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private CharacterController character;

    [SerializeField]
    private TextMeshProUGUI stackText;
    [SerializeField]
    private TextMeshProUGUI startText;

    void Start()
    {
        if (character == null)
        {
            character = FindFirstObjectByType<CharacterController>();
        }

        character.OnStackUpdated.AddListener(OnStackUpdated);
        character.OnStarsUpdated.AddListener(OnStarUpdated);

        OnStackUpdated(character.status.stackedAmount);
        OnStarUpdated(character.status.stars);
    }

    private void OnStarUpdated(int starts)
    {
        Debug.Log("Updating stars UI");
        startText.text = starts.ToString();
    }

    private void OnStackUpdated(int stackAmount)
    {
        Debug.Log("Updating stack UI");
        stackText.text = character.status.stackedAmount.ToString() + " / " + character.status.maxStack.ToString();
    }

    private void OnDisable()
    {
        character.OnStackUpdated.RemoveListener(OnStackUpdated);
        character.OnStarsAdded.RemoveListener(OnStarUpdated);
    }
}
