using UnityEngine;
using System.Collections;

public class Przedmioty : MonoBehaviour {
    private  bool zamiana=false;
    public Material materialPoZmianaie;
    public Renderer rend;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(zamiana==true)
        {
            rend.material = materialPoZmianaie;
        }
	
	}
    void zmiana()
    {
        zamiana = true;
    }
}
