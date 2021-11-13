using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider hpBar;


    public int HealthComponent;

    private float _lastHealthTime;


    private void Start()
    {
        HealthComponent = 100;
        hpBar.value = HealthComponent;
    }
    private void Update()
    {
        hpBar.value = HealthComponent;

        if (HealthComponent < 100 && Time.time - _lastHealthTime > 1)
        {
            _lastHealthTime = Time.time;
            HealthComponent += 1;
        }
    }
}
