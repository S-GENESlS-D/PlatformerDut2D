using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thorns : MonoBehaviour
{
    private float _lastDamageTime;

    private int _damage = 25;

    private Health health;

    private Animator animator;

    [SerializeField] private TMP_Text killedUI;

    private void OnTriggerStay2D(Collider2D collision)
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
   
    private void OnTriggerExit2D(Collider2D collision)
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
