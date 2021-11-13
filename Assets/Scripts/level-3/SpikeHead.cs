using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    private Health _health;

    [SerializeField] private float _walkRange;

    [SerializeField] private bool _faceRight;

    [SerializeField] private float _speed;

    private Rigidbody2D _rb;

    private int _damage = 25;

    private int _direction = 1;

    private float _lastAttakTime;

    private Vector2 _startPos;
    private Vector2 _drawPos
    {
        get
        {
            if (_startPos == Vector2.zero)
            {
                return transform.position;
            }
            else
                return _startPos;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_drawPos, new Vector3(1, _walkRange, 0));
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
    }
    private void Update()
    {
        if (_faceRight && transform.position.y > _startPos.y + _walkRange)
        {
            Flip();
        }
        else if (!_faceRight && transform.position.y < _startPos.y - _walkRange)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        _rb.velocity = Vector2.up * _direction * _speed;
    }

    void Flip()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0, 180, 0);
        _direction *= -1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _health = collision.gameObject.GetComponent<Health>();

        if (_health != null && Time.time - _lastAttakTime > 1f)
        {
            _lastAttakTime = Time.time;
            _health.HealthComponent -= _damage;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _health = null;
    }
}
