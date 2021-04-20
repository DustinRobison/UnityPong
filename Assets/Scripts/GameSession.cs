using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] Canvas endCanvas;
    [SerializeField] TextMeshProUGUI endText;

    // Game state
    bool started, lose, win = false;
    Ball ball;


    private void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        endCanvas.gameObject.SetActive(false);
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

   public void SetStarted()
    {
        started = true;
        ball.LaunchOnStart();
    }

    public bool GetPlaying()
    {
        return started == true && lose == false && win == false;
    }

    public void SetLost()
    {
        ball.StopMovement();
        endCanvas.gameObject.SetActive(true);
        lose = true;
        endText.text = "You Lost!";
    }

    public void SetWin()
    {
        ball.StopMovement();
        endCanvas.gameObject.SetActive(true);
        win = true;
        endText.text = "You Won!";
    }

    public void ResetGame()
    {
        // endCanvas.gameObject.SetActive(false);
        started = true;
        lose = false;
        win = false;
        // ball.ResetPosition();
    }

    public void GameStatusDestroy()
    {
        Destroy(gameObject);
    }
}
