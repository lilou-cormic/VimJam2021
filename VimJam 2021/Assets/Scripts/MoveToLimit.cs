using System;
using UnityEngine;

public abstract class MoveToLimit : MonoBehaviour
{
    protected abstract Vector3 Direction { get; }

    protected abstract float Speed { get; }

    private void Start()
    {
        InvokeRepeating(nameof(Move), 0.02f, 0.02f);
    }

    private void Update()
    {
        if (IsAtLimit())
            OnLimitReached();
    }

    private void Move()
    {
        if (!gameObject.activeSelf)
            return;

        transform.position += Direction * (float)Math.Round(0.02f * Speed, 3);
    }

    protected abstract bool IsAtLimit();

    protected abstract void OnLimitReached();
}
