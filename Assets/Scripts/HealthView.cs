using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Finish _finish;

    private void OnEnable() => _finish.HPChanged += OnHPChanged;

    private void Start()
    {
        _slider.maxValue = _finish.HP;
        _slider.value = _slider.maxValue;
    }

    private void OnDisable() => _finish.HPChanged -= OnHPChanged;

    private void OnHPChanged(int hp) => _slider.value = hp;
}
