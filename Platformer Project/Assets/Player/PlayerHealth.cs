using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int health = 10;
    public int lives = 10;
    public GameObject HealthPack;
    public Text HealthText;
    public Text HealthNumbers;
    public Slider Slider;

    // Use this for initialization
    void Start () {

        //PlayerPrefs.SetInt("Lives", lives);
        lives = PlayerPrefs.GetInt("Lives");

    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            health = 10;
            //reload the level
            PlayerPrefs.SetInt("Lives", lives - 1);
            lives--;
            if (lives <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        float yVelocity = GetComponent<Rigidbody2D>().velocity.y;
        if (collision.gameObject.tag == "Enemy" && yVelocity >= 0)
        {
            health -= 1;
        }
        else if (collision.gameObject.tag == "Enemy" && yVelocity < 0)
        {
            Destroy(collision.gameObject);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 150));
            GameObject healthPack = (GameObject)Instantiate(HealthPack, collision.gameObject.transform.position, Quaternion.identity);

        }
        if (collision.gameObject.tag == "Obstical")
        {
            health -= 1;
        }
        if (collision.gameObject.tag == "HealthPack")

        {
            health += 2;
            Destroy(collision.gameObject);
        }
        if (health > 10)
        {
            health = 10;
        }
        HealthText.GetComponent<Text>().text = "Health";
        HealthNumbers.GetComponent<Text>().text = "" + health + "/10";
        Slider.GetComponent<Slider>().value = health;
        if (health <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

}

