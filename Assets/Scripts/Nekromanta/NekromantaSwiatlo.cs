using UnityEngine;
using System.Collections;

public class NekromantaSwiatlo : MonoBehaviour {
    public GameObject Fireball;
    float czas = 3f;
    public float duration = 1.0F;
    public int fbcount = 0;
    public GameObject cage;

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
            if(fbcount >= 3)
            {
                GameObject go = Instantiate(cage, GameObject.FindGameObjectWithTag("Player").transform.position, transform.rotation) as GameObject;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inkwizytor>().canMove = false;
                StartCoroutine(unlockCage(go));
            }
            Debug.Log("Throw fireball");
            fbcount++;
            this.transform.parent.gameObject.GetComponentInChildren<Animation>().Play("CzarAttackPose");
            Instantiate(Fireball, transform.position, transform.rotation);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if((other.gameObject.tag == "Player") && (Time.time - czas >= 1))
        {
            if (fbcount >= 3)
            {
                GameObject go = Instantiate(cage, GameObject.FindGameObjectWithTag("Player").transform.position, transform.rotation) as GameObject;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inkwizytor>().canMove = false;
                StartCoroutine(unlockCage(go));
            }
            Debug.Log("Throw fireball");
            fbcount++;
            this.transform.parent.gameObject.GetComponentInChildren<Animation>().Play("CzarAttackPose");
            Instantiate(Fireball, transform.position, transform.rotation);
            czas = Time.time;
        }
    }

    IEnumerator unlockCage(GameObject go)
    {
        yield return new WaitForSeconds(3);
        Destroy(go);
        if(GameObject.FindGameObjectWithTag("Player"))
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inkwizytor>().canMove = true;
    }
}
