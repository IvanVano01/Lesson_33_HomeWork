using System.Collections.Generic;
using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private int _itemsCountMax;
    [SerializeField] private int _numberTakeAtOne;
    [SerializeField] private int _itemSwordID;
    [SerializeField] private int _itemShieldID;

    private List<ItemSlot> _itemSlots;

    private ItemSlot _itemSlot;
    private Item _itemSword;
    private Item _itemShield;

    private InventoryRefactored _inventoryRefactored;

    [Header("Inventory")]
    [SerializeField] private List<int> _seeItemSlots = new();// для теста

    private void Awake()
    {
        _itemSword = new Item(_itemSwordID);
        _itemShield = new Item(_itemShieldID);

        _itemSlots = new();

        for (int i = 0; i < _itemsCountMax; i++)
        {
            _itemSlot = new ItemSlot();

            _itemSlots.Add(_itemSlot);
        }

        _inventoryRefactored = new InventoryRefactored(_itemSlots, _itemsCountMax);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _inventoryRefactored.Add(_itemSword, _numberTakeAtOne);


            _seeItemSlots.Clear();

            foreach (ItemSlot slot in _inventoryRefactored.ItemSlots)
            {
                if (slot.IsEquipped)
                    _seeItemSlots.Add(slot.ItemID);
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            List<Item> getItem = _inventoryRefactored.GetItemsBy(_itemSword.ID, _numberTakeAtOne);



            _seeItemSlots.Clear();

            foreach (ItemSlot slot in _inventoryRefactored.ItemSlots)
            {
                if (slot.IsEquipped)
                    _seeItemSlots.Add(slot.ItemID);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _inventoryRefactored.Add(_itemShield, _numberTakeAtOne);



            _seeItemSlots.Clear();

            foreach (ItemSlot slot in _inventoryRefactored.ItemSlots)
            {
                if (slot.IsEquipped)
                    _seeItemSlots.Add(slot.ItemID);

            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            List<Item> getItem = _inventoryRefactored.GetItemsBy(_itemShield.ID, _numberTakeAtOne);


            _seeItemSlots.Clear();

            foreach (ItemSlot slot in _inventoryRefactored.ItemSlots)
            {
                if (slot.IsEquipped)
                    _seeItemSlots.Add(slot.ItemID);
            }
        }

        if (Input.GetKeyDown(KeyCode.G))        
            Debug.Log($" В инвентаре находится {_inventoryRefactored.NumberFilledSlots()} кол-во вещей ");        
    }
}

