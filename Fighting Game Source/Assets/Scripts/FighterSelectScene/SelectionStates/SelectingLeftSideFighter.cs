using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingLeftSideFighter : SelectionState
{
    public SelectingLeftSideFighter(FighterSelectManager manager, SelectionState lastState) : base(manager, lastState) { }

    public override void SelectFighter(Fighters fighter)
    {
        _manager.selectingSideText.SetText(FighterSide.right);
        _manager.SetLeftSideFighter(fighter, _manager.isAIButton.isAI);
        _manager.currentState = new SelectingRightSideFighter(_manager, this);
    }
}
