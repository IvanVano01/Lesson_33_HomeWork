using UnityEngine;
using UnityEngine.UI;

public class TimerPanelUI : MonoBehaviour
{
    [SerializeField] private TimerNumbersView _timerNumbersView;
    [SerializeField] private TimerImageFillView _timerImageFillView;
    [SerializeField] private TimerSliderBarView _sliderTimerBarView;
    [SerializeField] private TimerImageSpawnerView _timerImageSpawnerView;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private Button _restartButton; 

    public void Initialize(ReactiveVariable<float> currentTime, ReactiveVariable<float> maxTime)
    {       
        _timerNumbersView.Initialize(currentTime);
        _sliderTimerBarView.Initialize(currentTime, maxTime);
        _timerImageFillView.Initialize(currentTime, maxTime);
        _timerImageSpawnerView.Initialize(currentTime, maxTime, this);
    }    

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    public Button StartButton => _startButton;
    public Button StopButton => _stopButton;
    public Button RestartButton => _restartButton;    
}
