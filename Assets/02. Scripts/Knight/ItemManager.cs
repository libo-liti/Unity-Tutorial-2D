using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

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
        
    }
}