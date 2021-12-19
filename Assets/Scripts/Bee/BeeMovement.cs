using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector3 _direction;

    private void OnEnable()
    {
        _direction = Vector3.left;

        if (transform.position.x < 0)
        {
            _direction = Vector3.right;
        }
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
