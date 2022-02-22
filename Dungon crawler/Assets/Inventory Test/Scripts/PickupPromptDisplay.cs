using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupPromptDisplay : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public StringSO item;

    public void SetText()
    {
        buttonText.SetText("Pick up " + item.text + "?");
    }
}
