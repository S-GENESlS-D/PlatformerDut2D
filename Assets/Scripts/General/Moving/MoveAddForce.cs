using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAddForce : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField] private Collider2D collider2d;

    [SerializeField] private Transform _groundChecker;

    [SerializeField] private LayerMask _whatIsGround;

    private SpriteRenderer _spriteRenderer;

    private float _groundCheckerRadius = 0.1f;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        bool canJump = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);
        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            rigidbody2D.AddForce(new Vector2(-.3f, 0), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            rigidbody2D.AddForce(new Vector2(.3f, 0), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.Space) && canJump == true)
        {
            rigidbody2D.AddForce(new Vector2(0, 3f), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            collider2d.enabled = false;
        }
        else
            collider2d.enabled = true;
    }
}
   
   
