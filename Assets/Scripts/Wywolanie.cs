using UnityEngine;
using System.Collections;

public class Wywolanie : MonoBehaviour {
    public GameObject jednorozec;
    public GameObject wybuch;
    public GameObject wielkiDemon;
    public GameObject malyDemon;
    public GameObject partner;
    float wartosc;
	// Use this for initialization
 void wywolaj()
    {
        Gra gr = partner.GetComponent<Gra>();
        wartosc = gr.stability;
        if(wartosc>70)
        {
            Instantiate(wielkiDemon, transform.position, transform.rotation);
        }
     else
        {
            if(wartosc>40)
            {
                Instantiate(malyDemon, transform.position, transform.rotation);
            }
            else
            {
                if(wartosc>15)
                {
                    Instantiate(wybuch, transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(jednorozec, transform.position, transform.rotation);
                }
            }
        }
        
    }
}
