using UnityEngine;

public class BootstrapWallet : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] WalletPanelUI _walletPanelUIPrefab;
    [SerializeField] private Transform _parentPanelsUI;

    private WalletService _walletService;
    private WalletPanelUI _walletPanelUI;

    private void Awake()
    {
        _walletService = new WalletService();

        ReactiveVariable<int> coin = new ReactiveVariable<int>(default);
        ReactiveVariable<int> diamond = new ReactiveVariable<int>(default);
        ReactiveVariable<int> energy = new ReactiveVariable<int>(default);

        _walletService.AddNewCurrency(CurrencyTypes.Coin, coin);
        _walletService.AddNewCurrency(CurrencyTypes.Diamond, diamond);
        _walletService.AddNewCurrency(CurrencyTypes.Energy, energy);

        _walletPanelUI = Instantiate(_walletPanelUIPrefab, _parentPanelsUI);
        _walletPanelUI.Initialize(coin, diamond, energy);
        _walletPanelUI.Show();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _walletService.Add(CurrencyTypes.Coin, 1);
            Debug.Log($" В кошелёке лежит {_walletService.AmountCurrency(CurrencyTypes.Coin)} Coin! ");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (_walletService.HasEnough(CurrencyTypes.Coin, 1))
                _walletService.Spend(CurrencyTypes.Coin, 1);
            else
                Debug.Log($" В кошелёке не хватает запрашиваемой валюты Coin! ");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _walletService.Add(CurrencyTypes.Diamond, 1);
            Debug.Log($" В кошелёке лежит {_walletService.AmountCurrency(CurrencyTypes.Diamond)} Diamond! ");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (_walletService.HasEnough(CurrencyTypes.Diamond, 1))
            {
                _walletService.Spend(CurrencyTypes.Diamond, 1);
            }
            else
                Debug.Log($" В кошелёке не хватает запрашиваемой валюты Diamond!");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _walletService.Add(CurrencyTypes.Energy, 1);
            Debug.Log($" В кошелёке лежит {_walletService.AmountCurrency(CurrencyTypes.Energy)} Energy! ");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (_walletService.HasEnough(CurrencyTypes.Energy, 1))
            {
                _walletService.Spend(CurrencyTypes.Energy, 1);
            }
            else
                Debug.Log($" В кошелёке не хватает запрашиваемой валюты Energy! ");
        }
    }
}
