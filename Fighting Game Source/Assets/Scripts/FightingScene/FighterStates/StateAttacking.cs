using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttacking : State
{
    public StateAttacking(FighterController fc, MovementDatas movDatas) : base(fc, movDatas)
    {
        _fighterController.fs = FighterState.attacking;
        _fighterController.combat.onResetCombos += ComeBackToIdle;
    }

    public override void Update()
    {
        _fighterController.combat.HandleAttack();
    }

    void ComeBackToIdle()
    {
        _fighterController.currentState = new StateIdle(_fighterController, _movDatas);
        _fighterController.combat.onResetCombos -= ComeBackToIdle;
    }
}
