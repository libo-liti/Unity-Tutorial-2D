using UnityEngine;

public class MathCircle : MonoBehaviour
{
    [SerializeField] private float _theta;
    [SerializeField] private float _speed;
    private float _radius = 3f;

    void Update()
    {
        _theta += Time.deltaTime * _speed;

        Vector2 pos = new Vector2(Mathf.Cos(_theta), Mathf.Sin(_theta)) * _radius;
        transform.position = pos;
    }
}
