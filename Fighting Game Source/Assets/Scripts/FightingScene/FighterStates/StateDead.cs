using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDead : State
{
    string inAnimatorStateName;
    public StateDead(FighterController fighterController, MovementDatas movDatas) : base(fighterController, movDatas)
    {
        _fighterController.fs = FighterState.dead;
        inAnimatorStateName = "Dead";
        _fighterController.animator.Play(inAnimatorStateName);
    }

    public override void GoToDamagedState(Transform t, float damage, float timeToRecover)
    {
        return;
    }
}
