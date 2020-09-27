using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAnimController: MonoBehaviour
{
    public NavMeshAgent agent;

    public void PauseAgent()
    {
        agent.isStopped = true;
    }
    public void ResumeAgent()
    {
        //player.playerState = PlayerController.PlayerStates.FREE;
        agent.isStopped = false;
    }

    public void SkillHitbox()
    {
        //player.CastQ();
    }
}
