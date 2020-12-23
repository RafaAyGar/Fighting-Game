using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEffector : MonoBehaviour
{
    void Start()
    {
        Effector.DoHitEffect(HitEffects.HardHitEffect, transform.position, transform.right);
    }
}
