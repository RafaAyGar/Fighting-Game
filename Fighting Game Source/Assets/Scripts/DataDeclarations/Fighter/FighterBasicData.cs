using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FighterBasicData", menuName = "FighterDatas/FighterBasicData")]
public class FighterBasicData : ScriptableObject
{
    [Header("Resources info")]
    public float Health;
    public float Mana;
    [Header("Basic Input Info")]
    public KeyCode jumpKey;
    public KeyCode blockKey;
}
