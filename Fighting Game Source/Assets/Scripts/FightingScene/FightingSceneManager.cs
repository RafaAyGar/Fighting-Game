using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingSceneManager : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.SpawnPlayers();       
    }
}
