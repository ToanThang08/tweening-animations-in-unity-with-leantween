
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager PrivateInstance;
    static public GameManager Instance { get { return PrivateInstance; } }

    public bool gameStarted = false;
    public TextMeshProUGUI scoreDisplay;
    public GameObject Cog;
    public GameObject Paddle;

    private int gameScore = 0;

    private void Awake()
    {
        if (PrivateInstance != null && PrivateInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            PrivateInstance = this;
        }
    }

    public void IncreaseScore(int value)
    {
        gameScore += value;
        scoreDisplay.text = gameScore.ToString();

        // 1
        LeanTween.cancel(scoreDisplay.gameObject);
        scoreDisplay.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        scoreDisplay.transform.localScale = Vector3.one;

        // 2
        LeanTween.rotateZ(scoreDisplay.gameObject, 15.0f, 0.5f).setEasePunch();
        LeanTween.scaleX(scoreDisplay.gameObject, 1.5f, 0.5f).setEasePunch();
    }

    public void ResetGame()
    {
        Cog.GetComponent<Rigidbody2D>().position = Vector2.zero;
        Cog.GetComponent<Rigidbody2D>().velocity = Vector2.down * BallScript.BallSpeed;
        Paddle.GetComponent<Rigidbody2D>().position = new Vector2(0, -4);

    }
}
