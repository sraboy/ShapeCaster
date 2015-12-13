using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    private float nextFire;
    private bool ableToJump = true;
    private Rigidbody rb;
    private Renderer rend;

    public GameObject SpellCast;
    public Transform SpellCastSpawnPosition;
    public GameController gameController;

    /// <summary>
    /// The reciprocal of the desired fire rate, in shots per second (e.g., 0.25 = 4 shots/s)
    /// </summary>
    public float FireRate;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<MeshRenderer>();
        gameController = FindObjectOfType<GameController>();
        
    }
	
    public void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;
            Instantiate(SpellCast, SpellCastSpawnPosition.position, SpellCastSpawnPosition.rotation);//new Quaternion(0, 270, 0, 0));
            ChangeScale(-.5f);
            //Debug.Log("scsp for: " + SpellCastSpawnPosition.forward);
            //audio.Play();
        }
    }

    public void Jump()
    {
        if(ableToJump)
        { //todo: need to set ableToJump based on whether or not we're on the ground
            ableToJump = false;
            rb.AddForce(new Vector3(rb.velocity.x, 500), ForceMode.Force);
        }

        ableToJump = true;
    }

    public IEnumerator TakeDamage()
    {
        
        Debug.Log("Hit player...");
        if (rend == null)
            Debug.LogError("rend cannot be null!");
        if (rend.material == null)
            Debug.LogError("material cannot be null!");

        var oldColor = rend.material.GetColor("_Color");
        //Debug.Log("oldColor = " + oldColor);
        //rend.material.EnableKeyword("_EmissionColor");
        //rend.material.SetColor("_EmissionColor", Color.red);
        //rend.material.SetFloat("_EmissionLevel", 1);
        rend.material.SetColor("_Color", Color.red);
        //Debug.Log("new color = " + rend.material.GetColor("_EmissionColor"));
        
        yield return new WaitForSeconds(.25f);
        rend.material.SetColor("_Color", oldColor);
        //rend.material.SetFloat("_EmissionLevel", 0);
        //rend.material.SetColor("_EmissionColor", oldColor);
        //rend.material.DisableKeyword("_EmissionColor");
    }

    public void ChangeScale(float scale)
    {
        float s = rb.transform.localScale.x;
        s += (scale / 10);
        rb.transform.localScale = new Vector3(s, s, s);

        if (s <= .2)
            gameController.GameOver(false);
        if (s >= 5)
            gameController.GameOver(true);
    }
}
