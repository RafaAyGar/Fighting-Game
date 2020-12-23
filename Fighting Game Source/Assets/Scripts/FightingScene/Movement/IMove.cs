using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    void MoveInXAxis(float speed);
    void Jump(float jumpForce);
    bool MoveRequested();
    bool JumpRequested();
    bool BlockRequested();
}
