using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryRefactored
{
    private List<ItemSlot> _itemSlots;

    public InventoryRefactored(IEnumerable<ItemSlot> itemSlots, int maxSize)
    {
        _itemSlots = new List<ItemSlot>(itemSlots);

        MaxSize = maxSize;
    }

    public int MaxSize { get; private set; }    
    public IEnumerable<ItemSlot> ItemSlots => _itemSlots;

    public int NumberFilledSlots()
    {
        int size = 0;

        foreach (var itemSlot in _itemSlots)
        {
            if (itemSlot.IsEquipped)
                size++;
        }
        return size;
    }

    public bool HasItems(int ID, int count)
    {
        int amountItem = 0;

        foreach (ItemSlot itemSlot in _itemSlots)
        {
            if (itemSlot.IsEquipped)
            {
                if (itemSlot.ItemID == ID)
                    amountItem++;
            }
        }

        if (amountItem >= count)
            return true;

        return false;
    }

    public bool HasFreeItemSlots(int count)
    {
        int freeSlots = 0;

        foreach (var itemSlot in _itemSlots)
        {
            if (itemSlot.IsEquipped == false)
                freeSlots++;
        }

        if (freeSlots >= count)
            return true;

        return false;
    }

    public void Add(Item item, int count)
    {
        int numberAdded = 0;

        if (HasFreeItemSlots(count) == false)
        {
            Debug.Log(" В инвенторе нет места для такого кол-ва айтэмов! ");
            return;
        }

        foreach (ItemSlot itemSlot in _itemSlots)
        {
            if (itemSlot.IsEquipped == false && numberAdded < count)
            {
                itemSlot.Equip(item);
                numberAdded++;
                Debug.Log(" Добавили Айтем в слот");// для теста
            }
        }
    }

    public List<Item> GetItemsBy(int ID, int count)
    {
        if (HasItems(ID, count) == false)
        {
            Debug.Log($" инвентарь не содержит Айтем запрашиваемого по ID {ID}");
            return null;
        }

        List<Item> listItems = new List<Item>();
        int numberGet = 0;

        foreach (var itemSlot in _itemSlots)
        {
            if (itemSlot.IsEquipped)
            {
                if (itemSlot.ItemID == ID && numberGet < count)
                {
                    Item item = itemSlot.UnEquip();
                    listItems.Add(item);
                    numberGet++;
                    Debug.Log(" Достали Айтем из слота");// для теста
                }
            }
        }

        return listItems;
    }
}


