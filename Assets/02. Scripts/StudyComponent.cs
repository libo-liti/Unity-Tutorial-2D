using Unity.VisualScripting;
using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    // public GameObject obj;
    //
    // public Transform objTf;

    public GameObject obj;
    public Mesh msh;
    public Material mat;
    void Start()
    {
        CreateCube("Hello World");
        CreateCube();
        
        //obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // obj = GameObject.FindWithTag("Player");
        //
        // objTf = GameObject.FindGameObjectWithTag("Player").transform;
        //
        // Debug.Log($"위치 : {obj.transform.position}");
        //
        // obj.GetComponent<MeshRenderer>().enabled = false;
        //
        // obj.SetActive(false);

        // Debug.Log($"이름 : {obj.name}");
        // Debug.Log($"태그 : {obj.tag}");
        // Debug.Log($"위치 : {obj.transform.position}");
        // Debug.Log($"회전 : {obj.transform.rotation}");
        // Debug.Log($"크기 : {obj.transform.localScale}");
        //
        // Debug.Log($"Mesh  데이터 : {obj.GetComponent<MeshFilter>().mesh}");
        // Debug.Log($"Material 데이터 : {obj.GetComponent<MeshRenderer>().material}");
    }

    public void CreateCube(string name = "Cube")
    {
        obj = new GameObject(name);

        obj.AddComponent<MeshFilter>();
        obj.GetComponent<MeshFilter>().mesh = msh;
        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;
        obj.AddComponent<BoxCollider>();
    }
}
