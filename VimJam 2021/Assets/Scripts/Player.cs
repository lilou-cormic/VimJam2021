using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Rigidbody2D rb = null;

    private Animator Animator = null;

    [SerializeField] SpriteRenderer SpriteRenderer = null;

    [SerializeField] GroundDetector GroundDetector = null;

    [SerializeField] AudioClip JumpSound = null;

    private float _jumpTimer = 0f;

    private bool _isDead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isDead || GameManager.IsGamePaused)
            return;

        if (transform.position.y < 0)
        {
            _isDead = true;
            GameManager.GameOver();
            return;
        }

        Animator.SetFloat("speed", 1);
        Animator.SetBool("jump", !GroundDetector.IsGrounded);

        if (GroundDetector.IsGrounded)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // TODO kick
            }

            // TODO Jump timer

            if (Input.GetButtonDown("Jump"))
            {
                JumpSound.Play();

                Animator.SetBool("jump", true);

                rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
            }
        }
    }
}