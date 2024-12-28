using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            //todo make it better
            SceneManager.LoadScene(1);
        });

        optionsButton.onClick.AddListener(() =>
        {
            Debug.Log("Options Button");
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
