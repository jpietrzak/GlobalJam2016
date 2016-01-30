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
            //Debug.Log(cel);
            if(Vector3.Distance(this.gameObject.transform.position, trasa[cel].transform.position) > 0.1)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, trasa[cel].transform.position, szybkosc * Time.deltaTime);
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
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inkwizytor>().canMove = false;
            ended = true;
            foreach (Transform p in GameObject.Find("mapa").GetComponentInChildren<Transform>())
            {
                if(p.gameObject.name == "swiecznik_st" || p.gameObject.name == "pentagram")
                {
                    if (p.gameObject.GetComponent<Przedmioty>().zamiany == 1)
                    obniz_stability(10);
                }
            }
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

    public void obniz_stability(int ile)
    {
        Debug.Log("stability - " + ile);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Gra>().stability -= ile;
    }
}
