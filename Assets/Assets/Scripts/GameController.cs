using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameController : MonoBehaviour {

    private int score;
    private bool isGameOver = false;
    private AudioSource[] audio;

    [System.NonSerialized]
    public PlayerController player;
    public GameObject Hazard;
    public GUIText ScoreText;
    public int HazardCount;
    public int WaveWait;

    ///// <summary>
    ///// The <see cref="GameObject.tag"/> that refers to the object the player is supposed to target
    ///// </summary>
    //public string targetObjectTag;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        player = FindObjectOfType<PlayerController>();
        audio = GetComponents<AudioSource>();

        UpdateScore(0);
        StartCoroutine(SpawnHazard());
	}
	
    void Update()
    {
        if (Input.GetKeyDown("escape"))
            GameOver(true);
    }

    IEnumerator SpawnHazard()
    {
        while (!isGameOver)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                //Debug.Log("Making hazard #" + i);
                //var pos = new Vector3(player.transform.position.x + 20, player.transform.position.y, player.transform.position.z);

                Instantiate(Hazard, new Vector3(0, 0, 0), Quaternion.identity);
                //Debug.Log("Sleeping for " + WaveWait + " seconds.");
                yield return new WaitForSeconds(WaveWait);
            }
        }
    }

    public void UpdateScore(int points)
    {
        Debug.Log("Score: " + score);
        score += points;
        ScoreText.text = "Score: " + score;
    }

    public void ButtonFireClick()
    {
        if (!isGameOver)
            player.Fire();
        else
            Start();
    }

    public void ButtonJumpClick()
    {
        if (!isGameOver)
            player.Jump();
        else
            Start();
    }

    public void GameOver(bool wonGame)
    {
        isGameOver = true;

        switch(wonGame)
        {
            case true:
                audio[0].Play();
                break;
            default:
                audio[1].Play();
                break;
        }

        StartCoroutine(Restart(2));
    }

    IEnumerator Restart(int secondsUntilRestart)
    {
        yield return new WaitForSeconds(secondsUntilRestart);
        isGameOver = false;
        Application.LoadLevel(0);
    }
}
