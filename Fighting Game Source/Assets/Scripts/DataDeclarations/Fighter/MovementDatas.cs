using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MovementDatas", menuName = "FighterDatas/MovementDatas")]
public class MovementDatas : ScriptableObject
{
    public float speed, jumpForce, blockTime, onAirSpeedDivisor;
}
