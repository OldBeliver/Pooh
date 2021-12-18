using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoohMovement))]

public class PoohInput : MonoBehaviour
{
    private PoohMovement _movement;

    private void Start()
    {
        _movement = GetComponent<PoohMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            _movement.TryMoveUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            _movement.TryMoveDown();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _movement.TryMoveLeft();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _movement.TryMoveRight();
        }
    }
}
