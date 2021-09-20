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

    [SerializeField] AudioClip KickSound = null;

    private bool _isJumping = false;

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

        if (transform.position.y < -0.5f || transform.position.x < -0.5f)
        {
            _isDead = true;
            GameManager.GameOver();
            return;
        }

        Animator.SetFloat("speed", Input.GetAxis("Horizontal"));
        Animator.SetBool("jump", !GroundDetector.IsGrounded);

        if (Input.GetButtonDown("Fire1"))
        {
            Animator.SetTrigger("kick");

            KickSound.Play();
        }

        if (GroundDetector.IsGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Animator.SetBool("jump", true);

                _jumpTimer = 0f;

                _isJumping = true;

                return;
            }

            if (_isJumping)
            {
                _jumpTimer += Time.deltaTime;

                if (Input.GetButtonUp("Jump") || _jumpTimer >= 0.2f)
                {
                    JumpSound.Play();

                    rb.AddForce(Vector2.up * (_jumpTimer < 0.08f ? 3f : (_jumpTimer > 0.17f ? 6f : 5f)), ForceMode2D.Impulse);

                    _isJumping = false;
                }
            }
        }
    }
}
