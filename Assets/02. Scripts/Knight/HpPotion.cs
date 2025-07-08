using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class HpPotion : MonoBehaviour, IItemObject
{
    public ItemManager Inventory { get; set; }
    public GameObject Obj { get; set; }
    public string ItemName { get; set; }
    public Sprite Icon { get; set; }

    private void Start()
    {
        Inventory = FindFirstObjectByType<ItemManager>();
        Obj = gameObject;
        ItemName = name;
        Icon = GetComponent<SpriteRenderer>().sprite;
    }

    public void Get()
    {
        gameObject.SetActive(false);
        Inventory.GetItem(this);
    }

    public void Use()
    {
        Debug.Log("포션 사용");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Get();
        }
    }
}
