using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected FighterController _fighterController;
    protected MovementDatas _movDatas;
    protected Rigidbody2D _rb;

    public State(FighterController fighterController, MovementDatas movDatas)
    {
        _fighterController = fighterController;
        _movDatas = movDatas;
        _rb = _fighterController.GetComponent<Rigidbody2D>();
    }
    protected virtual bool CheckAttack() { return false; }
    public virtual void Jump() { return; }
    public virtual void Block() { return; }
    public virtual void Update() { return; }
    public virtual void FinishState() { return; }
    public virtual void GoToDamagedState(Transform t, float damage, float timeToRecover) 
    {
        _fighterController.currentState = new StateDamaged(_fighterController, _movDatas, timeToRecover);
        _fighterController.Damage(damage);
        if (_fighterController.IsDead()) _fighterController.Die();
    }
}
