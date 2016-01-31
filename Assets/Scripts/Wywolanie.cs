using UnityEngine;
using System.Collections;

public class Wywolanie : MonoBehaviour
{
    public GameObject jednorozec;
    public GameObject wybuch;
    public GameObject demon;
    public GameObject rozowy_dymek;
    public GameObject przyzwany;
    public GameObject efekt;
    bool wywolana = false;
    bool skonczona = false;
    GameObject partner;
    float wartosc = 14;
    // Use this for initialization
    void Start()
    {
        partner = GameObject.FindGameObjectWithTag("GameController");

        //

        wywolaj();

        //
    }

    void Update()
    {
        if (wywolana && !skonczona)
        {
            if (wartosc <= 40 && wartosc > 15)
            {
                GameObject.Find("Nekromanta").GetComponent<Nekromanta>().rusza_sie = false;
                GameObject.Find("Nekromanta").transform.position = Vector3.MoveTowards(GameObject.Find("Nekromanta").transform.position, this.transform.position, 15 * Time.deltaTime);
                if(Vector3.Distance(GameObject.Find("Nekromanta").transform.position, this.transform.position) < 0.5f && !skonczona)
                {
                    StartCoroutine(zrob_wybuch(0.1f));
                    StartCoroutine(zrob_wybuch(0.3f));
                    StartCoroutine(zrob_wybuch(0.5f));
                    skonczona = true;
                    Destroy(GameObject.Find("Nekromanta"));
                }
            }
            else if(wartosc <=15)
            {
                przyzwany.transform.localScale += Vector3.one * 0.1f;

                if(przyzwany.transform.localScale.x > 3f)
                {
                    skonczona = true;
                    //Debug.Log("anim!");
                    jednorozec.GetComponentInChildren<Animation>().Play("Unicorn");
                    Destroy(GameObject.Find("Nekromanta"), 1);
                }
            }
        }
    }

    public void wywolaj()
    {
        wywolana = true;
        Gra gr = partner.GetComponent<Gra>();
        //wartosc = gr.stability;
        if (wartosc > 70)
        {
            Debug.Log("Wielki demon");
            przyzwany = Instantiate(demon, transform.position, transform.rotation) as GameObject;
            przyzwany.transform.localRotation = Quaternion.Euler(0, -140, 0);
            przyzwany.transform.localScale = Vector3.one * 4f;
            Destroy(Instantiate(wybuch, transform.position, transform.rotation) as GameObject, 1);
        }
        else if (wartosc > 40)
        {
            Debug.Log("Mały demon");
            efekt = Instantiate(rozowy_dymek, transform.position, transform.rotation) as GameObject;
            przyzwany = Instantiate(demon, transform.position, transform.rotation) as GameObject;
            przyzwany.transform.localScale = Vector3.one * 1f;
            przyzwany.transform.localRotation = Quaternion.Euler(0, -140, 0);
            Destroy(efekt, 3);
        }
        else if (wartosc > 15)
        {
            Debug.Log("Wybuch");
        }
        else
        {
            Debug.Log("jednorożec");
            przyzwany = Instantiate(jednorozec, transform.position + Vector3.up * 4, transform.rotation) as GameObject;
            przyzwany.transform.localScale = Vector3.one * 0.1f;
            przyzwany.transform.localRotation = Quaternion.Euler(0, -140, 0);
        }
    }

    IEnumerator zrob_wybuch(float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(Instantiate(wybuch, transform.position + Vector3.right * Random.Range(0,0.1f) + Vector3.forward * Random.Range(0,0.1f), transform.rotation) as GameObject, 1);
    }
}
