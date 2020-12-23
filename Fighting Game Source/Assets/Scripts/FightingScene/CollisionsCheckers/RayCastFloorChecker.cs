using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastFloorChecker : MonoBehaviour, IOnFloorChecker
{
    bool _onFloor;
    float rangeExtension;
    Collider2D fighterCollider;

    private void Awake()
    {
        fighterCollider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        rangeExtension = 0.05f;
    }

    public bool onFloor
    {
        get
        {
            Vector2 rayOrigin = (Vector2) fighterCollider.bounds.min + Vector2.down * rangeExtension; //Se introduce un offset de 0.2 para que no choque con su propio collider
            Debug.DrawLine(rayOrigin, rayOrigin + (Vector2.down * rangeExtension), Color.red, 5);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(rayOrigin, Vector2.down, rangeExtension);
            if(hit)
            {
                if(hit.transform.CompareTag("Floor")) return true;
            }
            return false;
        }
        set => _onFloor = value;
    }
}
