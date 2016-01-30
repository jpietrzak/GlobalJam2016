using UnityEngine;
using System.Collections;

public class NekromantaColider : MonoBehaviour {
    public float spadek = 5f;
    void Start()
    {
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("s");
        Przedmioty prz = collision.GetComponentInParent<Przedmioty>();
        if ((collision.tag == "Przedmiot") && (prz.zamiana == true))
        {
            Debug.Log("naprawa", collision.gameObject);
            prz.naprawa();
            this.GetComponentInParent<Nekromanta>().obniz_stability(5);
        }
    }
}
