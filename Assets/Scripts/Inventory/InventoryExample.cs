using System.Collections.Generic;
using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private int _itemsCountMax;

    private Item _itemSword = new Item(0, 1);
    private Item _itemShield = new Item(1, 1);

    private InventoryRefactored _inventoryRefactored;

    private void Awake()
    {
        _items = new();
        _inventoryRefactored = new InventoryRefactored(_items, _itemsCountMax);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _inventoryRefactored.Add(_itemSword);

            if (_inventoryRefactored.IsEnoughSpace(_itemSword.Count))
            {
                Debug.Log($" Добавили в инвентарь Меч");
            }

            ToPrintListItemID(_inventoryRefactored.ToSeeExistingItems());
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            List<Item> getItem = _inventoryRefactored.GetItemsBy(0, 1);

            if (_inventoryRefactored.HasItem(0))
            {
                Debug.Log($" Забрали из инвентаря Меч");
            }

            ToPrintListItemID(_inventoryRefactored.ToSeeExistingItems());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _inventoryRefactored.Add(_itemShield);

            if (_inventoryRefactored.IsEnoughSpace(_itemShield.Count))
            {
                Debug.Log($" Добавили в инвентарь Щит");
            }

            ToPrintListItemID(_inventoryRefactored.ToSeeExistingItems());
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            List<Item> getItem = _inventoryRefactored.GetItemsBy(1, 1);
            if (_inventoryRefactored.HasItem(1))
            {
                Debug.Log($" Забрали из инвентаря Щит");
            }

            ToPrintListItemID(_inventoryRefactored.ToSeeExistingItems());
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log($" В инвентаре находится {_inventoryRefactored.CurrentSize.ToString()} кол-во вещей ");
        }
    }

    private void ToPrintListItemID(List<int> listItemsID)
    {
        foreach (int itemID in listItemsID)
        {
            Debug.Log($" В инвентарь содержит айтем с ID{itemID.ToString()}");
        }
    }

}

