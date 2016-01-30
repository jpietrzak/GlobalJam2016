using UnityEngine;
using System.Collections;

public class Namierzanie : MonoBehaviour
{
    public float walkSpeed = 20f;
    Rigidbody namRigitbody;
    private float timer = 0;
    float attackDistance = 0.3f;
    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {

            Quaternion targetRotation = Quaternion.LookRotation(other.transform.position - transform.position);
            float oryginalX = transform.rotation.x;
            float oryginalZ = transform.rotation.z;

            Quaternion finalRotation = Quaternion.Slerp(transform.rotation, targetRotation, 5.0f * Time.deltaTime);
            finalRotation.x = oryginalX;
            finalRotation.z = oryginalZ;
            transform.rotation = finalRotation;

            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance > attackDistance)
            {
                transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            }


            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            Vector3 wector = transform.position;
            wector.y = 8;
            transform.position= wector;
        }
    }
}
