using UnityEngine;
using System.Collections;

public class Przedmioty : MonoBehaviour {
    private  bool zamiana=false;
    public Material materialPoZmianaie;
    Renderer rend;
    int zmaiany = 0;
    void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
    }
	// Update is called once per frame
	void Update () {
        if( (zamiana==true) && (zmaiany == 0))
        {
            rend.material = materialPoZmianaie;
        }
	
	}
    public void zmiana()
    {
        zamiana = true;
    }
}
