using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoohMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _leftBoard;
    [SerializeField] private float _rightBoard;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
            SetHightPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
            SetHightPosition(-_stepSize);
    }

    public void TryMoveLeft()
    {
        if (_targetPosition.x > _leftBoard)
            SetWidthPosition(-_stepSize);
    }

    public void TryMoveRight()
    {
        if (_targetPosition.x < _rightBoard)
            SetWidthPosition(_stepSize);
    }

    private void SetHightPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }

    private void SetWidthPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x + +stepSize, _targetPosition.y);
    }
}
