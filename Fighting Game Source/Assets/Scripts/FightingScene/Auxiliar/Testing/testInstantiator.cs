using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInstantiator : MonoBehaviour
{
    void Start()
    {
        FightersInstantiator.InstantiateFighterOnSide(Fighters.Sakura, true, FighterSide.right);
        FightersInstantiator.InstantiateFighterOnSide(Fighters.Naruto, false, FighterSide.left);
    }
}
