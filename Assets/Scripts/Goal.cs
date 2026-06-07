using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public static class GameData
    {
        public static float survivalTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("무언가 충돌");
        if (other.CompareTag("Player"))
        {
            PlayerController player =
                other.GetComponent<PlayerController>();
            Debug.Log("Goal 도착!");
            GameData.survivalTime = player.GetSurvivalTime();

            SceneManager.LoadScene("WinScene");
        }
    }
}