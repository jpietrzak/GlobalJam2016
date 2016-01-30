using UnityEngine;
using System.Collections;

public class Rysunek : MonoBehaviour {

    public bool isDrawing = false;
    public GameObject par = null;
    public float distance;
    private float doneDistance = 0;
    Vector3 mousePos;
    GameObject progressBar = null;
    Vector3 initPos = new Vector3();
    public GameObject pb;
    public GameObject shaketxt;

    // Use this for initialization
    void Start ()
    {
        this.gameObject.transform.LookAt(Camera.main.transform);
        this.gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + Vector3.up * 4;
        mousePos = Input.mousePosition;
        initPos = this.gameObject.transform.position;
        progressBar = pb;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inkwizytor>().canMove = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (progressBar)
        {
            shaketxt.transform.localRotation = Quaternion.Euler(new Vector3(0, -180, Random.Range(0, 5)));

            progressBar.transform.localScale = new Vector3(doneDistance / distance * 6.4f, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
            progressBar.transform.position = new Vector3(initPos.x + 3.2f - progressBar.transform.localScale.x / 2, initPos.y, initPos.z);
            doneDistance += Vector3.Distance(mousePos, Input.mousePosition) / 100;
            mousePos = Input.mousePosition;
            if (distance < doneDistance)
            {
                par.GetComponent<Przedmioty>().zamiana = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inkwizytor>().canMove = true;
                DestroyImmediate(this.gameObject);
            }
        }
    }
}
