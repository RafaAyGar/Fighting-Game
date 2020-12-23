using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Attack
{

    #region Variable_Declaration
    public AttackData attackData;
        [Tooltip("Amount of time you have to wait to cancel the animation. " +
            "\n   When = 0 -> you can do next attack right after the hitTime" +
            "\n   When = 1 -> you have to wait the maxTime of the animation to start the next attack")]
        [Range(0, 1)]
        public float cancelTime;
        public HitEffects effect;
        public KeyCode input;
        public FighterState state;
        private bool hitOnce;
    #endregion

    public KeyCode getInput()
    {
        return input;
    }

    public float getHitTime()
    {
        if (attackData.maxTime < attackData.hitMoment) throw new System.Exception("In animation: " + attackData.animation + "Hit Time can't be bigger than Max Time");
        return (attackData.maxTime - attackData.hitMoment);
    }

    public float getMinTime()
    {
        float scaledCancelTime = Mathf.Lerp(attackData.hitMoment, attackData.maxTime, cancelTime);
        return (attackData.maxTime - (attackData.hitMoment + scaledCancelTime));
    }

    public float getMaxTime()
    {
        return attackData.maxTime;
    }

    public void DoAttack(Animator animator, Transform transform)
    {
        hitOnce = false;
        animator.Play(attackData.animation);
    }

    public void DoHit(Transform transform)
    {
        if(!hitOnce)
        {
            Collider2D fighterCollider = transform.GetComponent<Collider2D>();
            float xOffset = fighterCollider.bounds.extents.x;
            float yOffset = fighterCollider.bounds.extents.y;

            Vector2 attOriginOffset;

            if(transform.right.x == 1)
            {
              attOriginOffset = new Vector2(xOffset, yOffset);
            }
            else
            {
              attOriginOffset = new Vector2(-xOffset, yOffset);
            }

            hitOnce = true;

            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll((Vector2)transform.position + attOriginOffset, transform.right, attackData.range);
            foreach (RaycastHit2D hit in hits)
            {
                if (!hit.transform.name.Equals(transform.name))
                {
                    Effector.DoHitEffect(effect, hit.point, Vector3.left);
                    hit.transform.GetComponent<FighterController>().currentState.GoToDamagedState(transform, attackData.damage, attackData.targetRecoverTime);
                }
            }
            Debug.DrawLine((Vector2)transform.position + attOriginOffset, (Vector2)transform.position + attOriginOffset + new Vector2(attackData.range * transform.right.x, 0), Color.green, attackData.maxTime);
        }
    }
}
