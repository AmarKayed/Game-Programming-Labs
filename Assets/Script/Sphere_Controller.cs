using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sphere_Controller : MonoBehaviour
{
    public static float speed;
    Rigidbody rb;
    private static int numar = 0;
    public TextMeshProUGUI endGameText;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20;
        rb = GetComponent<Rigidbody>();
        Game_Manager.Generate_Cube();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Debug.Log("Horizontal: " + h);
        //Debug.Log("Vertical: " + v);
        //Debug.Log("Speed: " + speed);
        rb.AddForce(new Vector3(h, 0, v) * speed);
    }
    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Am atins ceva");
        if (other.gameObject.CompareTag("Cub") || other.gameObject.CompareTag("Cub Rosu"))
        {
            //other.gameObject.SetActive(false);
            //Debug.Log("Am papat un cub");
            numar++;
            Game_Manager.Update_Score(numar);
            //Game_Manager.Generate_Cube();
            //other.transform.position = Game_Manager.Generate_Cube_Position();
            Game_Manager.Generate_Cube();
            Destroy(other.gameObject);
            speed = Mathf.Abs(speed);
            if (other.gameObject.CompareTag("Cub Rosu"))
            {
                speed *= -1;
            }
            if(numar == 3)
            {
                //speed = 0;
                //endGameText.gameObject.SetActive(true);
                Game_Manager.On_End_Game();
            }
        }
        
        //else if (other.gameObject.CompareTag("Cilindru"))
        //{
        //    Debug.Log("Am intrat in cilindru");
        //}
    }
}
