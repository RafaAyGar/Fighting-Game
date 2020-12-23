using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLimitChecker : MonoBehaviour, IOnLimitChecker
{
    bool _collidingWithLimit;
    public bool collidingWithLimit => _collidingWithLimit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Limit"))
        {
            _collidingWithLimit = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Limit"))
        {
            _collidingWithLimit = false;
        }
    }
}
