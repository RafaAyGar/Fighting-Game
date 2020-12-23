using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBlockingOnFloor : State
{
    string inAnimatorStateName;
    public StateBlockingOnFloor(FighterController fc, MovementDatas movDatas) : base(fc, movDatas)
    {
        inAnimatorStateName = "Block";
        _fighterController.animator.Play(inAnimatorStateName);
        _fighterController.fs = FighterState.blockingFloor;
        ActionTimer.Create(_fighterController.gameObject, () => { _fighterController.currentState.FinishState(); }, movDatas.blockTime);
    }

    public override void FinishState()
    {
        _fighterController.currentState = new StateIdle(_fighterController, _movDatas);
    }

    public override void GoToDamagedState(Transform enemyTransform, float damage, float timeToRecover)
    {
        damage = 0; //Blocking doesn't consume enemy health.
        FinishState();
        enemyTransform.GetComponent<FighterController>().currentState.GoToDamagedState(_fighterController.transform, damage, timeToRecover);
    }
}
