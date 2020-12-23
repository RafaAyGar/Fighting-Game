using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBlockingOnAir : State
{
    string inAnimatorStateName;

    public StateBlockingOnAir(FighterController fc, MovementDatas movDatas) : base(fc, movDatas)
    {
        _fighterController.fs = FighterState.blockingAir;
        inAnimatorStateName = "BlockAir";
        _fighterController.animator.Play(inAnimatorStateName);
        ActionTimer.Create(_fighterController.gameObject, () => { _fighterController.currentState.FinishState(); }, movDatas.blockTime);
    }

    public override void Update()
    {
        ChangeStateIfOnFloor();
    }
    public override void GoToDamagedState(Transform t, float damage, float timeToRecover)
    {
        t.GetComponent<FighterController>().currentState.GoToDamagedState(_fighterController.transform, damage, timeToRecover);
        FinishState();
    }
    public override void FinishState()
    {
        if(!_fighterController.IsOnFloor())
        {
            _fighterController.currentState = new StateJump(_fighterController, _movDatas);
        }
    }
    private void ChangeStateIfOnFloor()
    {
        if (_fighterController.IsOnFloor())
        {
            _fighterController.currentState = new StateBlockingOnFloor(_fighterController, _movDatas);
        }
    }

}
