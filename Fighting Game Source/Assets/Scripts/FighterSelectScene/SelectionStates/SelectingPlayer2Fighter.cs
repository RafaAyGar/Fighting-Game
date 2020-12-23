using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingPlayer2Fighter : SelectionState
{
    public SelectingPlayer2Fighter(FighterSelectManager manager, SelectionState lastState) : base(manager, lastState) { }

    public override void SelectFighter(Fighters fighter)
    {
        _manager.SetRightSideFighter(fighter, false);
        GoToFightersSelectedState();
        _manager.EnableButton(_manager.startButton);
    }

    public override void ChangeFighterType()
    {
        _manager.currentState = new SelectingAIFighter2(_manager, _lastState);
    }

    void GoToFightersSelectedState()
    {
        _manager.currentState = new FightersSelected(_manager, this);
    }

    public override void Back()
    {
        _manager.selectingSideText.SetText(FighterSide.left);
        base.Back();
    }
}
