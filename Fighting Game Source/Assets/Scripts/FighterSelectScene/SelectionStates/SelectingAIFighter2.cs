using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingAIFighter2 : SelectionState
{
    public SelectingAIFighter2(FighterSelectManager manager, SelectionState lastState) : base(manager, lastState) { }

    public override void SelectFighter(Fighters fighter)
    {
        _manager.SetRightSideFighter(fighter, true);
        _manager.currentState = new FightersSelected(_manager, this);
        _manager.EnableButton(_manager.startButton);
    }

    public override void ChangeFighterType()
    {
        _manager.currentState = new SelectingPlayer2Fighter(_manager, _lastState);
    }

    public override void Back()
    {
        _manager.selectingSideText.SetText(FighterSide.left);
        base.Back();
    }
}
