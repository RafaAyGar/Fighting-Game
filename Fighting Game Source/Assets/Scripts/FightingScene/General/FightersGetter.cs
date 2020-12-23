using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightersGetter : MonoBehaviour
{
    private static string fightersPath = "Fighters/";
    public static GameObject GetFighter(Fighters fighter)
    {
        GameObject fighterToReturn = Resources.Load(fightersPath + fighter.ToString()) as GameObject;

        return fighterToReturn;
    }
}
