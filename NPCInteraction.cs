using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionText;
    public DialogueManager dialogueManager;

    private bool playerNearby = false;

    private void Start()
    {
        if (interactionText != null)
        {
            interactionText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            if (interactionText != null)
            {
                interactionText.SetActive(true);
            }

            Debug.Log("Press E to Talk");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;

            if (interactionText != null)
            {
                interactionText.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Conversation Started");

            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue();
            }
        }
    }
}