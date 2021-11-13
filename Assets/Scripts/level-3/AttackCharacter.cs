using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackCharacter : MonoBehaviour
{
    private Mana _mana;

    private Animator _animator;

    private MovingCharacter _character;

    private SpriteRenderer _spriteRenderer;

    private HealthEnemy _healthEnemy;

    [SerializeField] GameObject _gunRight;

    [SerializeField] GameObject _gunLeft;

    [SerializeField] GameObject _bullet;

    [SerializeField] private float _speed;

    private int _damage = 25;

    private float _lastAttakTime;

    private void Start()
    {
        _mana = GetComponent<Mana>();
        _animator = GetComponent<Animator>();
        _character = GetComponent<MovingCharacter>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - _lastAttakTime > 1f)
        {
            _lastAttakTime = Time.time;

            if (_spriteRenderer.flipX == true)
            {
                GameObject bul = Instantiate(_bullet, _gunLeft.transform.position, Quaternion.identity);
                Rigidbody2D _rb = bul.GetComponent<Rigidbody2D>();
                _rb.velocity = -_speed * transform.right;
                _mana.ManaComponent -= 5;

            }

            else if (_spriteRenderer.flipX == false)
            {
                GameObject bul = Instantiate(_bullet, _gunRight.transform.position, Quaternion.identity);
                Rigidbody2D _rb = bul.GetComponent<Rigidbody2D>();
                _rb.velocity = _speed * transform.right;
                _mana.ManaComponent -= 5;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _healthEnemy = collision.gameObject.GetComponent<HealthEnemy>();
        if (Input.GetMouseButton(1) && _healthEnemy != null && Time.time - _lastAttakTime > 1f)
        {
            _animator.SetBool("notRangeHit", true);
            _lastAttakTime = Time.time;
            _healthEnemy.HealthComponent -= _damage;
             if (_healthEnemy.HealthComponent <= 0)
             {
                 Destroy(collision.gameObject);
             }
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _animator.SetBool("notRangeHit", false);
    }

}
