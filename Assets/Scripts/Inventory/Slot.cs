using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image SlotFrame => _slotFrame;
    public Image ItemIcon => _itemIcon;
    public Item Item { get; private set; }
    public int SlotIndex { get; private set; }

    [SerializeField] private Image _slotFrame;
    [SerializeField] private Image _itemIcon;

    public void SetIndex(int slotIndex) => SlotIndex = slotIndex;

    public void PlaceItem(Item item)
    {
        Item = item;
    }
}
