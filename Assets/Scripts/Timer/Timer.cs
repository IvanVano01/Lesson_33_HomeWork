using System.Collections;
using UnityEngine;

public class Timer
{    
    private float _timeMin =0;    

    private MonoBehaviour _monoBehaviour;
    private Coroutine _timerCoroutine;

    public Timer(ReactiveVariable<float> timeMax, ReactiveVariable<float> currentTime, MonoBehaviour monoBehaviour)
    {       
        _monoBehaviour = monoBehaviour;

        TimeMax = timeMax;
        CurrentTime = currentTime;
    }

    public ReactiveVariable<float> TimeMax { get; private set;}
    public ReactiveVariable<float> CurrentTime { get; private set;}

    private IEnumerator ToÑountdownTimer()
    {
        while (CurrentTime.Value > _timeMin)
        {
            CurrentTime.Value -= Time.deltaTime;

            yield return null;
        }

        _timerCoroutine = null;
    }

    public void StartTimer()
    {       
        if (CurrentTime.Value <= _timeMin && _timerCoroutine == null)
        {
            CurrentTime.Value = TimeMax.Value;
            _timerCoroutine = _monoBehaviour.StartCoroutine(ToÑountdownTimer());
        }
        else if (_timerCoroutine == null)
        {
            _timerCoroutine = _monoBehaviour.StartCoroutine(ToÑountdownTimer());
        }
    }

    public void StopTimer()
    {
        if (_timerCoroutine != null)
        {           
            _monoBehaviour.StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
        }
    }

    public void RestartTimer()
    {
        CurrentTime.Value = TimeMax.Value;

        if (_timerCoroutine != null)
        {
            _monoBehaviour.StopCoroutine(_timerCoroutine);
        }

        _timerCoroutine = _monoBehaviour.StartCoroutine(ToÑountdownTimer());
    }
}
