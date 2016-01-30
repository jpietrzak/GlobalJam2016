using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
    GameObject objec;
    void Start()
    {
        objec = transform.parent.gameObject;
    }
    void Update()
    {
        transform.position = objec.transform.position;
        //Debug.Log(transform.position);
    }
    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("nice");
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("touched fireboll!");
            Destroy(other.gameObject);
            Destroy(objec);
        }
        else
        {
            if (other.gameObject.tag == "Fireball" || other.gameObject.tag == "Przedmiot")
             {
                return;
             }
             else
             {
                  //Debug.Log("objekt!");
                  Destroy(objec);
             }
        }
        
    }
}
