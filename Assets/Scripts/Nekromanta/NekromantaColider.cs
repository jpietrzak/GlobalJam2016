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
        Przedmioty prz = collision.GetComponentInParent<Przedmioty>();
        if ((collision.tag == "Przedmiot") && (prz.zamiana == false))
        {
            Debug.Log("naprawa", collision.gameObject);
            Gra gr = partner.GetComponent<Gra>();
            collision.GetComponentInParent<Przedmioty>().naprawa();
            gr.stability = gr.stability - spadek;
        }
    }
}
