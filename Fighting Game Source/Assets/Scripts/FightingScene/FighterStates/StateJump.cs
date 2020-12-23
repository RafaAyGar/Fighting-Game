using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateJump : State
{
    bool checkFloorFlag;
    IMove moveComponent;
    Vector2 jumpVector;
    string inAnimatorStateName;

    public StateJump(FighterController fc, MovementDatas movDatas) : base(fc, movDatas)
    {
        _fighterController.fs = FighterState.jumping;
        inAnimatorStateName = "Jump";
        _fighterController.animator.Play(inAnimatorStateName);

        checkFloorFlag = false;
        moveComponent = fc.moveComponent;
        jumpVector = new Vector2(0, movDatas.jumpForce);
        WaitForSecondsToActiveCheckFloorFlag(0.3f);
    }

    public override void Update()
    {
        _fighterController.animator.Play(inAnimatorStateName);
        if(CheckAttack()) _rb.velocity = Vector3.zero;
        if(_fighterController.IsOnLimit() == false) moveComponent.MoveInXAxis(_movDatas.speed / _movDatas.onAirSpeedDivisor);
        if (checkFloorFlag) ChangeStateIfOnFloor();
    }

    public override void GoToDamagedState(Transform t, float damage, float timeToRecover)
    {
        _fighterController.currentState = new StateDamagedOnAir(_fighterController, _movDatas, timeToRecover);
        _fighterController.Damage(damage);
    }

    public override void Block()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        _fighterController.currentState = new StateBlockingOnAir(_fighterController, _movDatas);
    }

    protected override bool CheckAttack()
    {
        if (Input.anyKeyDown)
        {
            _fighterController.combat.HandleAttack();
            if (_fighterController.combat.currentAttackActive)
            {
                _fighterController.currentState = new StateAttackingOnAir(_fighterController, _movDatas);
                return true;
            }
        }
        return false;
    }

    private void ChangeStateIfOnFloor()
    {
        if (_fighterController.IsOnFloor())
        {
            _fighterController.currentState = new StateIdle(_fighterController, _movDatas);
        }
    }

    void WaitForSecondsToActiveCheckFloorFlag(float seconds)
    {
        ActionTimer.Create(_fighterController.gameObject, () => { checkFloorFlag = true; }, seconds);
    }
}
