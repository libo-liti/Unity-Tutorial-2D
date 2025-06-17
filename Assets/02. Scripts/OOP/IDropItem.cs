using UnityEngine;

public interface IDropItem
{
    void Use();
    void Grab(Transform grabPos);
    void Drop();
}