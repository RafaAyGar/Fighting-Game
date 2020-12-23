using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Combo
{
    int comboPhase = 0;
    public string name;
    [Tooltip("Looking at the basic attacks list, the index of the basic you want to be the first attack in this combo")]
    public int basicAttackIndex;
    public List<Attack> comboAttacks;

    public bool isNextAttackInCombo(Attack att)
    {
        if(comboAttacks[comboPhase].getInput().Equals(att.getInput()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Attack getAttackByPhase()
    {
        return comboAttacks[comboPhase];
    }

    public void ResetCombo()
    {
        comboPhase = 0;
    }

    public int getComboPhase()
    {
        return comboPhase;
    }

    public void risePhase()
    {
        comboPhase++;
    }

    public int getNumberOfAttacks()
    {
        return comboAttacks.Count;
    }
}
