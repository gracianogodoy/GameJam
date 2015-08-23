using UnityEngine;
using System.Collections;

public class CastRay
{
    public RaycastHit2D Cast(Vector2 origin, Vector2 direction, float distance, LayerMask mask)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance, mask);

        return hit;
    }
}
