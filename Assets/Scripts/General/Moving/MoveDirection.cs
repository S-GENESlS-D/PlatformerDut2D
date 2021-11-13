using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 endPosition;
    [SerializeField] private float step;
    private float progress;
    void Start()
    {
        startPosition = gameObject.transform.position;
        transform.position = startPosition;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(startPosition, endPosition, progress);
        progress += step;
    }
}
