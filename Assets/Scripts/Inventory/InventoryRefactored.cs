using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryRefactored
{
    private List<Item> _items = new();

    public InventoryRefactored(IEnumerable<Item> items, int maxSize)
    {
        _items = new List<Item>(items);
        MaxSize = maxSize;
    }

    public int MaxSize { get; private set; }
    public int CurrentSize => _items.Sum(item => item.Count);

    public bool IsEnoughSpace(int itemCount) => CurrentSize + itemCount <= MaxSize;

    public List<int> ToSeeExistingItems()
    {
        List<int> listItemsID = new List<int>();

        if (_items.Count != 0)
        {
            foreach (Item item in _items)
                listItemsID.Add(item.ID);
        }

        return listItemsID;
    }

    public void Add(Item item)
    {
        if (IsEnoughSpace(item.Count) == false)
        {
            Debug.Log(" В инвенторе нет места для такого кол-ва айтэмов! ");
            return;
        }

        _items.Add(item);
    }

    public List<Item> GetItemsBy(int id, int count)
    {
        if (HasItem(id) == false)
        {
            Debug.Log($" инвентарь не содержит Айтем запрашиваемого по {id}");
            return null;
        }

        List<Item> listItems = new List<Item>();

        for (int i = 0; i < count; i++)
        {
            Item item = _items.First(item => item.ID == id);
            listItems.Add(item);
            _items.Remove(item);
        }

        return listItems;
    }

    public bool HasItem(int id)
    {
        foreach(Item item in _items)
        {
            if (item.ID == id)
                return true;
        }      

        return false;
    }
}

public class Item
{
    public Item(int iD, int count)
    {
        ID = iD;
        Count = count;
    }

    public int ID { get; private set; }
    public int Count { get; private set; }
}
