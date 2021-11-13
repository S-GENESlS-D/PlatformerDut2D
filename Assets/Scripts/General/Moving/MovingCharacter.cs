using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Collider2D collider2d;

    [SerializeField] private Transform _groundChecker;

    [SerializeField] private LayerMask _whatIsGround;

    private float _groundCheckerRadius = 0.1f;

    private Endurance endurance;

    private float _lastEnduranceTime;



    private void Start()
    {
        endurance = GetComponent<Endurance>();
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        bool canJump = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);
        if (Input.GetKey(KeyCode.A))
        {
            if(endurance != null && Time.time - _lastEnduranceTime > .5f)
            {
                _lastEnduranceTime = Time.time;
                endurance.EnduranceComponent -= 1;
            }
            _rigidbody2D.velocity = new Vector2(-3, _rigidbody2D.velocity.y);
            _spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (endurance != null && Time.time - _lastEnduranceTime > .5f)
            {
                _lastEnduranceTime = Time.time;
                endurance.EnduranceComponent -= 1;
            }
            _rigidbody2D.velocity = new Vector2(3, _rigidbody2D.velocity.y);
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            if (endurance != null && Time.time - _lastEnduranceTime > .5f)
            {
                _lastEnduranceTime = Time.time;
                endurance.EnduranceComponent -= 3;
            }
            collider2d.enabled = false;
        }
        else if (Input.GetKey(KeyCode.Space) && canJump)
        {
            if (endurance != null && Time.time - _lastEnduranceTime > .5f)
            {
                _lastEnduranceTime = Time.time;
                endurance.EnduranceComponent -= 5;
            }
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 6);
        }
      
        else
            collider2d.enabled = true;
    }
}
