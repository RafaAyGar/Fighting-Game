using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightersSelected : SelectionState
{
    public FightersSelected(FighterSelectManager manager, SelectionState lastState) : base(manager, lastState) { }

    public override void Back()
    {
        _manager.selectingSideText.SetText(FighterSide.right);
        _manager.DisableButton(_manager.startButton);
        _manager.EnableFighterSelectingButtons();
        base.Back();
    }
}
