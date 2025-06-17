using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public GameObject bulletPrefeb;
    public Transform shootPos;
    public void Use()
    {
        GameObject bullet = Instantiate(bulletPrefeb, shootPos.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        
        bulletRb.AddForce(shootPos.forward * 100f, ForceMode.Impulse);
        Debug.Log("총을 발사한다");
    }

    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.position = grabPos.position;
        Debug.Log("총을 주웠다.");
    }

    public void Drop()
    {
        transform.SetParent(null);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        Debug.Log("총을 버렸다.");
    }
}