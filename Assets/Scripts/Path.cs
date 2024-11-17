using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    public Vector3 GetPointPosition(int index) => _waypoints[index].position;
}
