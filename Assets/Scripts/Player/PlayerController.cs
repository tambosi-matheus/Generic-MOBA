using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask clickMask;

    //(Basic Attack) Punch

    //(Q) Kick
    public LayerMask kickLayer;
    public Transform kickHitPosition;
    public GameObject kickFeedback;
    public Transform kickFeedbackPosition;
    public float kickHitbox;
    

    //(W)


    //(E) Roll


    //(R)

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        var skills = new Dictionary<Type, BaseSkill>()
        {
            {typeof(Kick), new Kick(gameObject)}
        };

        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(FreeState), new FreeState(gameObject, clickMask, skills) }
        };
        GetComponent<StateMachine>().SetStates(states);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(kickHitPosition.position, kickHitbox);
    }
}
