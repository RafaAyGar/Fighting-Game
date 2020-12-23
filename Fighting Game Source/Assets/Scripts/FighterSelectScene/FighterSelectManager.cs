using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterSelectManager : MonoBehaviour
{
    public static FighterSelectManager instance;
    private void Awake()
    {
        if(FighterSelectManager.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public SelectionState currentState;
    public SelectingFighterImage displayerFighterImage;
    public CombatData combatData;
    public Button pickButton;
    public Button startButton;
    public SelectingSideText selectingSideText;
    public IsAIButton isAIButton;


    private void Start()
    {
        currentState = new SelectingLeftSideFighter(this, null);

        selectingSideText.SetText(FighterSide.left);
        DisableButton(startButton);
        pickButton.onClick.AddListener(PickFighter);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            currentState.Back();
        }
    }

    void PickFighter()
    {
        currentState.SelectFighter(displayerFighterImage.GetFighterByCurrentImage());
    }
    public void SetLeftSideFighter(Fighters fighter, bool isAI)
    {
        combatData.fighter1 = fighter;
        combatData.fighter1IsAI = isAI;
    }
    public void SetRightSideFighter(Fighters fighter, bool isAI)
    {
        combatData.fighter2 = fighter;
        combatData.fighter2IsAI = isAI;
    }
    public void EnableButton(Button button)
    {
        button.interactable = true;
    }
    public void DisableButton(Button button)
    {
        button.interactable = false;
    }

    public void DisableFighterSelectingButtons()
    {
        DisableButton(displayerFighterImage.goLeft);
        DisableButton(displayerFighterImage.goRight);
        DisableButton(isAIButton.button);
        DisableButton(pickButton);
    }
    public void EnableFighterSelectingButtons()
    {
        EnableButton(displayerFighterImage.goLeft);
        EnableButton(displayerFighterImage.goRight);
        EnableButton(isAIButton.button);
        EnableButton(pickButton);
    }
}
