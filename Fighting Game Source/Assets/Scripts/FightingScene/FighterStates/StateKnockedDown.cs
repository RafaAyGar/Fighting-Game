using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateKnockedDown : State
{
    float timeKnocked;
    string inAnimatorStateName;
    Vector3 initialPos;
    public StateKnockedDown(FighterController fc, MovementDatas movDatas) : base(fc, movDatas)
    {
        _fighterController.fs = FighterState.knockedDown;
        inAnimatorStateName = "KnockedDown";
        _fighterController.animator.Play(inAnimatorStateName);

        initialPos = _fighterController.transform.position;
        timeKnocked = 1.5f;
        ActionTimer.Create(_fighterController.gameObject, () => GoToIdleStateOrDie(), timeKnocked);
    }

    public override void Update()
    {
        AvoidBeingPushed();
    }

    public override void GoToDamagedState(Transform t, float damage, float timeToRecover)
    {
        return;
    }

    void GoToIdleStateOrDie()
    {
        if (_fighterController.IsDead()) _fighterController.Die();
        else _fighterController.currentState = new StateIdle(_fighterController, _movDatas);
    }

    void AvoidBeingPushed()
    {
        _fighterController.transform.position = initialPos;
    }
}
