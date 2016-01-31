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
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (canMove)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Move(h, v);
        }
    }
    void Move(float h, float v)
    {
        Debug.Log(Input.GetAxisRaw("Horizontal") + "----" + Input.GetAxisRaw("Vertical"));
        movement.Set(h, 0f, v);
        
        //gora
        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            if (!this.GetComponentInChildren<Animation>().IsPlaying("InkStandingPose"))
            {
                this.GetComponentInChildren<Animation>().Play("InkStandingPose");
            }
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") > 0)
        { this.gameObject.transform.localRotation = (Quaternion.Euler(0, -135, 0));
            if (!this.GetComponentInChildren<Animation>().IsPlaying("InkWalkingPose"))
                this.GetComponentInChildren<Animation>().Play("InkWalkingPose");
        }
        //dol
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") < 0)
        { this.gameObject.transform.localRotation = (Quaternion.Euler(0, 45, 0));
            if (!this.GetComponentInChildren<Animation>().IsPlaying("InkWalkingPose"))
                this.GetComponentInChildren<Animation>().Play("InkWalkingPose");
        }
        //prawo
        if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") == 0)
        { this.gameObject.transform.localRotation = (Quaternion.Euler(0, -45, 0));
            if (!this.GetComponentInChildren<Animation>().IsPlaying("InkWalkingPose"))
                this.GetComponentInChildren<Animation>().Play("InkWalkingPose");
        }
        //lewo
        if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") == 0)
        { this.gameObject.transform.localRotation = (Quaternion.Euler(0, 135, 0));
            if (!this.GetComponentInChildren<Animation>().IsPlaying("InkWalkingPose"))
                this.GetComponentInChildren<Animation>().Play("InkWalkingPose");
        }
        

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
                    this.GetComponentInChildren<Animation>().Play("InkDoingPose");
                    collision.gameObject.GetComponentInParent<Przedmioty>().zmiana();
                }
            }
        }
    }
    public void blokuj()
    {
    
    }

    public void KillMe()
    {
        this.GetComponentInChildren<Animation>().Play("InkDyingPose");
        Destroy(this.gameObject, 2);
    }
}