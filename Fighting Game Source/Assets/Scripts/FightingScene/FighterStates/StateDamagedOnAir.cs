using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDamagedOnAir : State
{
    float _timeToRecover;
    string inAnimatorStateName;
    public StateDamagedOnAir(FighterController fc, MovementDatas movData, float timeToRecover) : base(fc, movData)
    {
        _fighterController.fs = FighterState.damagedAir;
        inAnimatorStateName = "DamagedAir";
        _fighterController.animator.Play(inAnimatorStateName);

        _timeToRecover = timeToRecover;
    }

    public override void Update()
    {
        ChangeStateIfOnFloor();
        _timeToRecover -= Time.deltaTime;
        if(_timeToRecover <= 0 && !_fighterController.IsDead())
        {
            _fighterController.currentState = new StateJump(_fighterController, _movDatas);
        }
    }

    private void ChangeStateIfOnFloor()
    {
        if (_fighterController.IsOnFloor())
        {
            _fighterController.currentState = new StateKnockedDown(_fighterController, _movDatas);

        }
    }
}
