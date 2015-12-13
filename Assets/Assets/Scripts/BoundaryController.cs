using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("BoundaryController destroyed " + other.gameObject);
        Destroy(other.gameObject);
    }
}
