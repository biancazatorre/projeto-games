using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float initiaSpeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text playerScore;
    [SerializeField] private Text AIScore;
    [SerializeField] private Text victoryMessage;
    [SerializeField] private int winningScore = 2;
    [SerializeField] private GameObject Telafimgame;

    private int hitCounter;
    private Rigidbody2D rb;
    [SerializeField] private bool isMultiplayer;
    private bool isPaused;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        victoryMessage.gameObject.SetActive(false); // Esconde a mensagem no início
        Invoke("startBall", 2f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Retoma o jogo
            }
            else
            {
                PauseGame("Jogo Pausado"); // Pausa o jogo
            }
        }
    }
    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initiaSpeed + (speedIncrease * hitCounter));
    }

    private void startBall()
    {
        rb.velocity = new Vector2(-1, 0) * (initiaSpeed + speedIncrease * hitCounter);
    }

    private void resetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        hitCounter = 0;
        Invoke("startBall", 2f);
    }

    private void PlayerBounce(Transform myObject)
    {
        hitCounter++;

        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float xDirection, yDirection;
        if (transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }

        yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        if (yDirection == 0)
        {
            yDirection = 0.25f;
        }
        rb.velocity = new Vector2(xDirection, yDirection) * (initiaSpeed + (speedIncrease * hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI") 
        {
            PlayerBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0) 
        {
            playerScore.text = (int.Parse(playerScore.text) + 1).ToString();
            CheckWinCondition();
            resetBall();
        }
        else if (transform.position.x < 0)
        {
            AIScore.text = (int.Parse(AIScore.text) + 1).ToString();
            CheckWinCondition();
            resetBall();
        }
    }
    private void CheckWinCondition()
    {
        int playerPoints = int.Parse(playerScore.text);
        int aiPoints = int.Parse(AIScore.text);

        if (isMultiplayer)
        {
            // Verifica se algum dos jogadores no modo multiplayer atingiu a pontuação necessária
            if (playerPoints >= winningScore)
            {
                ShowVictoryMessage("Player 1 venceu!");
            }
            else if (aiPoints >= winningScore)
            {
                ShowVictoryMessage("Player 2 venceu!");
            }
        }
        else
        {
            // Verifica as condições no modo single player contra a IA
            if (playerPoints >= winningScore)
            {
                ShowVictoryMessage("Você ganhou!");
            }
            else if (aiPoints >= winningScore)
            {
                ShowVictoryMessage("Você perdeu!");
            }
        }
    }
    private void ShowVictoryMessage(string message)
    {
        victoryMessage.text = message;
        Telafimgame.SetActive(true);
        victoryMessage.gameObject.SetActive(true); // Exibe a mensagem de vitória
        Time.timeScale = 0;
    }

    private void PauseGame(string message)
    {
        isPaused = true;
        victoryMessage.text = message;
        Telafimgame.SetActive(true);
        victoryMessage.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    private void ResumeGame()
    {
        isPaused = false;
        Telafimgame.SetActive(false);
        Time.timeScale = 1; // Retoma o jogo
    }
}