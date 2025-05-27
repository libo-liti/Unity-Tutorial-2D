using UnityEngine;

public class Material_loopMap : MonoBehaviour
{
    private Renderer _renderer;
    public float offsetSpeed = 0.1f;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 offset = Time.deltaTime * offsetSpeed * Vector2.right;
        
        _renderer.material.SetTextureOffset("_MainTex", _renderer.material.mainTextureOffset + offset);
    }
}
