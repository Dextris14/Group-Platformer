using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coins : MonoBehaviour {
    public int coinCount = 0;
    public Text coinText;
    // Use this for initialization
    void Start () {
        coinText.GetComponent<Text>().text = "Coins:" + coinCount;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coins")
        {
            coinCount++;
            coinText.GetComponent<Text>().text = "Coins:" + coinCount;
            Destroy(collision.gameObject);
        }

    }
    
}
