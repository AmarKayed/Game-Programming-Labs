using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Controller : MonoBehaviour
{
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate((new Vector3(15, 30, 45)) * Time.deltaTime);
    }
}
