using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputInfo", menuName = "FighterDatas/InputInfo")]
public class InputInfo : ScriptableObject
{
    public KeyCode goRightKey, goLeftKey;

    public bool MoveToLeftRequested()
    {
        return Input.GetKeyDown(goLeftKey) || !Input.GetKey(goRightKey);
    }

    public bool MoveToRightRequested()
    {
        return Input.GetKeyDown(goRightKey) || !Input.GetKey(goLeftKey);
    }

    public bool InputPulsed()
    {
        return (Input.GetKey(goRightKey) || Input.GetKey(goLeftKey));
    }
}