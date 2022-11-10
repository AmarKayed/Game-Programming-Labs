using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform tr;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    { 
        offset = this.transform.position - tr.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = tr.position + offset;
    }
}
