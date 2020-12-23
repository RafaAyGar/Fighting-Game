using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator
{
    Transform _transform;
    private FighterSide _currentSideFacing;
    public FighterSide currentSideFacing
    {
        get => _currentSideFacing;
        set
        {
            _currentSideFacing = value;
            if (_currentSideFacing == FighterSide.right)
            {
                _transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                _transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    public Rotator(Transform transform, FighterSide initialSideFacing)
    {
        _transform = transform;
        SetInitialSideFacing(initialSideFacing);
    }

    void SetInitialSideFacing(FighterSide initialSideFacing)
    {
        if (initialSideFacing.Equals(FighterSide.right))
        {
            currentSideFacing = FighterSide.left;
        }
        else
        {
            currentSideFacing = FighterSide.right;
        }
    }
}
