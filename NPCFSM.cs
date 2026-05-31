using UnityEngine;

public enum NPCState
{
    Neutral,
    Friendly,
    Suspicious
}

public class NPCFSM : MonoBehaviour
{
    public NPCState CurrentState { get; private set; } = NPCState.Neutral;

    public void UpdateState(int score)
    {
        if (score >= 6)
        {
            CurrentState = NPCState.Friendly;
        }
        else if (score >= 0)
        {
            CurrentState = NPCState.Neutral;
        }
        else
        {
            CurrentState = NPCState.Suspicious;
        }

        Debug.Log("NPC State: " + CurrentState);
    }
}