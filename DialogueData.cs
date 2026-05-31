using System;

[Serializable]
public class DialogueData
{
    public string npcLine;
    public string[] choices;
    public string[] responses;
    public string[] memoryEventNames;
    public int[] scoreChanges;

    public DialogueData(
        string npcLine,
        string[] choices,
        string[] responses,
        string[] memoryEventNames,
        int[] scoreChanges)
    {
        this.npcLine = npcLine;
        this.choices = choices;
        this.responses = responses;
        this.memoryEventNames = memoryEventNames;
        this.scoreChanges = scoreChanges;
    }
}