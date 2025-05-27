using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    public string hexcode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // GetComponent<MeshRenderer>().material = mat;
        
        // GetComponent<MeshRenderer>().sharedMaterial = mat;

        // GetComponent<MeshRenderer>().material.color = Color.green;
        
        // GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;

        // GetComponent<MeshRenderer>().material.color = new Color(200f/255f, 137f/255f , 200f/255f, 255f/255f);

        Material mat = GetComponent<MeshRenderer>().material;
        Color outputColor;

        if (ColorUtility.TryParseHtmlString(hexcode, out outputColor))
        {
            mat.color = outputColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
