using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

    public Text TimeLeft;
    public float timer = 75;
    public Slider Slider;
    public int StartTime = 75;

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        TimeLeft.GetComponent<Text>().text = "" + Mathf.RoundToInt(timer) + "/"+ StartTime;
        Slider.GetComponent<Slider>().value = timer;
        if (timer <= 0)
        {
            SceneManager.LoadScene("Lose");
        }

    }
}
