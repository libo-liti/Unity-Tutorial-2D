using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public void Use()
    {
        Debug.Log(3);
    }

    public void Grab()
    {
        Debug.Log(1);
    }

    public void Drop()
    {
        throw new System.NotImplementedException();
    }
}