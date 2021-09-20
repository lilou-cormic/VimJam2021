using PurpleCable;
using UnityEngine;

public class EnemyDeath : PoolableMonoBehaviour
{
    private Rigidbody2D rb = null;
    private ScaleAnimation scaleAnimation = null;

    [SerializeField] SpriteRenderer SpriteRenderer = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        scaleAnimation = GetComponent<ScaleAnimation>();
    }

    private void OnEnable()
    {
        rb.AddForce(new Vector2(1, 1) * 3, ForceMode2D.Impulse);
        rb.AddTorque(-2f, ForceMode2D.Impulse);
        scaleAnimation.StartAnimation();
    }

    protected override void Init()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.transform.rotation = Quaternion.identity;
        scaleAnimation.ResetAnimation();
    }

    private void Update()
    {
        if (transform.position.y < -2)
            SetAsAvailable();
    }

    public void SetDef(EnemyDef def)
    {
        SpriteRenderer.sprite = def.Sprite;
    }
}
