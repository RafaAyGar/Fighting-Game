using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingRightSideFighter : SelectionState
{
    public SelectingRightSideFighter(FighterSelectManager manager, SelectionState lastState) : base(manager, lastState) { }

    public override void SelectFighter(Fighters fighter)
    {
        _manager.selectingSideText.SetText(FighterSide.left);
        _manager.SetRightSideFighter(fighter, _manager.isAIButton.isAI);
        GoToFightersSelectedState();
        _manager.EnableButton(_manager.startButton);
        _manager.DisableFighterSelectingButtons();
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
