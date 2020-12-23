using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AttackData", menuName = "FighterDatas/AttackData")]
public class AttackData : ScriptableObject
{
    [Tooltip("The name of the animator state. Make sure you link the animation you want to play to the state")]
    public string animation;
    [Tooltip("Max time the animation can lasts")]
    public float maxTime;
    [Tooltip("Moment when the animation hits the enemy")]
    public float hitMoment; //The animation time when the enemy is hit.
    [Tooltip("Range of the attack. Use AttackRangeReference component to calculate it in editor")]
    public float range;
    public float damage;
    [Tooltip("Time the beaten enemy is stunned")]
    public float targetRecoverTime;

    private void OnValidate()
    {
        if(maxTime < 0)
        {
            maxTime = 0;
            throw new System.Exception("Max Time must be bigger than 0");
        }
        else if(hitMoment > maxTime || hitMoment < 0)
        {
            hitMoment = 0;
            throw new System.Exception("Hit Moment must be bigger than 0 and lower than Max Time");
        }
        else if(range < 0)
        {
            range = 0;
            throw new System.Exception("Range must be bigger than 0");
        }
        else if(damage < 0)
        {
            damage = 0;
            throw new System.Exception("Damage must be bigger than 0");
        }
        else if(targetRecoverTime < 0)
        {
            targetRecoverTime = 0;
            throw new System.Exception("Target Recovery Time must be bigger than 0");
        }
    }
}
