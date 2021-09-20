using PurpleCable;
using UnityEngine;

public class EnemyDeathPool : PrefabPool<EnemyDeath>
{
    public static EnemyDeathPool _current;

    protected override void Awake()
    {
        _current = this;

        base.Awake();
    }

    public static EnemyDeath GetEnemyDeath(Enemy enemy)
    {
        EnemyDeath enemyDeath = _current.GetItem();
        enemyDeath.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, -5);
        enemyDeath.SetDef(enemy.Def);

        return enemyDeath;
    }
}