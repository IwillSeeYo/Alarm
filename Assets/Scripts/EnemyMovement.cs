using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 

class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _moveSpots;

    private Rigidbody2D _rigidbody2D;
    private float _speed=3f;
    private int _point;

    private void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, _moveSpots[_point].position, _speed* Time.deltaTime);

        if(Vector2.Distance(transform.position, _moveSpots[_point].position) < 0.2f)
            _point = (_point == 1) ? 0 : 1;
    }

}
