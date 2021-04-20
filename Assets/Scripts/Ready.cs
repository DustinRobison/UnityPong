using UnityEngine;

public class Ready : MonoBehaviour
{

    GameSession gameSession;
    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.anyKeyDown)
        {
            gameSession.SetStarted();
            gameObject.SetActive(false);
        }
    }
}
