using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    private int _hp = 10;

    public int HP => _hp;

    public event UnityAction<int> HPChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _hp--;
            HPChanged?.Invoke(_hp);
            if (_hp <= 0)
            {
                Debug.Log("!!!");
            }

            Destroy(enemy.gameObject);
        }
    }
}
