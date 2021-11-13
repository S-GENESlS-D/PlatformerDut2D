using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpFruits : MonoBehaviour
{
    private int addedHp = 25;

    private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _health = collision.gameObject.GetComponent<Health>();
        if(_health != null &&_health.HealthComponent == 100)
        {
            return;
        }
        else if (_health != null && _health.HealthComponent < 100)
        {
            _health.HealthComponent += addedHp;
            this.addedHp = 0;
            Destroy(this.gameObject);
        }

    }
}
