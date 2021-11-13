using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SawVertical : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private GameObject sawVertical;

    private Health health;

    private SpriteRenderer spriteRenderer;

    public GameObject startPosVertical;

    public GameObject endPosVertical;

    private Vector3 _startPosVertical;

    private Vector3 _endPosVertical;

    private int _damage = 25;

    private float _lastDamageTime;

    [SerializeField] private TMP_Text killedUI;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _startPosVertical = startPosVertical.transform.position;
        _endPosVertical = endPosVertical.transform.position;
        StartCoroutine(nameof(MoveVertical));

    }

    IEnumerator MoveVertical()
    {
        while (true)
        {
            while (sawVertical.transform.position.y >= _endPosVertical.y)
            {
                spriteRenderer.flipX = true;
                sawVertical.transform.Translate(new Vector2(0, -1) * Time.deltaTime);
                yield return transform.position;
               
            }
        
            while (sawVertical.transform.position.y <= _startPosVertical.y)
            {
                spriteRenderer.flipX = false;
                sawVertical.transform.Translate(new Vector2(0, 1) * Time.deltaTime);
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
                Invoke(nameof(ReloadScene), 3f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        animator = collision.gameObject.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("isDamage", false);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
