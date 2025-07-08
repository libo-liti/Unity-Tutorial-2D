using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private IItemObject _item;
    public Image itemImage;
    public Button slotButton;

    public bool isEmpty = true;

    private void Awake()
    {
        slotButton = GetComponent<Button>();
        itemImage = transform.GetChild(0).GetComponent<Image>();
        slotButton.onClick.AddListener(UseItem);
    }

    private void OnEnable()
    {
        // if (isEmpty)
        // {
        //     slotButton.interactable = false;
        //     itemIcon.gameObject.SetActive(false);
        // }
        // else
        // {
        //     slotButton.interactable = true;
        // }

        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }

    public void AddItem(IItemObject newItem)
    {
        _item = newItem;
        isEmpty = false;
        itemImage.sprite = newItem.Icon;
        itemImage.SetNativeSize();
    }

    public void UseItem()
    {
        if (_item != null)
        {
            _item.Use();
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        _item = null;
        isEmpty = true;
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }
}
