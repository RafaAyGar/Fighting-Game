using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectionState
{
    protected FighterSelectManager _manager;
    protected SelectionState _lastState;

    public SelectionState(FighterSelectManager manager, SelectionState lastState)
    {
        _manager = manager;
        _lastState = lastState;
    }

    public virtual void SelectFighter(Fighters fighter) { return; }
    public virtual void ChangeFighterType() { return; }
    public virtual void Back()
    {
        if (_lastState != null)
        {
            _manager.currentState = _lastState;
        }
    }
}
