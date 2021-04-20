using UnityEngine;

public class Ball : MonoBehaviour
{
  
    [SerializeField] float speedOfSpin = 720f;
    [SerializeField] float randomFactor = 0.2f;

    // State
    GameSession gameSession;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSession && gameSession.GetPlaying())
        {
            rotate();
        }
    }

    private void rotate()
    {
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }

    public void StopMovement()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(0, 0);
        LaunchOnStart();
    }

    public void LaunchOnStart()
    {
       rigidbody2D.velocity = new Vector2(Random.Range(5, 8), GetRandomXVel());
    }

    private float GetRandomXVel()
    {
        float randomValue = UnityEngine.Random.value;
        if (randomValue > 0.5)
        {
            // Ball goes up
            return Random.Range(5, 8);
        } else
        {
            return Random.Range(5, 8) * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            UnityEngine.Random.Range(0f, randomFactor),
            UnityEngine.Random.Range(0f, randomFactor));
    }
}
