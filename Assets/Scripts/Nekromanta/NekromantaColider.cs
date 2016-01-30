using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NekromantaColider : MonoBehaviour {
    public float spadek = 5f;
    public GameObject costamtext;
    void Start()
    {
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponentInParent<Przedmioty>())
        {
            Przedmioty prz = collision.GetComponentInParent<Przedmioty>();
            if ((collision.tag == "Przedmiot") && (prz.zamiana == true))
            {
                Debug.Log("naprawa", collision.gameObject);
                prz.naprawa();
                GameObject cos = Instantiate(costamtext, this.transform.position + Vector3.up * 4, this.transform.rotation) as GameObject;
                cos.transform.LookAt(Camera.main.transform);
                cos.GetComponent<Text>().text = "- " + "5";
                cos.transform.SetParent(this.transform);
                this.GetComponentInParent<Nekromanta>().obniz_stability(5);
            }
        }
    }
}
