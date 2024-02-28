using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    int playerScore = 0;
    int enemyScore = 0;

    [SerializeField] TextMeshProUGUI playerText;
    [SerializeField] TextMeshProUGUI enemyText;

    private void Update()
    {
        playerText.text = playerScore.ToString();
        enemyText.text = enemyScore.ToString();
    }

    public void PlayerScored()
    {
        playerScore += 1;
        ResetPosition();
    }

    public void EnemyScored()
    {
        enemyScore += 1;
        ResetPosition();
    }

    void ResetPosition()
    {
        ball.GetComponent<Ball>().ResetPosition();
        player.GetComponent<Player>().ResetPosition();
        enemy.GetComponent<Player>().ResetPosition();
    }
}
