using UnityEngine;

[RequireComponent(typeof(TargetDetector))]
public class Aim : MonoBehaviour
{
    [SerializeField] private TargetDetector _detector;
    [SerializeField] private Transform _partToRotate;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (_detector.Target == null) return;

        LookAtTarget();
    }

    private void LookAtTarget()
    {
        Vector3 direction = _detector.Target.transform.position - _partToRotate.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _partToRotate.rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _speed);
    }
}
