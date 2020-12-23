using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRunning : State
{
    IMove moveComponent;
    Vector2 jumpVector;
    string inAnimatorStateName;

    public StateRunning(FighterController fc, MovementDatas movDatas) : base(fc, movDatas)
    {
        _fighterController.fs = FighterState.running;
        inAnimatorStateName = "Run";
        _fighterController.animator.Play(inAnimatorStateName);

        moveComponent = _fighterController.moveComponent;
        jumpVector = new Vector2(0, movDatas.jumpForce);
    }

    public override void Jump()
    {
        moveComponent.Jump(_movDatas.jumpForce);
        _fighterController.currentState = new StateJump(_fighterController, _movDatas);
    }

    public override void Block()
    {
        _rb.velocity = Vector2.zero;
        _fighterController.currentState = new StateBlockingOnFloor(_fighterController, _movDatas);
    }

    public override void Update()
    {
        CheckAttack();
        moveComponent.MoveInXAxis(_movDatas.speed);
        if (_rb.velocity.x == 0) _fighterController.currentState = new StateIdle(_fighterController, _movDatas);
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
}
