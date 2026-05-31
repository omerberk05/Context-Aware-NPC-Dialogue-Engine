using System;

[Serializable]
public class MemoryEvent
{
    public string eventName;
    public int impactValue;
    public float timestamp;
    public int dialogueStage;

    public MemoryEvent(string eventName, int impactValue, float timestamp, int dialogueStage)
    {
        this.eventName = eventName;
        this.impactValue = impactValue;
        this.timestamp = timestamp;
        this.dialogueStage = dialogueStage;
    }
}