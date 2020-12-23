using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FighterState
{
    idle,
    running,
    jumping,
    damaged,
    damagedAir,
    blockingFloor,
    blockingAir,
    attacking,
    attackingAir,
    knockedDown,
    dead
}

public class FighterController : MonoBehaviour, IDamageable
{
    public FighterState fs;
    private IOnFloorChecker onFloorChecker;
    private IOnLimitChecker onLimitChecker;
    public IMove moveComponent;
    [HideInInspector] public FighterSide side;

    public bool isAI;
    public FighterBasicData info;
    public MovementDatas movDatas;
    public CombosData comboData;

    FighterUI fighterUI;
    [HideInInspector]
    public Animator animator;
    public Resource health, mana;
    public State currentState;
    public Combat combat;


    private void Awake()
    {
        fighterUI = GetComponent<FighterUI>();
        animator = GetComponent<Animator>();
        onFloorChecker = GetComponent<IOnFloorChecker>();
        onLimitChecker = GetComponent<IOnLimitChecker>();
    }
    private void Start()
    {
        InitializeIMoveComponent();

        health = new Resource(fighterUI.healthSlider, info.Health);
        //mana = new Resource(fighterUI.manaSlider, atributes.Mana);

        combat = new Combat(comboData.combas, comboData.basicAttacks, this);
        currentState = new StateIdle(this, movDatas);
    }

    void InitializeIMoveComponent()
    {
        if (isAI) moveComponent = gameObject.AddComponent(typeof(AIMove)) as AIMove;
        else moveComponent = GetComponent<IMove>();
    }

    private void Update()
    {
        currentState.Update();
        if(moveComponent.JumpRequested())
        {
            currentState.Jump();
        }
        else if (moveComponent.BlockRequested())
        {
            currentState.Block();
        }
    }
    public bool IsOnFloor()
    {
        return onFloorChecker.onFloor;
    }

    public bool IsOnLimit()
    {
        return onLimitChecker.collidingWithLimit;
    }

    public void Damage(float damage)
    {
        health.Consume(damage);
    }

    public bool IsDead()
    {
        bool isDead = false;
        if(health.value <= 0) isDead = true;
        return isDead;
    }

    public void Die()
    {
        DisableFighter();
        currentState = new StateDead(this, movDatas);
    }

    public void DisableFighter()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false; 
    }
}
