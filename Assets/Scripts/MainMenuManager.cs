using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public AudioSource clickSound;
    public void StartGame()
    {
        clickSound.Play();
        SceneManager.LoadScene("GameScene");
    }

    public void ShowHowToPlay()
    {
        clickSound.Play();
        howToPlayPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        clickSound.Play();
        howToPlayPanel.SetActive(false);
    }

    public void QuitGame()
    {
        clickSound.Play();
        Application.Quit();
    }
}