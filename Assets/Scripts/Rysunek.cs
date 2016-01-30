using UnityEngine;
using System.Collections;

public class Rysunek : MonoBehaviour {

    public bool isDrawing = false;
    public GameObject par;

	// Use this for initialization
	void Start ()
    {
        this.gameObject.transform.LookAt(Camera.main.transform);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("elo");
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            Debug.Log(hitInfo.transform.name);
            if (hit && hitInfo.transform.gameObject.tag == "drawable" && hitInfo.transform.gameObject.name == "start")
            {
                isDrawing = true;
                Debug.Log("down");
            }
        }

        if(Input.GetMouseButton(0) && isDrawing)
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit && hitInfo.transform.gameObject.tag == "drawable" && hitInfo.transform.gameObject.name == "end")
            {
                Debug.Log("done");
                par.GetComponent<Przedmioty>().zamiana = true;
                DestroyImmediate(this.gameObject);
            }
            else if (hit && hitInfo.transform.gameObject.tag != "drawable")
            {
                isDrawing = false;
                Debug.Log("out");
            }
        }

        if(Input.GetMouseButtonUp(0) && isDrawing)
        {
            isDrawing = false;
            Debug.Log("up");
        }
    }
}
