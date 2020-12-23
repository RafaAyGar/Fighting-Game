using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingPlayer1Fighter : SelectionState
{
    public SelectingPlayer1Fighter(FighterSelectManager manager, SelectionState lastState) : base(manager, lastState) { }

    public override void SelectFighter(Fighters fighter)
    {
        _manager.selectingSideText.SetText(FighterSide.right);
        _manager.SetLeftSideFighter(fighter, false);
        _manager.currentState = new SelectingPlayer2Fighter(_manager, this);
    }

    public override void ChangeFighterType()
    {
        _manager.currentState = new SelectingAIFighter1(_manager, _lastState);
    }
}
