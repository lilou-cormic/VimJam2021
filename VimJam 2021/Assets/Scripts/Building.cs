using PurpleCable;
using UnityEngine;

public class Building : PoolableMonoBehaviour
{
    [SerializeField] BoxCollider2D Collider = null;

    [SerializeField] Transform EnemySpawnPointLeft = null;

    [SerializeField] Transform EnemySpawnPointRight = null;

    public float Width => Collider.size.x;

    public float Height => Collider.size.y;

    public Vector3 GetEnemySpawnPoint()
    {
        return Vector3.Lerp(EnemySpawnPointLeft.position, EnemySpawnPointRight.position, Random.value);
    }
}
