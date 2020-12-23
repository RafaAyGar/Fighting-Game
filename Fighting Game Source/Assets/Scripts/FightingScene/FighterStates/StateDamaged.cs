using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDamaged : State
{
    float _timeToRecover;
    string inAnimatorStateName;
    public StateDamaged(FighterController fc, MovementDatas movDatas, float timeToRecover) : base(fc, movDatas)
    {
        _fighterController.fs = FighterState.damaged;
        inAnimatorStateName = "Damaged";
        _fighterController.animator.Play(inAnimatorStateName);

        _timeToRecover = timeToRecover;
    }

    public override void Update()
    {
        _timeToRecover -= Time.deltaTime;
        if(_timeToRecover <= 0)
        {
            if(_fighterController.fs != FighterState.dead)
            {
                _fighterController.currentState = new StateIdle(_fighterController, _movDatas);
            }
        }
    }
}
