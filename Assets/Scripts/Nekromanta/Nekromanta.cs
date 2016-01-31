using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Nekromanta : MonoBehaviour {

    public List<GameObject> trasa;
    public int ile_petli = 1;
    private int cel = 1;
    public bool rusza_sie = true;
    public bool the_end = false;
    public float szybkosc = 3.0f;
    public bool ended = false;
    public GameObject costamtext;
    int tmp = 0;


    // Use this for initialization
    void Start () {
        rusza_sie = true;
        cel = 1;
        this.gameObject.transform.position = trasa[0].transform.position;
	}

    // Update is called once per frame
    void Update() {
        if (rusza_sie && ile_petli > 0)
        {
            //this.GetComponentInChildren<Animation>().Play("Armature.001|Cylinder.001|Take 001|BaseLayer");
            //Debug.Log(cel);
            if(Vector3.Distance(this.gameObject.transform.position, trasa[cel].transform.position) > 0.1)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, trasa[cel].transform.position, szybkosc * Time.deltaTime);
                this.transform.LookAt(trasa[cel].transform.position);
            }
            else
            {
                StartCoroutine(czekaj(int.Parse(trasa[cel].name.Substring(trasa[cel].name.Length - 1))));
            }
        }
        else if (ile_petli <= 0)
        {
            the_end = true;
            rusza_sie = false;
        }
        
        if (the_end && !ended)
        {
            if(GameObject.FindGameObjectWithTag("Player"))
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inkwizytor>().canMove = false;
            ended = true;
            foreach (Transform p in GameObject.Find("mapa").GetComponentInChildren<Transform>())
            {
                if (p.gameObject.name == "pentagram")
                {
                    Debug.Log("child");
                    if (p.GetComponent<Przedmioty>().zamiany == 1)
                    {
                        tmp = tmp + 10;
                        Debug.Log("+10");
                    }
                }
                else if (p.gameObject.name == "swiecznik_stoj")
                {
                    foreach (Transform r in p.GetComponentInChildren<Transform>())
                    {
                        if (r.gameObject.name == "swiecznik_st")
                        {
                            Debug.Log("child");
                            if (r.GetComponent<Przedmioty>().zamiany == 1)
                            {
                                tmp = tmp + 10;
                                Debug.Log("+10");
                            }
                        }
                    }
                }
            }
            obniz_stability(tmp, this.gameObject);
            if (GameObject.FindGameObjectWithTag("Player"))
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inkwizytor>().canMove = false;
            GameObject.Find("DemonSpawn").GetComponent<Wywolanie>().wywolaj();
        }
    }
    public IEnumerator czekaj(int czas)
    {
        rusza_sie = false;
        cel++;
        if (cel >= trasa.Count)
        {
            cel = 0;
            ile_petli--;
        }
        yield return new WaitForSeconds(czas);
        rusza_sie = true;
    }

    public void obniz_stability(int ile, GameObject target)
    {
        Debug.Log("stability - " + ile);
        GameObject cos = Instantiate(costamtext, target.transform.position + Vector3.up * 4, Quaternion.Euler(0, 180, 0)) as GameObject;
        cos.GetComponent<TextMesh>().text = "- " + ile.ToString();
        cos.transform.SetParent(target.transform);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Gra>().stability -= ile;
    }
}
