using UnityEngine;
using System.Collections;

public class Wywolanie : MonoBehaviour {
    public GameObject jednorozec;
    public GameObject wybuch;
    public GameObject wielkiDemon;
    public GameObject malyDemon;
    GameObject partner;
    float wartosc;
	// Use this for initialization
    void Start()
    {
        partner = GameObject.FindGameObjectWithTag("GameController");
        wywolaj();
    }
 void wywolaj()
    {
        Gra gr = partner.GetComponent<Gra>();
        wartosc = gr.stability;
        if(wartosc>70)
        {
            Debug.Log("Wielki demon");
            Instantiate(wielkiDemon, transform.position, transform.rotation);
        }
     else
        {
            if(wartosc>40)
            {
                Debug.Log("Mały demon");
                Instantiate(malyDemon, transform.position, transform.rotation);
            }
            else
            {
                if(wartosc>15)
                {
                    Debug.Log("Wybuch");
                    Instantiate(wybuch, transform.position, transform.rotation);
                }
                else
                {
                    Debug.Log("jednorożec");
                    Instantiate(jednorozec, transform.position, transform.rotation);
                }
            }
        }
        
    }
}
