using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerPanelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerNumbersText;
    [SerializeField] private Image _imageFillRound;
    [SerializeField] private TimerBar _sliderTimerBar;
    [SerializeField] private TimerImageSpawner _timerImageSpawner;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private Button _restartButton;
   
    private bool _isTimerRunning;

    private ReactiveVariable<float> _currentTime;
    private ReactiveVariable<float> _timeMax;

    private float _timerValue;

    public void Initialize(ReactiveVariable<float> currentTime, ReactiveVariable<float> maxTime)
    {
        _currentTime = currentTime;
        _timeMax = maxTime;

        _currentTime.Changed += OnCurrentTimeChanged;

        _startButton.onClick.AddListener(StartTimer);
        _stopButton.onClick.AddListener(StopTimer);
        _restartButton.onClick.AddListener(RestartTimer);
    }

    private void OnDestroy()
    {
        _currentTime.Changed -= OnCurrentTimeChanged;
        _startButton.onClick.RemoveListener(StartTimer);
        _stopButton.onClick.RemoveListener(StopTimer);
        _restartButton.onClick.RemoveListener(RestartTimer);
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public Button StartButton => _startButton;
    public Button StopButton => _stopButton;
    public Button RestartButton => _restartButton;

    private void StartTimer()
    {
        _isTimerRunning = true;

        if (_timerValue <= 0 )
        {
            for (int i = 0; i < _timeMax.Value; i++)
            {
                _timerImageSpawner.ToSpawn();
            }
        }
    }

    private void StopTimer()
    {
        _isTimerRunning = false;
    }

    private void RestartTimer()
    {
        _isTimerRunning = false;
        _timerImageSpawner.ToClear();        
       
        for (int i = 0; i < _timeMax.Value; i++)
        {
            _timerImageSpawner.ToSpawn();
        }
        _isTimerRunning = true;
    }

    private void OnCurrentTimeChanged(float oldValue, float currentValue)
    {
        _timerValue = currentValue;        

        ToViewByNumber(currentValue);

        ToFillImageRound(currentValue);

        ToFillSliderBar(currentValue);

        ToLaunchImageSpawner(currentValue);
    }

    private void ToViewByNumber(float currentValue)
    {
        float roundValue = (float)Math.Round(currentValue, 1);
        _timerNumbersText.text = $"{roundValue}";
    }

    private void ToFillImageRound(float currentValue) => _imageFillRound.fillAmount = 1 - (currentValue / _timeMax.Value);

    private void ToFillSliderBar(float currentValue) => _sliderTimerBar.FillBar(_timeMax.Value, currentValue);

    private void ToLaunchImageSpawner(float currentValue)
    {
        if (_isTimerRunning == false)
            return;

        if ((_timerImageSpawner.ImageCount - currentValue) >= 1)
        {
            if (_timerImageSpawner.ImageCount > 0)
                _timerImageSpawner.ToDestoy();
        }
    }
}
