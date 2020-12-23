using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingAIFighter1 : SelectionState
{
    public SelectingAIFighter1(FighterSelectManager manager, SelectionState lastState) : base(manager, lastState) { }

    public override void SelectFighter(Fighters fighter)
    {
        _manager.selectingSideText.SetText(FighterSide.right);
        _manager.SetLeftSideFighter(fighter, true);
        _manager.currentState = new SelectingAIFighter2(_manager, this);
    }

    public override void ChangeFighterType()
    {
        _manager.currentState = new SelectingPlayer1Fighter(_manager, _lastState);
    }
}
