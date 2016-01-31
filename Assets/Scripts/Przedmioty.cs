using UnityEngine;
using System.Collections;

public class Przedmioty : MonoBehaviour {
    public bool zamiana = false;
    public Texture materialPoZmianaie;
    public Texture orginalny;
    public int zamiany = 0;
    public GameObject rys1;
    public bool done = false;
    void Awake()
    {
    }
	// Update is called once per frame
	void Update () {
        if( (zamiana==true) && (zamiany == 0))
        {
            Debug.Log("render");
            if (name != "pentagram")
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                this.GetComponent<Renderer>().material.mainTexture= materialPoZmianaie;
            }
            zamiany =1;
        }
        if((zamiana == false)&& (zamiany ==1))
        {
            Debug.Log("render");
            if (name != "pentagram")
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                this.GetComponent<Renderer>().material.mainTexture = orginalny;
            }
            zamiany = 0;
        }
	
	}
    public void zmiana()
    {
        if (!done)
        {
            Destroy(GameObject.Find("shakeIt"));
            GameObject go = Instantiate(rys1, new Vector3(0, 50f, 50f), Quaternion.identity) as GameObject;
            go.GetComponent<Rysunek>().par = this.gameObject;
            go.GetComponent<Rysunek>().distance = 150f;
            go.name = "shakeIt";
            done = true;
        }
    }
    public void naprawa()
    {
        Debug.Log("zmiana");
        zamiana = false;
    }
}
