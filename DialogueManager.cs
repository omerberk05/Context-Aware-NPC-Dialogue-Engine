using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public TMP_Text choiceText;
    public NPCMemory npcMemory;
    public NPCFSM npcFSM;

    private int currentStage = 0;
    private int selectedChoiceIndex = 0;

    private bool dialogueActive = false;
    private bool waitingForClose = false;

    private string[] currentChoices;
    private DialogueData currentDialogueData;
    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (!dialogueActive) return;

        if (waitingForClose)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                EndDialogue();
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            selectedChoiceIndex--;

            if (selectedChoiceIndex < 0)
                selectedChoiceIndex = currentChoices.Length - 1;

            UpdateChoiceText();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            selectedChoiceIndex++;

            if (selectedChoiceIndex >= currentChoices.Length)
                selectedChoiceIndex = 0;

            UpdateChoiceText();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ConfirmChoice();
        }
    }

    public void StartDialogue()
    {
        dialogueActive = true;
        waitingForClose = false;
        selectedChoiceIndex = 0;

        dialoguePanel.SetActive(true);

        if (currentStage == 0)
            ShowFirstInteraction();
        else if (currentStage == 1)
            ShowSecondInteraction();
        else
            ShowFinalInteraction();
    }

    private void ShowFirstInteraction()
    {
        currentDialogueData = new DialogueData(
            "NPC: Hello, traveler. I need help carrying some supplies. Can you help me?",
            new string[]
            {
            "Yes, I can help.",
            "No, I am busy."
            },
            new string[]
            {
            "NPC: Thank you. I appreciate your help.",
            "NPC: I understand. Maybe another time."
            },
            new string[]
            {
            "HelpedNPC",
            "RefusedHelp"
            },
            new int[]
            {
            5,
            -3
            }
        );

        dialogueText.text = currentDialogueData.npcLine;
        currentChoices = currentDialogueData.choices;

        UpdateChoiceText();
    }

    private void ShowSecondInteraction()
    {
        if (npcMemory.Score > 0)
        {
            currentDialogueData = new DialogueData(
                "NPC: Thanks for helping me earlier. I need assistance once again.",
                new string[]
                {
                "Of course, I will help again.",
                "Sorry, I cannot help this time."
                },
                new string[]
                {
                "NPC: Your support means a lot to me.",
                "NPC: I understand. Everyone has their own priorities."
                },
                new string[]
                {
                "HelpedAgain",
                "RefusedAfterHelping"
                },
                new int[]
                {
                4,
                -2
                }
            );
        }
        else
        {
            currentDialogueData = new DialogueData(
                "NPC: You refused to help me before. Have you changed your mind?",
                new string[]
                {
                "Yes, I will help this time.",
                "No, I still cannot help."
                },
                new string[]
                {
                "NPC: I'm glad you changed your mind.",
                "NPC: That is disappointing."
                },
                new string[]
                {
                "HelpedAfterRefusing",
                "RefusedAgain"
                },
                new int[]
                {
                4,
                -4
                }
            );
        }

        dialogueText.text = currentDialogueData.npcLine;
        currentChoices = currentDialogueData.choices;

        UpdateChoiceText();
    }

    private void ShowFinalInteraction()
    {
        waitingForClose = true;

        npcFSM.UpdateState(npcMemory.Score);

        if (npcFSM.CurrentState == NPCState.Friendly)
        {
            currentDialogueData = new DialogueData(
                "NPC: You have consistently helped me. I trust you and consider you a reliable friend.",
                new string[] { },
                new string[] { },
                new string[] { },
                new int[] { }
            );
        }
        else if (npcFSM.CurrentState == NPCState.Neutral)
        {
            currentDialogueData = new DialogueData(
                "NPC: I am still learning what kind of person you are, but I appreciate some of your actions.",
                new string[] { },
                new string[] { },
                new string[] { },
                new int[] { }
            );
        }
        else
        {
            currentDialogueData = new DialogueData(
                "NPC: I remember your decisions. It is difficult for me to trust you.",
                new string[] { },
                new string[] { },
                new string[] { },
                new int[] { }
            );
        }

        dialogueText.text = currentDialogueData.npcLine;
        choiceText.text = "F - Close";
    }

    private void UpdateChoiceText()
    {
        string displayText = "";

        for (int i = 0; i < currentChoices.Length; i++)
        {
            if (i == selectedChoiceIndex)
                displayText += "> " + currentChoices[i] + "\n";
            else
                displayText += "  " + currentChoices[i] + "\n";
        }

        choiceText.text = displayText;
    }

    private void ConfirmChoice()
    {
        if (currentStage == 0)
        {
            npcMemory.AddMemoryEvent(
                currentDialogueData.memoryEventNames[selectedChoiceIndex],
                currentDialogueData.scoreChanges[selectedChoiceIndex],
                currentStage
            );

            dialogueText.text = currentDialogueData.responses[selectedChoiceIndex];

            currentStage = 1;
        }
        else if (currentStage == 1)
        {
            npcMemory.AddMemoryEvent(
                currentDialogueData.memoryEventNames[selectedChoiceIndex],
                currentDialogueData.scoreChanges[selectedChoiceIndex],
                currentStage
            );

            dialogueText.text = currentDialogueData.responses[selectedChoiceIndex];

            currentStage = 2;
        }

        choiceText.text = "F - Close";
        waitingForClose = true;
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueActive = false;
        waitingForClose = false;
    }
}