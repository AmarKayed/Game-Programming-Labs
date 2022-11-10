using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Zoom_Controller : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation.Set(
        //    player.transform.rotation.x,
        //    player.transform.rotation.y,
        //    player.transform.rotation.z,
        //    player.transform.rotation.w
        //);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Equals))
        {

            Camera.main.fieldOfView--;
        }
        else if (Input.GetKey(KeyCode.Minus))
        {
            Camera.main.fieldOfView++;
        }

        transform.position = player.transform.position + new Vector3(0, 1, -5);


    }
}
