using UnityEngine;
using UnityEngine.UI;

public class BootstrapTimer : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private float _timeMax;

    [Header("Links")]
    [SerializeField] private TimerPanelUI _timerPanelUIPrefab;
    [SerializeField] private Transform _parentPanelsUI;
    

    private TimerPanelUI _timerPanelUI;
    private Button _startButton;
    private Button _stopButton;
    private Button _restartButton;

    private Timer _timer;

    private void Awake()
    {
        ReactiveVariable<float> timeMax = new ReactiveVariable<float>(_timeMax);
        ReactiveVariable<float> currentTime = new ReactiveVariable<float>(default);

        _timer = new Timer(timeMax,currentTime, this);
        _timerPanelUI = Instantiate(_timerPanelUIPrefab, _parentPanelsUI);
        _timerPanelUI.Initialize(currentTime, timeMax);
        _timerPanelUI.Show();       

        _startButton = _timerPanelUI.StartButton;
        _stopButton = _timerPanelUI.StopButton;
        _restartButton = _timerPanelUI.RestartButton;

        _startButton.onClick.AddListener(StartTimer);
        _stopButton.onClick.AddListener(StopTimer);
        _restartButton.onClick.AddListener(RestartTimer);
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(StartTimer);
        _stopButton.onClick.RemoveListener(StopTimer);
        _restartButton.onClick.RemoveListener(RestartTimer);
    }

    private void StartTimer()
    {
        _timer.StartTimer();
    }

    private void StopTimer()
    {
        _timer.StopTimer();
    }

    private void RestartTimer()
    {
        _timer.RestartTimer();
    }    

}
