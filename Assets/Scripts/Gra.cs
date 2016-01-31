using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gra : MonoBehaviour {
    public float stability = 100f;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(stability < 10)
        {
            stability = 10;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("scena");
        }
	}

    public void endGame(bool f)
    {
        if (!f)
        {
            GameObject.Find("gameEndTxt").GetComponent<Text>().text = "GAME OVER!";
        }
        else
        {
            GameObject.Find("gameEndTxt").GetComponent<Text>().text = "WIN!";
        }
        //GameObject.Find("Nekromanta").GetComponent<Nekromanta>().ended = true;

        GameObject.FindGameObjectWithTag("Player").GetComponent<Inkwizytor>().canMove = false;
    }
}
