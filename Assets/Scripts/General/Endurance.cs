using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endurance : MonoBehaviour
{
    public int EnduranceComponent;

    [SerializeField] private Slider _enduranceBar;

    private float _lastEnduranceTime;

    private void Start()
    {
        EnduranceComponent = 100;
        _enduranceBar.value = EnduranceComponent;
    }
    private void Update()
    {
        _enduranceBar.value = EnduranceComponent;

        if(EnduranceComponent < 100 && Time.time - _lastEnduranceTime > 1)
        {
            _lastEnduranceTime = Time.time;
            EnduranceComponent += 1;
        }
    }
}
