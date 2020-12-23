using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat
{
    #region Variable Declaration
    public float _attackTimer;
    public bool currentAttackActive, nextAttackRequested;
    private Attack nextAttack;
    private Attack currentAttack;
    private List<Combo> activeCombos;
    private FighterController fighterController;
    public Action onResetCombos;
    IEnumerable<Attack> ataquesBasicos;

    public List<Combo> combos;
    public List<Attack> basicAttacks;

    public float attackTimer { get => _attackTimer; }
    #endregion
    public Combat(List<Combo> combosP, List<Attack> basicAttacksP, FighterController fighterControllerRef)
    {
        activeCombos = new List<Combo>();
        _attackTimer = 0;

        combos = combosP;
        basicAttacks = basicAttacksP;
        fighterController = fighterControllerRef;

        ResetCombosHandler();
    }
    public void HandleAttack()
    {
        if(AttackTimerFinishedOrNotInitialized())
        {
            if (nextAttackRequested) DoAttack(nextAttack);
            else if (!currentAttackActive)
            {
                if (NewAttackAccepted())
                {
                    currentAttackActive = true;
                    InitializeActiveCombost();
                    DoAttack(currentAttack);
                }
            }
            else
            {
                currentAttackActive = false;
                ResetCombosHandler();
            }
        }
        else
        {
            _attackTimer -= Time.deltaTime;
            if (IsHitTime())
            {
                currentAttack.DoHit(fighterController.transform);
            }
            if (!nextAttackRequested && Input.anyKeyDown)
            {
                if (NextAttackAccepted()) nextAttackRequested = true;
            }
            if (nextAttackRequested && CanChainNextAttack())
            {
                DoAttack(nextAttack);
            }
        }
    }
    private bool NewAttackAccepted()
    {
        foreach (Attack att in basicAttacks)
        {
            if (InputAndStateMatchWithAttack(att.input, att.state))
            {
                currentAttack = att;
                return true;
            }
        }
        return false;
    }
    public bool NextAttackAccepted()
    {
        CheckCombFinish();
        bool attackAccepted = false;
        List<Combo> toRemove = new List<Combo>();

        foreach (Combo c in activeCombos)
        {
            Attack att = c.getAttackByPhase();
            if (InputAndStateMatchWithAttack(att.input, att.state))
            {
                nextAttack = c.getAttackByPhase();
                attackAccepted = true;
                c.risePhase();
            }
            else
            {
                toRemove.Add(c);
            }
        }
        foreach (Combo c in toRemove)
        {
            activeCombos.Remove(c);
        }
        return attackAccepted;
    }
    private void InitializeActiveCombost()
    {
        if (combos.Count <= 0) return;
        int currentAttackIndex = basicAttacks.IndexOf(currentAttack);
        foreach (Combo c in combos)
        {
            if (currentAttackIndex == c.basicAttackIndex)
            {
                activeCombos.Add(c);
            }
        }
    }

    #region General Combat Methods
    private bool IsHitTime()
    {
        return _attackTimer <= currentAttack.getHitTime();
    }
    private bool CanChainNextAttack()
    {
        return _attackTimer <= currentAttack.getMinTime();
    }
    private bool AttackTimerFinishedOrNotInitialized()
    {
        return attackTimer <= 0;
    }
    private void DoAttack(Attack att)
    {
        nextAttackRequested = false;
        currentAttack = att;
        _attackTimer = att.getMaxTime();
        att.DoAttack(fighterController.animator, fighterController.transform);
    }
    private void CheckCombFinish()
    {
        foreach (Combo c in combos)
        {
            if (c.getComboPhase() >= c.getNumberOfAttacks())
            {
                ResetCombosHandler();
            }
        }
    }
    public void ResetCombosHandler()
    {
        if (_attackTimer <= 0)
        {
            currentAttack = null;
            fighterController.animator.Play("Idle");
            onResetCombos?.Invoke();
        }
        nextAttack = null;
        activeCombos.Clear();
        foreach (Combo c in combos)
        {
            c.ResetCombo();
        }
    }
    private bool InputAndStateMatchWithAttack(KeyCode input, FighterState state)
    {
        return Input.GetKeyDown(input) && (fighterController.fs.Equals(state) || fighterController.fs.Equals(FighterState.attacking));
    }
    #endregion
}
