using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIdle : State
{
    Vector2 jumpVector;
    IMove moveComponent;
    string inAnimatorStateName;

    public StateIdle(FighterController fc, MovementDatas movDatas) : base(fc, movDatas)
    {
        _fighterController.fs = FighterState.idle;
        inAnimatorStateName = "Idle";
        _fighterController.animator.Play(inAnimatorStateName);

        moveComponent = _fighterController.moveComponent;
        _rb = _fighterController.transform.GetComponent<Rigidbody2D>();

        jumpVector = new Vector2(0, movDatas.jumpForce);
    }

    protected override bool CheckAttack()
    {
        _fighterController.combat.HandleAttack();
        if (_fighterController.combat.currentAttackActive)
        {
            _fighterController.currentState = new StateAttacking(_fighterController, _movDatas);
            return true;
        }
        return false;
    }

    public override void Jump()
    {
        moveComponent.Jump(_movDatas.jumpForce);
        _fighterController.currentState = new StateJump(_fighterController, _movDatas);
    }

    public override void Block()
    {
        _fighterController.currentState = new StateBlockingOnFloor(_fighterController, _movDatas);
    }

    public override void Update()
    {
        CheckAttack();
        ChangeToRunningIfMove();
    }

    void ChangeToRunningIfMove()
    {
        if (moveComponent.MoveRequested())
        {
            _fighterController.currentState = new StateRunning(_fighterController, _movDatas);
        }
    }
}