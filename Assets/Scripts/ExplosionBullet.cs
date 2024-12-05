using UnityEngine;

public class ExplosionBullet : BulletBase
{
    [SerializeField] private float _radius = 5;

    public override void DealDamage(Enemy enemy)
    {
        var colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var col in colliders)
        {
            if (col.TryGetComponent(out Enemy enemInRange))
            {
                enemInRange.TakeDamage(_damage);
            }
        }
    }
}
