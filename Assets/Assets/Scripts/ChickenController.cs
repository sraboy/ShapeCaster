using UnityEngine;
using System.Collections;

public class ChickenController : MonoBehaviour {

    private Rigidbody rb;

    [System.NonSerialized]
    public HazardController HazardController;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Old pos: " + rb.transform.position);
        rb.transform.LookAt(FindObjectOfType<PlayerController>().gameObject.transform);
        Debug.Log("New pos: " + rb.transform.position);
        rb.velocity = rb.transform.forward * 2;
    }
	
    void FixedUpdate()
    {


    }

    void Update()
    {
        if (Time.frameCount % 33 == 0 && rb.position.x >= -5) //just wander off-screen if it's made it as far as the player
        {
            StartCoroutine(ChangeDirection());
            Debug.Log(Time.frameCount);
        }
    }

    public IEnumerator ChangeDirection(bool towardPlayer = false)
    {
        var rnd = Random.Range(-2, 2); //20% chance the chickens will notice and follow the player, 50% chance up/down when wandering

        Transform t = FindObjectOfType<PlayerController>().gameObject.transform;

        if (this.gameObject.tag.Equals("Reward") || (this.gameObject.tag.Equals("Hazard") && (rnd == 1 || towardPlayer)))
        {
            rb.transform.LookAt(t);
            rb.velocity = rb.transform.forward * 1.2f;
            //Debug.Log("Going after the player.");
            yield return new WaitForSeconds(2f);
        }
        else //80% change they'll just wander off somewhere else
        {
            rb.transform.LookAt(new Vector3(t.position.x, t.position.y + (rnd * 10)));
            rb.velocity = rb.transform.forward;
            //Debug.Log("Wandering.");
            yield return new WaitForSeconds(2f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (HazardController != null)
            HazardController.ProcessTriggerEnter(this.gameObject, other);
        else
            Debug.LogError("HazardController cannot be null!");
    }

    
}
