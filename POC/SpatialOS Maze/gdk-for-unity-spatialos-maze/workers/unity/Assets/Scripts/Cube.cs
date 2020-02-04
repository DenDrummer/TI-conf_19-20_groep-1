using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject cubePrefab;
    CubeManager cubeManager = new CubeManager();
    // Start is called before the first frame update

    public void Instantiate(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        GameObject.Instantiate(prefab, pos, rot);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
