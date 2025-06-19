using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private List<Monster> monsterList = new List<Monster>();
    [SerializeField] private GameObject[] _monsters;
    [SerializeField] private GameObject[] _items;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            var randomIndex = Random.Range(0, _monsters.Length);
            var randomX = Random.Range(-8, 9);
            var randomY = Random.Range(-3, 5);

            var createPos = new Vector3(randomX, randomY, 0); 
            GameObject monster = Instantiate(_monsters[randomIndex], createPos, Quaternion.identity);
            
            monsterList.Add(monster.GetComponent<Monster>());
        }
    }

    public void DropCoin(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, _items.Length);
        GameObject item = Instantiate(_items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb2 = item.GetComponent<Rigidbody2D>();
        
        itemRb2.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb2.AddForceY(3f, ForceMode2D.Impulse);

        float randomPower = Random.Range(-3f, 3f);
        itemRb2.AddTorque(randomPower, ForceMode2D.Impulse);
    }
}
