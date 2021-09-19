using PurpleCable;
using UnityEngine;

public class EnemyPool : PrefabPool<Enemy>
{
    private static EnemyPool _current;

    protected override void Awake()
    {
        base.Awake();

        _current = this;
    }

    public static Enemy GetEnemy(Vector2 position)
    {
        Enemy enemy = _current.GetItem();
        enemy.SetDef(EnemyDefCollection.GetEnemyDef());
        enemy.transform.position = position;

        return enemy;
    }
}
