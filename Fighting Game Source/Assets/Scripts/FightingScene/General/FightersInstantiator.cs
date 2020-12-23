using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightersInstantiator : MonoBehaviour
{
    public static void InstantiateFighterOnSide(Fighters fighter, bool isAI, FighterSide side)
    {
        GameObject fighterToInstantiate = FightersGetter.GetFighter(fighter);

        fighterToInstantiate.GetComponent<FighterController>().side = side;
        fighterToInstantiate.GetComponent<FighterController>().isAI = isAI;
        SetPositionDependingOnSide(fighterToInstantiate.transform, side);

        Instantiate(fighterToInstantiate);
    }

    private static void SetPositionDependingOnSide(Transform transform, FighterSide side)
    {
        float xPos;
        if(side.Equals(FighterSide.right))
        {
            xPos = 1f;
        }
        else
        {
            xPos = -1f;
        }

        transform.position = new Vector3(xPos, 0, 0);
    }
}
