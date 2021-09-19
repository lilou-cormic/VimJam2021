using PurpleCable;
using UnityEngine;

public class Enemy : PoolableMonoBehaviour
{
    [SerializeField] SpriteRenderer SpriteRenderer = null;

    public EnemyDef Def { get; private set; }

    public void SetDef(EnemyDef def)
    {
        Def = def;

        SpriteRenderer.sprite = Def.Sprite;
    }
}
