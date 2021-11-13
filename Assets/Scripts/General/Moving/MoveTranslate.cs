using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTranslate : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Collider2D collider2d;

    [SerializeField] private Transform _groundChecker;

    [SerializeField] private LayerMask _whatIsGround;

    private float _groundCheckerRadius = 0.1f;

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        bool canJump = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-3, 0) * Time.deltaTime);
            _spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(3, 0) * Time.deltaTime);
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            
            collider2d.enabled = false;
        }
        else if (Input.GetKey(KeyCode.Space) && canJump)
        {
            transform.Translate(new Vector2(0, 3));
        }
        else
            collider2d.enabled = true;
    }
}
