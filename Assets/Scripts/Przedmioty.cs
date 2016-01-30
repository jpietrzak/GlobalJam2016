using UnityEngine;
using System.Collections;

public class Przedmioty : MonoBehaviour {
    public  bool zamiana=false;
    public Material materialPoZmianaie;
    public Material orginalny;
    Renderer rend;
    int zamiany = 0;
    void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
    }
	// Update is called once per frame
	void Update () {
        if( (zamiana==true) && (zamiany == 0))
        {
            rend.material = materialPoZmianaie;
            zamiany=1;
        }
        if((zamiana == false)&& (zamiany ==1))
        {
            Debug.Log("render");
            rend.material = orginalny;
            zamiany = 0;
        }
	
	}
    public void zmiana()
    {
        zamiana = true;
    }
    public void naprawa()
    {
        Debug.Log("zmiana");
        zamiana = false;
    }
}
