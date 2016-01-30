using UnityEngine;
using System.Collections;

public class NekromantaColider : MonoBehaviour {
    private GameObject partner;
    public float spadek = 5f;
    void Start()
    {
        partner = GameObject.FindGameObjectWithTag("GameController");
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("s");
        Przedmioty prz = collision.GetComponentInParent<Przedmioty>();
        if ((collision.tag == "Przedmiot") && (prz.zamiana == true))
        {
            Debug.Log("naprawa", collision.gameObject);
            Gra gr = partner.GetComponent<Gra>();
            prz.naprawa();
            this.GetComponentInParent<Nekromanta>().obniz_stability(5);
        }
    }
}
