using UnityEngine;
using System.Collections;

public class SpellCastController : MonoBehaviour {

    private Rigidbody rb;
    private AudioSource audio;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        var tr = GetComponent<Transform>();
        Debug.Log("Forward: " + tr.forward);
        //rb.AddForce(new Vector3(10f, 0f, 0f), ForceMode.Impulse);
        rb.velocity = tr.forward * 3;
        Debug.Log("velocity: " + rb.velocity);

        audio = GetComponent<AudioSource>();
        audio.Play();
    }
	
}
