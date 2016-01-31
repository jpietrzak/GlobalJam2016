using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
}
