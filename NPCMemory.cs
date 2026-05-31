using System.Collections.Generic;
using UnityEngine;

public class NPCMemory : MonoBehaviour
{
    public int Score { get; private set; }

    private List<MemoryEvent> memoryEvents = new List<MemoryEvent>();

    public void AddMemoryEvent(string eventName, int scoreChange, int dialogueStage)
    {
        MemoryEvent newEvent = new MemoryEvent(
            eventName,
            scoreChange,
            Time.time,
            dialogueStage
        );

        memoryEvents.Add(newEvent);
        Score += scoreChange;

        Debug.Log("Memory Event: " + newEvent.eventName +
                  " | Impact: " + newEvent.impactValue +
                  " | Stage: " + newEvent.dialogueStage +
                  " | Time: " + newEvent.timestamp);

        Debug.Log("Current Score: " + Score);
    }

    public bool HasMemoryEvent(string eventName)
    {
        foreach (MemoryEvent memoryEvent in memoryEvents)
        {
            if (memoryEvent.eventName == eventName)
            {
                return true;
            }
        }

        return false;
    }
}