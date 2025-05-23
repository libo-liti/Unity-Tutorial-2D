using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    public Transform targetTf;
    public Transform turrentHead;
    public GameObject bulletPrefab;
    public Transform firePos;

    public float timer;
    public float cooldownTime;
    void Start()
    {
        targetTf = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        turrentHead.LookAt(targetTf);

        timer += Time.deltaTime;
        if (timer >= cooldownTime)
        {
            timer = 0f;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
