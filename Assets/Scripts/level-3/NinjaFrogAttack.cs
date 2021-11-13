using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NinjaFrogAttack : MonoBehaviour
{
    private Health health;

    private Animator animator;

    private float _lastDamageTime;

    private int _damage = 25;

    [SerializeField] private TMP_Text killedUI;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        health = collision.gameObject.GetComponent<Health>();
        if (health != null && Time.time - _lastDamageTime > 1.5f)
        {
            animator.SetBool("isHit", true);
            _lastDamageTime = Time.time;
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
            animator.SetBool("isHit", false);
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
