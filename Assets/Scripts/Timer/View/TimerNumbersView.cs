using TMPro;
using UnityEngine;
using System;

public class TimerNumbersView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerNumbersText;

    private ReactiveVariable<float> _currentTime;

    public void Initialize(ReactiveVariable<float> currentTime)
    {
        _timerNumbersText.GetComponentInChildren<TextMeshProUGUI>();
        
        _currentTime = currentTime;

        _currentTime.Changed += OnCurrentTimeChanged;
    }

    private void OnDestroy()
    {
        _currentTime.Changed -= OnCurrentTimeChanged;
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    private void OnCurrentTimeChanged(float oldValue, float currentValue)
    {
        ToViewByNumber(currentValue);
    }

    private void ToViewByNumber(float currentValue)
    {
        float roundValue = (float)Math.Round(currentValue, 1);
        _timerNumbersText.text = $"{roundValue}";
    }
}
