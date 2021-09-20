using PurpleCable;
using UnityEngine;

public class Enemy : PoolableMonoBehaviour
{
    [SerializeField] SpriteRenderer SpriteRenderer = null;

    [SerializeField] AudioClip DieSound = null;

    public EnemyDef Def { get; private set; }

    public void SetDef(EnemyDef def)
    {
        Def = def;

        SpriteRenderer.sprite = Def.Sprite;
    }

    public void Die()
    {
        DieSound.Play();

        ScoreManager.AddPoints(1);

        EnemyDeathPool.GetEnemyDeath(this);

        SetAsAvailable();
    }
}
