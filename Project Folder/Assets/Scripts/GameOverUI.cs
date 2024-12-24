using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjects;
    [SerializeField] TextMeshProUGUI scoreText;
    private void Start()
    {
        Player.Instance.OnGameOver += Player_OnGameOverEvent;
        foreach (GameObject item in gameObjects)
        {
            item.SetActive(false);
        }

    }

    private void Player_OnGameOverEvent(object sender, System.EventArgs e)
    {
        foreach (GameObject item in gameObjects)
        {
            item.SetActive(true);
        }
        scoreText.text = Player.Instance.getScore().ToString();
    }
}
