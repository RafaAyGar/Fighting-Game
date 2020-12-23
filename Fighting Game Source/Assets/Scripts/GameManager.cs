using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private string combatSceneName = "FightingScene";
    public CombatData combatData;

    public void GoToCombatScene()
    {
        SceneManager.LoadScene(combatSceneName);
    }

    public void SpawnPlayers()
    {
        FightersInstantiator.InstantiateFighterOnSide(combatData.fighter1, combatData.fighter1IsAI, FighterSide.left);
        FightersInstantiator.InstantiateFighterOnSide(combatData.fighter2, combatData.fighter2IsAI, FighterSide.right);
    }
}
