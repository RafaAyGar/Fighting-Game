using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnLimitChecker
{
    bool collidingWithLimit { get; }
}
