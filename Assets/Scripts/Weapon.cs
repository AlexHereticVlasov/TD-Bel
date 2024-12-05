using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private TargetDetector _detector;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletBase _bullet;

    [SerializeField] private float _rate = 2;

    private float _time;

    private void Update()
    {
        _time -= Time.deltaTime;

        if (CanShoot())
        {
            Stoot();
        }
    }

    private bool CanShoot()
    {
        return _time <= 0 && _detector.Target != null;
    }

    private void Stoot()
    {
        var bullet = Instantiate(_bullet, _firePoint.position, Quaternion.identity);
        _time = _rate;
        bullet.Init(_detector.Target);
    }
}
