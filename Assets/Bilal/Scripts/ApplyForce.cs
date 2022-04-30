using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    static bool trigger = true;
    void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.tag == "Car" && trigger)
        {
            trigger = false;
            float speed = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            Debug.Log(speed);
            float otherSpeed = other.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            Debug.Log(otherSpeed);
            StartCoroutine(ApplyReboundForce(other, speed, otherSpeed));
        }*/
    }

    IEnumerator ApplyReboundForce(Collision other, float speed, float otherSpeed)
    {
        Vector3 centroid = new Vector3(0, 0, 0);
        foreach (ContactPoint contact in other.contacts)
        {
            centroid += contact.point;
        }
        centroid = centroid / other.contacts.Length;

        Vector3 projection = other.transform.position;
        projection.x = centroid.x;
        Vector3 normaliseCollisionPoint = Vector3.Normalize(projection - centroid);
        float collidedBodyMass = other.gameObject.GetComponent<Rigidbody>().mass;

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        Debug.Log(other.gameObject.name);
        int i = 0;
        while (i < 5)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(normaliseCollisionPoint * speed * collidedBodyMass, ForceMode.Impulse);
            gameObject.GetComponent<Rigidbody>().AddForce(normaliseCollisionPoint * otherSpeed * collidedBodyMass, ForceMode.Impulse);
            yield return new WaitForFixedUpdate();
            i++;
        }
    }
}
