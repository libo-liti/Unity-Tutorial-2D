using System;
using UnityEngine;

public class MathLight : MonoBehaviour
{
    private Light _light;
    private float _theta;

    [SerializeField] private float _power;
    [SerializeField] private float _speed;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        _theta += Time.deltaTime * _speed;
        // _light.intensity = Mathf.Sin(_theta) * _power;
        _light.intensity = Mathf.PerlinNoise(_theta, 0) * _power;
    }
}
