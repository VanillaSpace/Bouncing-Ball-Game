using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public Text scoreTxt;
    private int scoreboard = 0;
    public string preTextScore = "Score: ";
    private string scoreTx = "0";
    public int pointsPerBounce = 35;
    
    public ParticleSystem deathParts;

    public GameObject btnExit;
    public GameObject btnRetry;

    private AudioSource audioBall;

    private string sceneToReload = "Game";
    

    public float minTranslation = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        audioBall = GetComponent<AudioSource>();
        btnExit.SetActive(false);
        btnRetry.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 colPos = collision.transform.position;
        Rigidbody rigid = GetComponent<Rigidbody>();
    
        if (collision.gameObject.tag == "paddle")
        {
            float diffx = minTranslation + (colPos.x - transform.position.x) * Random.Range(1, 10);
            float diffz = minTranslation + (colPos.z - transform.position.z) * Random.Range(1, 10);

            rigid.velocity = new Vector3(-diffx, 8, -diffz);
            Debug.Log("x: "+ diffx+" z: "+ diffz);
            AddScore();

            scoreTxt.text = preTextScore + scoreTx;
                    IncreaseDifficulty();
                    audioBall.Play();
        }
         else
            {
                  // Game over
                 deathParts.transform.position = transform.position;
                 GetComponent<TrailRenderer>().enabled = false;
                 transform.position = new Vector3(-1000, -1000);
                 Time.timeScale = 1.0f;
                 deathParts.Play();

                 btnExit.SetActive(true);
                 btnRetry.SetActive(true);

                 Cursor.lockState = CursorLockMode.None;
                 Cursor.visible = true;
                 deathParts.GetComponent<AudioSource>().Play();
            }
    }

    void AddScore()
    {
        scoreboard += pointsPerBounce;
        scoreTx = scoreboard.ToString();
    }
}
