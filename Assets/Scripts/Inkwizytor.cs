using UnityEngine;
using System.Collections;


public class Inkwizytor : MonoBehaviour 
{
    public float speed = 3f;
    private Vector3 movement;
    Rigidbody playerRigidbody;
    public bool canMove = true;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Move(h, v);
        }
    }
    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * (-speed) * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }
    void OnCollisionStay(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if ((collision.gameObject.tag == "Przedmiot") || (collision.gameObject.tag == "Przedmiot1"))
        {
            //Debug.Log("colisja", collision.gameObject);
            if (collision.gameObject.GetComponentInParent<Przedmioty>())
            {
                if (Input.GetKeyDown(KeyCode.Space) && collision.gameObject.GetComponentInParent<Przedmioty>().zamiany == 0)
                {
                    collision.gameObject.GetComponentInParent<Przedmioty>().zmiana();
                }
            }
        }
    }
    public void blokuj()
    {
    
    }
}