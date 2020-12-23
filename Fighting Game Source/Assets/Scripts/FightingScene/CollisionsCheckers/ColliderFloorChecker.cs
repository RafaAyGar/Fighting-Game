using UnityEngine;
using System.Collections;

public class ColliderFloorChecker : MonoBehaviour, IOnFloorChecker
{
    bool _onFloor;
    public bool onFloor => _onFloor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            _onFloor = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            _onFloor = false;
        }
    }
}