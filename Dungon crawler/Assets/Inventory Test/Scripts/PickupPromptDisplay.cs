using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupPromptDisplay : MonoBehaviour
{
    public TextMeshProUGUI buttonText;

    public void SetText(GroundItem _item)
    {
        buttonText.SetText("Pick up " + _item.item.name + "?");
    }
}
