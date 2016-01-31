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
    public GameObject fireball;
    bool wywolana = false;
    bool skonczona = false;
    GameObject partner;
    float wartosc = 100;
    public AudioClip growl;
    // Use this for initialization
    void Start()
    {
        partner = GameObject.FindGameObjectWithTag("GameController");

        //
        //wywolaj();

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

                if(przyzwany.transform.localScale.x > 4f)
                {
                    skonczona = true;
                    //Debug.Log("anim!");
                    jednorozec.GetComponentInChildren<Animation>().Play("Unicorn");
                    Destroy(GameObject.Find("Nekromanta"), 0.5f);
                }
            }
        }
    }

    public void wywolaj()
    {
        wywolana = true;
        GameObject.Find("GameController").GetComponent<AudioSource>().PlayOneShot(growl);
        Gra gr = partner.GetComponent<Gra>();
        wartosc = gr.stability;
        if (wartosc > 70)
        {
            Debug.Log("Wielki demon");
            GameObject.Find("GameController").GetComponent<Gra>().endGame(false);
            przyzwany = Instantiate(demon, transform.position + Vector3.up * 6f, transform.rotation) as GameObject;
            przyzwany.transform.localRotation = Quaternion.Euler(0, -140, 0);
            przyzwany.transform.localScale = Vector3.one * 1f;
            przyzwany.GetComponentInChildren<Animation>().Play("kill");
            przyzwany.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
            przyzwany.transform.Rotate(Vector3.up * 180);
            Instantiate(wybuch, transform.position, transform.rotation);
            StartCoroutine(instFireball());
        }
        else if (wartosc > 40)
        {
            Debug.Log("Mały demon");
            GameObject.Find("GameController").GetComponent<Gra>().endGame(true);
            efekt = Instantiate(rozowy_dymek, transform.position, transform.rotation) as GameObject;
            przyzwany = Instantiate(demon, transform.position + Vector3.up * 4f, transform.rotation) as GameObject;
            przyzwany.transform.localScale = Vector3.one * 0.2f;
            przyzwany.transform.localRotation = Quaternion.Euler(0, -140, 0);
            przyzwany.GetComponentInChildren<Animation>().PlayQueued("idle");
            Destroy(efekt, 3);
        }
        else if (wartosc > 15)
        {
            Debug.Log("Wybuch");
            GameObject.Find("GameController").GetComponent<Gra>().endGame(true);
        }
        else
        {
            Debug.Log("jednorożec");
            GameObject.Find("GameController").GetComponent<Gra>().endGame(true);
            przyzwany = Instantiate(jednorozec, transform.position + Vector3.up * 9, transform.rotation) as GameObject;
            przyzwany.transform.localScale = Vector3.one * 0.1f;
            przyzwany.transform.localRotation = Quaternion.Euler(0, -140, 0);
        }
    }

    IEnumerator zrob_wybuch(float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(Instantiate(wybuch, transform.position + Vector3.right * Random.Range(0,0.1f) + Vector3.forward * Random.Range(0,0.1f), transform.rotation) as GameObject, 1);
    }

    IEnumerator instFireball()
    {
        foreach(GameObject g in GameObject.FindObjectsOfType<GameObject>())
        {
            Debug.Log("!");
            if(g.tag != "Player" && g.tag != "GameController")
            g.tag = "Fireball";
        }
        yield return new WaitForSeconds(2);
        Instantiate(fireball, transform.position + Vector3.up * 4f, transform.rotation);
        przyzwany.GetComponentInChildren<Animation>().Play("idle");
    }
}
