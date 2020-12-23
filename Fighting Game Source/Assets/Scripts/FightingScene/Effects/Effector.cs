using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitEffects
{
    HardHitEffect,
    SoftHitEffect
}

public class Effector : MonoBehaviour
{
    public static readonly string HitEffectsPath = "HitEfects/";
    public static void DoHitEffect(HitEffects effect, Vector3 position, Vector3 direction)
    {
        string effectName = effect.ToString();

        Quaternion rotation = Quaternion.identity;
        if (direction != Vector3.zero) rotation = Quaternion.LookRotation(direction);

        GameObject o = Instantiate(Resources.Load(Effector.HitEffectsPath + effectName) as GameObject, position, rotation);
        ActionTimer.Create(o, () => Destroy(o), o.GetComponent<ParticleSystem>().main.duration);
    }
}