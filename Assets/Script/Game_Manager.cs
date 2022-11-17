using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class Game_Manager : MonoBehaviour
{
    static Vector3 spherePosition;
    public GameObject scoreCard;
    public GameObject timeCard;
    private static TextMeshProUGUI score;
    private static TextMeshProUGUI timeText;
    private static float time = 0.0f;
    public GameObject endGameCard;
    public static TextMeshProUGUI endGameText;

    // Start is called before the first frame update
    void Start()
    {
        score = scoreCard.GetComponent<TextMeshProUGUI>();
        score.text = "Score: 0";
        endGameText = endGameCard.GetComponent<TextMeshProUGUI>();
        timeText = timeCard.GetComponent<TextMeshProUGUI>();
        StartCoroutine(incrementTime());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator incrementTime()
    {
        var timeCardText = timeCard.GetComponent<TextMeshProUGUI>();
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            time += 0.1f;
            timeCardText.text = String.Format("{0:0.0}", time);
        }
    }
    public static void Update_Score(int numar)
    {
        score.text = $"Score: {numar}";
    }
    public static Vector3 Generate_Cube_Position()
    {
        spherePosition = GameObject.FindWithTag("Sfera").transform.position;
        Vector3 position;

        position = new Vector3(Random.Range(-35.0f, 35.0f), 5, Random.Range(-35.0f, 35.0f));
        while (Vector3.Distance(position, spherePosition) < 10)
        {
            position = new Vector3(Random.Range(-35.0f, 35.0f), 5, Random.Range(-35.0f, 35.0f));
        }
        return position;
    }

    public static void Generate_Cube()
    {
        Vector3 position = Generate_Cube_Position();
        int probability = Random.Range(0, 3);
        // Pentru cazuri mai complicate folosim switch  
        string cubeType = probability == 0 ? "Red Cube" : "Cube";
        GameObject cubeInstance = Instantiate(Resources.Load(cubeType, typeof(GameObject)), position, Quaternion.identity) as GameObject;
    }

    public static void On_End_Game()
    {

        Sphere_Controller.speed = 0;
        string endGameString;
        if (PlayerPrefs.HasKey("BestTime"))
        {
            if(time < PlayerPrefs.GetFloat("BestTime"))
            {
                endGameString = $"New Best Time: {timeText.text}";
                PlayerPrefs.SetFloat("BestTime", time);
            }
            else
            {
                endGameString = $"Your time: {timeText.text}\nBest time: {PlayerPrefs.GetFloat("BestTime")}.2f";
            }
        }
        else
        {
            endGameString = $"New Best Time: {timeText.text}";
            PlayerPrefs.SetFloat("BestTime", time);
        }

        endGameText.text = endGameString;
        endGameText.gameObject.SetActive(true);
        score.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);
    }
}
