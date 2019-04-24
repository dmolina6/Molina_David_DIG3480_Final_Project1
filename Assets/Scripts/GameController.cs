using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] Hazards;
    public GameObject Double;
    public GameObject Triple;
    public Vector3 spawnvalues;
    public int Hazardcount;
    public float spawnwait;
    public float startwait;
    public float wavewait;
    public int score;
    public Text Scoretext;
    public Text restarttext;
    public Text gameovertext;
    public Text hardmodetext;
    private bool gameOver;
    private bool restart;
    private bool alreadyplayed;
    public bool hardmode;
    public AudioSource audiosource;
    public AudioClip backgroundclip;
    public AudioClip winclip;
    public AudioClip loseclip;    


    void Start()
    {
        audiosource.clip = backgroundclip;
        audiosource.Play();
        gameOver = false;
        restart = false;
        alreadyplayed = false;
        hardmode = false;
        restarttext.text = "";
        hardmodetext.text = "";
        gameovertext.text = "";        
        score = 0;
        UpdateScore();
        StartCoroutine (Spawnwaves());               
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                hardmode = false;
                SceneManager.LoadScene("SampleScene");
                audiosource.clip = backgroundclip;
                audiosource.Play();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                hardmode = true;
                SceneManager.LoadScene("SampleScene");
                audiosource.clip = backgroundclip;
                audiosource.Play();
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    IEnumerator Spawnwaves ()
    {
        yield return new WaitForSeconds(startwait);
        while(true)
        {
            for (int i = 0; i <= Hazardcount; i++)
            {
                GameObject hazard = Hazards[Random.Range (0,Hazards.Length)];
                Vector3 spawnposition = new Vector3(Random.Range(-spawnvalues.x, spawnvalues.x), spawnvalues.y, spawnvalues.z);
                Quaternion spawnrotation = Quaternion.identity;
                Instantiate(hazard, spawnposition, spawnrotation);
                yield return new WaitForSeconds(spawnwait);
            }

            yield return new WaitForSeconds(wavewait);
            if (gameOver)
            {
                restarttext.text = "Press 'M' for Restart";
                hardmodetext.text = "Press 'H' for Hard Mode";
                restart = true;
                break;
            }
            
        }
        
    }

    public void AddScore (int newScorevalue)
    {
        score += newScorevalue;
        UpdateScore();
    }

    void UpdateScore()
    {
        Scoretext.text = "Points: " + score;
        if (score == 50)
        {
            
        }
        if (score == 100)
        {

        }
        if (score >= 100 && alreadyplayed == false)
        {
            gameovertext.text = "You win! Game created by David Molina";
            gameOver = true;
            restart = true;
            audiosource.clip = winclip;
            audiosource.Play();
            alreadyplayed = true;            
        }
    }

    public void Gameover()
    {
        if (score >= 100)
        {
            return;
        }
        gameovertext.text = "Game Over; Game created by David Molina";
        gameOver = true;
        audiosource.clip = loseclip;
        audiosource.Play();
    }
}
