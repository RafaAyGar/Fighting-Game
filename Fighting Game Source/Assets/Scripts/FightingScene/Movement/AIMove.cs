using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour, IMove
{
    FighterController fighterController;
    Rigidbody2D rb;
    Transform enemyTransform;
    Rotator rotator;
    private void Awake()
    {
        fighterController = GetComponent<FighterController>();
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Start()
    {
        rotator = new Rotator(transform, fighterController.side);
        enemyTransform = GetEnemyTransform();
    }

    public void MoveInXAxis(float speed)
    {
        rb.velocity = new Vector2(2, rb.velocity.y);
        RotateDependingOnXAxisVelocity();
    }

    void RotateDependingOnXAxisVelocity()
    {
        if (rb.velocity.x > 0) rotator.currentSideFacing = FighterSide.right;
        else if (rb.velocity.x < 0) rotator.currentSideFacing = FighterSide.left;
    }

    public void Jump(float jumpForce)
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }

    public bool MoveRequested()
    {
        return true;
    }

    Transform GetEnemyTransform()
    {
        FighterController[] fighters = FindObjectsOfType<FighterController>();
        foreach (FighterController fc in fighters)
        {
            if(fc.transform.name != transform.name)
            {
                return fc.transform;
            }
        }
        return null;
    }

    public bool JumpRequested()
    {
        return false;
    }

    public bool BlockRequested()
    {
        return false;
    }
}
