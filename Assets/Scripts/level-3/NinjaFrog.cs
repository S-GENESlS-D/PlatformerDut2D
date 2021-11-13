using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFrog : MonoBehaviour
{
    [SerializeField] private float _walkRange;

    private Vector2 _startPos;

    [SerializeField] private bool _faceRight;

     private Rigidbody2D _rb;

    [SerializeField] private float _speed;

    private int _direction = 1;

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

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
    }

    private void Update()
    {
        if (_faceRight && transform.position.x > _startPos.x + _walkRange)
        {
            Flip();
        }
        else if(!_faceRight && transform.position.x < _startPos.x - _walkRange)
        {
            Flip();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_drawPos, new Vector3(_walkRange, 1, 0));
    }
    private void FixedUpdate()
    {
        _rb.velocity = Vector2.right * _direction * _speed;
    }

    void Flip()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0,180,0);
        _direction *= -1;
    }
}
