using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField] private Slider _sliderTimerBar;

    private void Awake()
    {
        _sliderTimerBar = GetComponent<Slider>();
    }

    public void FillBar(float maxValue, float currentValue)

    {
        _sliderTimerBar.value = (currentValue / maxValue);
    }
}
