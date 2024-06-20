using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CountDownTimer countDownTimer;
    public PlayerHPBar playerHPBar;
    public GoalDetector goalDetector;

    public GameObject gameOverPanel;
    public GameObject gameClearPanel;
    public GameObject playerCanvas;

    [SerializeField] AudioClip gameOverBGM;
    [SerializeField] AudioClip gameOverVoice;

    private AudioSource audioSource;

    int i = 1;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (((countDownTimer.isTimeOver) || (playerHPBar.isZeroHP)) && goalDetector.isGoal != true)
        {
            if (i == 1)
            {
                audioSource.PlayOneShot(gameOverBGM);
                audioSource.PlayOneShot(gameOverVoice);



            }

            gameOverPanel.SetActive(true);
            playerCanvas.SetActive(false);
            i++;
        }
        if(((countDownTimer.isTimeOver) || (playerHPBar.isZeroHP)) != true && goalDetector.isGoal == true)
        {
            Debug.Log("ÉQÅ[ÉÄÉNÉäÉA");
            gameClearPanel.SetActive(true);
            playerCanvas.SetActive(false);

        }

    

    }
}
