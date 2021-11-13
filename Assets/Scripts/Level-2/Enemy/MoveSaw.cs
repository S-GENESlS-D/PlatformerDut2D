using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSaw : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private GameObject sawHorizontal;

    private Health health;

    private SpriteRenderer spriteRenderer;

    public GameObject startPosHorizontal;

    public GameObject endPosHorizontal;

    private Vector3 _startPosHorizontal;

    private Vector3 _endPosHorizontal;

    private int _damage = 25;

    private float _lastDamageTime;

    [SerializeField] private TMP_Text killedUI;



    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _startPosHorizontal = startPosHorizontal.transform.position;
        _endPosHorizontal = endPosHorizontal.transform.position;
        StartCoroutine(nameof(Move));

    }

    IEnumerator Move()
    {
        while (true)
        {
            while (sawHorizontal.transform.position.x <= _endPosHorizontal.x)
            {
                spriteRenderer.flipX = false;
                transform.Translate(new Vector2(1, 0) * Time.deltaTime);
                yield return transform.position;
            }
            while (sawHorizontal.transform.position.x >= _startPosHorizontal.x)
            {
                spriteRenderer.flipX = true;
                transform.Translate(new Vector2(-1, 0) * Time.deltaTime);
                yield return transform.position;
            }
        }
    }

    



    private void OnCollisionStay2D(Collision2D collision)
    {
        animator = collision.gameObject.GetComponent<Animator>();
        health = collision.gameObject.GetComponent<Health>();
        if (health != null && Time.time - _lastDamageTime > 1f && animator != null)
        {
            _lastDamageTime = Time.time;
            animator.SetBool("isDamage", true);
            health.HealthComponent -= _damage;
            if (health.HealthComponent <= 0)
            {
                killedUI.gameObject.SetActive(true);
                Destroy(collision.gameObject);
                Invoke(nameof(ReloadScene),3f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator = collision.gameObject.GetComponent<Animator>();
        if(animator != null)
        {
            animator.SetBool("isDamage", false);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
