using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;
    public bool isLight;
    public void Use()
    {
        isLight = !isLight;
        lightObj.SetActive(isLight);
    }

    public void Grab()
    {
        throw new System.NotImplementedException();
    }

    public void Drop()
    {
        throw new System.NotImplementedException();
    }
}