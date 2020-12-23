using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeReference : MonoBehaviour
{
    public float range;
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void OnDrawGizmosSelected()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.right*range, Color.green);
    }
}
