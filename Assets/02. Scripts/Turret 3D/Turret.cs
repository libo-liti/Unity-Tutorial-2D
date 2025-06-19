using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turretHead;
    private float _theta;
    public float rotSpeed = 1f;
    public float rotRange = 60f;

    private bool _isTarget;
    public Transform target;
    private void Update()
    {
        if (!_isTarget)
            TurretIdle();
        else
            LookTarget();
    }

    private void TurretIdle()
    {
        _theta += Time.deltaTime * rotSpeed;
        float rotY = Mathf.Sin(_theta) * rotRange;
        
        turretHead.localRotation = Quaternion.Euler(0, rotY, 0);
    }

    void LookTarget()
    {
        turretHead.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
            _isTarget = true;
        }
    }
}
