using PurpleCable;
using UnityEngine;

public class MoveLeftAndPool : MoveToLimit
{
    protected override Vector3 Direction => Vector3.left;

    private const float _Speed = 3.5f;
    protected override float Speed => (Input.GetAxisRaw("Horizontal") > 0 ? _Speed * 1.5f : _Speed);

    protected override bool IsAtLimit()
    {
        return transform.position.x < -10;
    }

    protected override void OnLimitReached()
    {
        IPoolable poolable = GetComponent<IPoolable>();
        if (poolable != null)
            poolable.SetAsAvailable();
        else
            gameObject.SetActive(false);
    }
}
