using UnityEngine;
using UnityEngine.UI;


public class TimerImageFillView : MonoBehaviour
{
    [SerializeField] private Image _imageFillRound;

    private ReactiveVariable<float> _currentTime;
    private ReactiveVariable<float> _timeMax;

    public void Initialize(ReactiveVariable<float> currentTime, ReactiveVariable<float> timeMax)
    {
        _imageFillRound.GetComponentInChildren<Image>();
        _currentTime = currentTime;
        _timeMax = timeMax;

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
        ToFillImageRound(_timeMax.Value, currentValue);
    }

    private void ToFillImageRound(float timeMax, float currentValue) => _imageFillRound.fillAmount = 1 - (currentValue / timeMax);
}
