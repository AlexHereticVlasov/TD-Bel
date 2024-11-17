using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3; 

    private Path _path;
    private int _index;

    internal void Init(Path path)
    {
        _path = path;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                                        _path.GetPointPosition(_index), 
                                        _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WayPoint _))
        {
            _index++;
        }
    }
}
