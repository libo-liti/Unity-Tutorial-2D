using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public Button inventoryButton;
    
    [SerializeField] private GameObject[] items;
    public Slot[] slots;
    [SerializeField] private Transform slotGroup;

    private void Start()
    {
        slots = slotGroup.GetComponentsInChildren<Slot>(true);
        
        inventoryButton.onClick.AddListener(OnInventory);
    }

    public void OnInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void DropItem(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb2 = item.GetComponent<Rigidbody2D>();

        itemRb2.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb2.AddForceY(3f, ForceMode2D.Impulse);

        float randomPower = Random.Range(-3f, 3f);
        itemRb2.AddTorque(randomPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        foreach (var slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.AddItem(item);
                break;
            }
        }
    }
}