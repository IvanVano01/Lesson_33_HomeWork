using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class TimerSliderBarView : MonoBehaviour
{
    private Slider _sliderTimerBar;

    private ReactiveVariable<float> _currentTime;
    private ReactiveVariable<float> _timeMax;

    public void Initialize(ReactiveVariable<float> currentTime, ReactiveVariable<float> maxTime)
    {
        _sliderTimerBar = GetComponent<Slider>();
        _currentTime = currentTime;
        _timeMax = maxTime;

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
        FillBar(_timeMax.Value, currentValue);
    }

    private void FillBar(float maxValue, float currentValue)

    {
        _sliderTimerBar.value = (currentValue / maxValue);
    }
}
