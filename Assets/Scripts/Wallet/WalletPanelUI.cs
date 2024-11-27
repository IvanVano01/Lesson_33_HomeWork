using TMPro;
using UnityEngine;

public class WalletPanelUI : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _diamondText;
    [SerializeField] private TextMeshProUGUI _energyText;

    private ReactiveVariable<int> _coin;
    private ReactiveVariable<int> _diamond;
    private ReactiveVariable<int> _energy;

    public void Initialize(ReactiveVariable<int> coin, ReactiveVariable<int> diamont, ReactiveVariable<int> energy)
    {
        _coin = coin;
        _diamond = diamont;
        _energy = energy;

        _coin.Changed += OnCoinChanged;
        _diamond.Changed += OnDiamondChanged;
        _energy.Changed += OnEnergyChanged;        
    }

    private void OnDestroy()
    {
        _coin.Changed += OnCoinChanged;
        _diamond.Changed += OnDiamondChanged;
        _energy.Changed += OnEnergyChanged;        
    }

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false); 
    
    private void OnEnergyChanged(int oldValue, int currentValue)
    {
        _energyText.text = currentValue.ToString();
    }

    private void OnDiamondChanged(int oldValue, int currentValue)
    {
        _diamondText.text = currentValue.ToString();
    }

    private void OnCoinChanged(int oldValue, int currentValue)
    {
        _coinsText.text = currentValue.ToString();
    }
}
