using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attakRange;

    private Animator _animator;

    [SerializeField] private LayerMask _whatIsPlayer;

    [SerializeField] private GameObject _bullet;

    [SerializeField] private Transform _gun;

    private float _lastAttakTime;

    [SerializeField] private float _speed;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.clear;
        Gizmos.DrawCube(transform.position, new Vector3(_attakRange,1,0));
    }

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Collider2D player = Physics2D.OverlapBox(transform.position, new Vector2(_attakRange, 1), 0, _whatIsPlayer);

        if (player != null && Time.time - _lastAttakTime > 1.5f && player.transform.position.x > 0)
        {
            gameObject.transform.localScale = new Vector3(4, 4, 0);
            _animator.SetBool("isHitRock", true);
            _lastAttakTime = Time.time;
        }
        else if (player != null && Time.time - _lastAttakTime > 1f && player.transform.position.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-4, 4,0);
            _animator.SetBool("isHitRock", true);
            _lastAttakTime = Time.time;
        }
        else if (player == null)
        {
            _animator.SetBool("isHitRock", false);
        }
    }


    public void Shoot()
    {
        GameObject bullet =  Instantiate(_bullet, _gun.position, Quaternion.identity);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        if(gameObject.transform.localScale == new Vector3(4, 4, 0))
        {
            rbBullet.velocity = _speed * transform.right;
        }
        else if (gameObject.transform.localScale == new Vector3(-4, 4, 0))
        {
            rbBullet.velocity = -_speed * transform.right;
        }
    }

}
