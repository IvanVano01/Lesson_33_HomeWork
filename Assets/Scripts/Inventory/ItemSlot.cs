using System;

public class ItemSlot
{
    private Item _item;

    public bool IsEquipped => _item != null;

    public int ItemID => _item.ID;


    public void Equip(Item item)
    {
        if (IsEquipped)
            throw new ArgumentException(" ���� ��� �����!");

        _item = item;
    }

    public Item UnEquip()
    {
        if (IsEquipped == false)
            throw new ArgumentException(" ������������� ���� ������!");

        Item item = _item;
        _item = null;

        return item;
    }
}
