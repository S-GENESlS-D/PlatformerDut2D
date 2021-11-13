using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletCharacter : MonoBehaviour
{
    private int _damage = 10;

    private float _timeLastAttak;

    private HealthEnemy _health;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _health = collision.gameObject.GetComponent<HealthEnemy>();
        if (_health != null)
        {
            _health.HealthComponent -= _damage;
            Destroy(this.gameObject);
            if (_health.HealthComponent <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            Invoke(nameof(Destroyer), 8f);

        }
    }
    private void Destroyer()
    {
        Destroy(gameObject);
    }

}
