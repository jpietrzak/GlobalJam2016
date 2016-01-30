using UnityEngine;
using System.Collections;

public class Przedmioty : MonoBehaviour {
    public bool zamiana = false;
    public Material materialPoZmianaie;
    Renderer rend;
    int zmiany = 0;
    public GameObject rys1;

    void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
    }
	// Update is called once per frame
	void Update () {
        if( (zamiana==true) && (zmiany == 0))
        {
            rend.material = materialPoZmianaie;
        }
	
	}
    public void zmiana()
    {
        GameObject go = Instantiate(rys1, new Vector3(0,50f,50f), Quaternion.identity) as GameObject;
        go.GetComponent<Rysunek>().par = this.gameObject;
    }
}
