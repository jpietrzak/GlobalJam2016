using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NekromantaColider : MonoBehaviour {
    public float spadek = 5f;
    void Start()
    {
    }
    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("!");
        //Debug.Log(collision.gameObject.name);
        if (collision.GetComponentInParent<Przedmioty>())
        {
            Przedmioty prz = collision.GetComponentInParent<Przedmioty>();
            if ((collision.tag == "Przedmiot") && (prz.zamiana == true))
            {
                this.GetComponent<Animation>().Play("CzarDoingPose");
                Debug.Log("naprawa", collision.gameObject);
                prz.naprawa();
                this.GetComponentInParent<Nekromanta>().obniz_stability(5, this.gameObject);
            }
        }
    }
}
