using UnityEngine;

public class Bullet : BulletBase
{
    public override void DealDamage(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }
}

public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] protected float _damage;

    private Enemy _target;

    internal void Init(Enemy target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null)
        {
            gameObject.AddComponent(typeof(Rigidbody));
            Destroy(this);
            Destroy(gameObject, 5);
            return;
        }

        Vector3 direction = _target.transform.position - transform.position;
        transform.Translate(_speed * Time.deltaTime * direction, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            DealDamage(enemy);
            Destroy(gameObject);
        }
    }
    public abstract void DealDamage(Enemy enemy);
}
