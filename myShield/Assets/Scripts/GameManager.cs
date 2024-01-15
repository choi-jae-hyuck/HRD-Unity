using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject square;
    public Text timeText;
    float alive = 0f;

    public Text bestScoreTxt;
    public Text thisScoreTxt;
    public GameObject endPanel;
    bool isRunning = true;

    public Animator anim;


    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("makeSquare", 0.0f, 0.5f);  
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            alive += Time.deltaTime;
            timeText.text = alive.ToString("N2");
        }
    }

    void makeSquare()
    {
        Instantiate(square);
    }

    public void gameOver()
    {
        anim.SetBool("isDie", true);

        isRunning = false;
        Invoke("timeStop", 0.5f);
        thisScoreTxt.text = alive.ToString("N2");
        endPanel.SetActive(true);

        if (PlayerPrefs.HasKey("bestScore") == false)
        {
            PlayerPrefs.SetFloat("bestScore", alive);
        }
        else
        {
            if (PlayerPrefs.GetFloat("bestScore") < alive)
            {
                PlayerPrefs.SetFloat("bestScore", alive);
            }
        }
        bestScoreTxt.text = PlayerPrefs.GetFloat("bestScore").ToString("N2");
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    void timeStop()
    {
        Time.timeScale = 0.0f;
    }

}
