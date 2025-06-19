using UnityEngine;

public class Heart : MonoBehaviour, IItem
{
    private Inventory _inventory;

    public enum HeartType { Green, Blue}
    public HeartType heartType;
    
    private void Start()
    {        
        _inventory = FindFirstObjectByType<Inventory>();
        Obj = gameObject;
    }
    private void OnMouseDown()
    {
        Get();
    }

    public GameObject Obj { get; set; }

    public void Get()
    {
        Debug.Log($"{this.name}을 획득 했습니다.");
        _inventory.AddItem(this);
        gameObject.SetActive(false);
    }
}