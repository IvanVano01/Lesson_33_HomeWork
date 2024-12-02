using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerImageSpawnerView : MonoBehaviour
{
    [SerializeField] private Object _imagePrefab;
    private Queue<Object> _imageQueue = new Queue<Object>();

    private ReactiveVariable<float> _currentTime;
    private ReactiveVariable<float> _timeMax;
    private float _timerValue;

    private TimerPanelUI _timerPanelUI;
    private Button _startButton;
    private Button _stopButton;
    private Button _restartButton;

    private bool _isTimerRunning;

    public int ImageCount => _imageQueue.Count;

    public void Initialize(ReactiveVariable<float> currentTime, ReactiveVariable<float> timeMax, TimerPanelUI timerPanelUI)
    {
        _currentTime = currentTime;
        _timeMax = timeMax;
        _timerPanelUI = timerPanelUI;

        _startButton = _timerPanelUI.StartButton;
        _stopButton = _timerPanelUI.StopButton;
        _restartButton = _timerPanelUI.RestartButton;

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

    private void StartTimer()
    {
        _isTimerRunning = true;

        if (_timerValue <= 0)
        {
            for (int i = 0; i < _timeMax.Value; i++)
            {
                ToSpawn();
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
        ToClear();

        for (int i = 0; i < _timeMax.Value; i++)
        {
            ToSpawn();
        }

        _isTimerRunning = true;
    }

    private void OnCurrentTimeChanged(float oldValue, float currentValue)
    {
        _timerValue = currentValue;

        if (_isTimerRunning == false)
            return;

        if ((ImageCount - currentValue) >= 1)
        {
            if (ImageCount > 0)
                ToDestoy();
        }
    }

    private void ToSpawn()
    {
        Object image = Instantiate(_imagePrefab, this.gameObject.transform);
        _imageQueue.Enqueue(image);
    }

    private void ToDestoy()
    {
        Object image = _imageQueue.Dequeue();
        Destroy(image);
    }

    private void ToClear()
    {
        if (_imageQueue.Count > 0)
        {
            for (int i = 0; i < _imageQueue.Count; i++)
            {
                Object temp;
                temp = _imageQueue.Dequeue();

                Destroy(temp);
            }
        }
    }
}
