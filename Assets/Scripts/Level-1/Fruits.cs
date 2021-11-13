using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public int _points;

    public Score _score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _score._coinsAmount += _points;
        this._points = 0;
        Destroy(this.gameObject);
        
    }
}
