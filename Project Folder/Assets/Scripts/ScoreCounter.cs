using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    bool hasGameEnded = false;

    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        Player.Instance.OnGameOver += Player_OnGameEndEvent;
    }

    private void Player_OnGameEndEvent(object sender, System.EventArgs e)
    {
        hasGameEnded = true;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(hasGameEnded) return;
        
        scoreText.text = Player.Instance.getScore().ToString();
    } 
}
