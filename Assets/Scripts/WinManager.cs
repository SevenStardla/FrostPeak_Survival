using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Goal;

public class WinManager : MonoBehaviour
{
    public TMP_Text survivalTimeText;
    public AudioSource clickSound;

    private void Start()
    {
        survivalTimeText.text =
            "생존 시간 : " +
            GameData.survivalTime.ToString("F0") +
            "초";
    }

    public void RestartGame()
    {
        clickSound.Play();
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMainMenu()
    {
        clickSound.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        clickSound.Play();
        Application.Quit();
    }
}