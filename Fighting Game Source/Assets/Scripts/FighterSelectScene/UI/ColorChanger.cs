using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    Button buttonRef;
    public bool interactable;

    private void Awake()
    {
        buttonRef = GetComponent<Button>();
        interactable = buttonRef.interactable;
    }

    private void Update()
    {
        if(interactable != buttonRef.interactable)
        {
            interactable = buttonRef.interactable;
            ColorBlock buttonColors = buttonRef.colors;
            if(interactable)
            {
                buttonColors.normalColor = Color.white;
            }
            else
            {
                buttonColors.normalColor = Color.gray;
            }
        }
    }
}
