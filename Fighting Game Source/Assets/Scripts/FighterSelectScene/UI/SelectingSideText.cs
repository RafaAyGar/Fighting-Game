using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectingSideText : MonoBehaviour
{
    Text selectingSideText;

    private void Awake()
    {
        selectingSideText = GetComponent<Text>();
    }

    public void SetText(FighterSide side)
    {
        selectingSideText.text = $"{side.ToString().ToUpper()} SIDE SELECTING";
    }
}
