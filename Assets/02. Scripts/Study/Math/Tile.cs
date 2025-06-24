using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] turret;

    private void OnMouseDown()
    {
        Instantiate(turret[SetTile.turretIndex], transform.position, Quaternion.identity);
    }
}
