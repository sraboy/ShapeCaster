using UnityEngine;
using System.Collections;

public class HazardController : MonoBehaviour {

    private GameController gameController;
    private AudioSource[] audio;

    public GameObject Alive;
    public GameObject Dead;

    void Start ()
    {
        gameController = FindObjectOfType<GameController>();
        
        Alive = Instantiate(Alive, new Vector3(7,1,0), Quaternion.identity) as GameObject; //new Quaternion(0, 0, 180, 0)
        Alive.GetComponent<ChickenController>().HazardController = this;
        //Debug.Log("Created Alive with HC: " + Alive.GetComponent<ChickenController>().HazardController);
        audio = GetComponents<AudioSource>();
    }

    public void ProcessTriggerEnter(GameObject sender, Collider other)
    {
        ProcessTriggerEnter(sender, other, null);
    }

    public void ProcessTriggerEnter(GameObject sender, Collider other, System.Action callback)
    {
        //Debug.Log("Hazard collision detected between: " + sender + " and " + other);

        if (sender.Equals(Alive))
        {
            if (other.tag.Equals("SpellCast"))
            {
                //Debug.Log("Hazard destroyed by SpellCast.");
                //gameController.UpdateScore(1);
                Destroy(other.gameObject);
                Vector3 loc = Alive.gameObject.transform.position;
                Quaternion rot = Alive.gameObject.transform.rotation;
                Destroy(Alive);
                MakeDead(loc, rot);
                audio[0].Play();
            }
            else if (other.tag.Equals("Player"))
            {
                gameController.UpdateScore(-2);
                //Debug.Log("About to launch coroutine...");
                StartCoroutine(gameController.player.TakeDamage());
            }
        }
        else if (sender.Equals(Dead))
        {
            if (other.tag.Equals("SpellCast"))
            {
                return;
            }
            else if (other.tag.Equals("Player"))
            {
                gameController.UpdateScore(2);
                gameController.player.ChangeScale(3);
                Destroy(Dead);
            }
        }


        if (callback != null)
            callback();
    }

    private void MakeDead(Vector3 loc, Quaternion rot)
    {
        Dead = Instantiate(Dead, loc, rot) as GameObject;
        Dead.GetComponent<ChickenController>().HazardController = this;
        //Debug.Log("Created Dead with HC: " + Dead.GetComponent<ChickenController>().HazardController + " at " + loc);
    }
}
