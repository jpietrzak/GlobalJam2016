using UnityEngine;
using System.Collections;

public class NekromantaSwiatlo : MonoBehaviour {
    public GameObject Fireball;
    float czas = 3f;
    public float duration = 1.0F;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) / 2 * 0.8F + 0.8F;
        this.GetComponent<Light>().intensity = amplitude + 2F;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("touched!");
            Instantiate(Fireball, transform.position, transform.rotation);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if((other.gameObject.tag == "Player") && (Time.time - czas >= 3))
        {
            Debug.Log("touched!");
            Instantiate(Fireball, transform.position, transform.rotation);
            czas = Time.time;
        }
    }
}
