using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI congratulations;
    public GameObject congratulationsGameObject;
    public bool isClap = false;

    public int player1Score = 0;
    public int player2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Disable text at the beginning of the game.
        congratulations.text = "";
        congratulationsGameObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If a player reaches to the 10 point clap that player.
        if (player1Score == 10 & isClap == false)
        {
            congratulationsGameObject.gameObject.SetActive(true);
            congratulations.text = "PLAYER 1 WON";
            isClap = true;
        }else if (player2Score == 10 & isClap == false)
        {
            congratulationsGameObject.gameObject.SetActive(true);
            congratulations.text = "PLAYER 2 WON";
            isClap = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the ball collide with the left or right walls increase the score according the wall.
        if (collision.gameObject == leftWall & isClap == false)
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
        }else if (collision.gameObject == rightWall & isClap == false)
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
        }
    }

    private void NextScene()
    {
        // I am planning to make end scene. This is way to go there.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
