using UnityEngine;
using System.Collections;

public class Przedmioty : MonoBehaviour {
    public bool zamiana = false;
    public Texture materialPoZmianaie;
    public Texture orginalny;
    Renderer rend;
    public int zamiany = 0;
    public GameObject rys1;
    void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
    }
	// Update is called once per frame
	void Update () {
        if( (zamiana==true) && (zamiany == 0))
        {
            Debug.Log("render");
            rend.material.mainTexture= materialPoZmianaie;
            zamiany=1;
        }
        if((zamiana == false)&& (zamiany ==1))
        {
            Debug.Log("render");
            rend.material.mainTexture = orginalny;
            zamiany = 0;
        }
	
	}
    public void zmiana()
    {
        GameObject go = Instantiate(rys1, new Vector3(0,50f,50f), Quaternion.identity) as GameObject;
        go.GetComponent<Rysunek>().par = this.gameObject;
    }
    public void naprawa()
    {
        Debug.Log("zmiana");
        zamiana = false;
    }
}
