using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public int ManaComponent;

    [SerializeField] private Slider _enduranceBar;

    private float _lastManaTime;

    private void Start()
    {
        ManaComponent = 100;
        _enduranceBar.value = ManaComponent;
    }
    private void Update()
    {
        _enduranceBar.value = ManaComponent;

        if (ManaComponent < 100 && Time.time - _lastManaTime > 1)
        {
            _lastManaTime = Time.time;
            ManaComponent += 1;
        }
    }
}
