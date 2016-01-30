using UnityEngine;
using System.Collections;

public class WielkiDemon : MonoBehaviour {
    private GameObject partner;
    public GameObject pocisk;
	// Use this for initialization
	void Start () {
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Throw fireball");
            Instantiate(pocisk, transform.position, transform.rotation);
        }
    }
}
