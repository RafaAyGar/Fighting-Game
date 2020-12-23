using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CombatData", menuName = "GeneralData/CombatData")]
public class CombatData : ScriptableObject
{
    public Fighters fighter1, fighter2;
    public bool fighter1IsAI, fighter2IsAI;
}
