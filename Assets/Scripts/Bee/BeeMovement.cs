using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Vector3 _direction;

    private void OnEnable()
    {   
        _direction = transform.position.x > 0 ? Vector3.left : Vector3.right;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
