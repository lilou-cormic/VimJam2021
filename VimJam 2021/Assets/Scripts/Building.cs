using PurpleCable;
using UnityEngine;

public class Building : PoolableMonoBehaviour
{
    [SerializeField] BoxCollider2D Collider = null;

    public float Width => Collider.size.x;

    public float Height => Collider.size.y;
}
