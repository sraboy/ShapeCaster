using UnityEngine;
using System.Collections;

public class SkyController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hazard")
        {
            if(other.gameObject.GetComponent<Rigidbody>().position.x >= -3)
                StartCoroutine(other.gameObject.GetComponent<ChickenController>().ChangeDirection(true));
            else
                StartCoroutine(other.gameObject.GetComponent<ChickenController>().ChangeDirection(false));
        }
    }	

}
