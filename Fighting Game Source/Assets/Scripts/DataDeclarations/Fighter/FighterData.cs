using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FighterData : ScriptableObject
{
    [Header("Resources info")]
    public float Health;
    public float Mana;
    [Header("Basic Input Info")]
    public KeyCode jumpKey;
    public KeyCode blockKey;
}
