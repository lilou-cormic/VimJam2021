using PurpleCable;
using System;

public class EnemyDefCollection : ResourceCollection<EnemyDef>
{
    private static readonly Lazy<EnemyDefCollection> _Instance = new Lazy<EnemyDefCollection>(() => new EnemyDefCollection());
    private static EnemyDefCollection Instance => _Instance.Value;

    public EnemyDefCollection()
        : base("Enemies")
    { }

    public static EnemyDef GetEnemyDef()
    {
        return Instance.GetRandom();
    }
}
