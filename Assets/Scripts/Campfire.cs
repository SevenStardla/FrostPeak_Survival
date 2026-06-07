using UnityEngine;

public class Campfire : MonoBehaviour
{
    public float healRate = 15f;

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerController player =
                other.GetComponent<PlayerController>();

            player.temperature +=
                healRate * Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>()
                 .isNearCampfire = false;
        }
    }
}