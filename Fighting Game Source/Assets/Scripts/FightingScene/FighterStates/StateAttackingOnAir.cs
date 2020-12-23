using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttackingOnAir : State
{
    public StateAttackingOnAir(FighterController fc, MovementDatas movDatas) : base(fc, movDatas)
    {
        _fighterController.fs = FighterState.attackingAir;
    }

    public override void Update()
    {
        _fighterController.combat.HandleAttack();
        ChangeStateIfOnFloor();
    }

    public override void GoToDamagedState(Transform t, float damage, float timeToRecover)
    {
        _fighterController.currentState = new StateDamagedOnAir(_fighterController, _movDatas, timeToRecover);
        _fighterController.Damage(damage);
    }

    void ComeBackToIdle()
    {
            _fighterController.currentState = new StateIdle(_fighterController, _movDatas);
    }

    void ChangeStateIfOnFloor()
    {
        if (_fighterController.IsOnFloor())
        {
            ComeBackToIdle();
        }
    }

}
