using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreeState : BaseState
{
    private new GameObject gameObject;
    private Transform tranform;
    private NavMeshAgent agent;
    private Animator anim;
    private LayerMask clickMask;
    private Dictionary<Type, BaseSkill> skills;    
    public FreeState(GameObject obj, LayerMask clickMask, Dictionary<Type, BaseSkill> skills) : base(obj)
    {
        this.gameObject = obj;
        this.tranform = obj.transform;
        this.agent = obj.GetComponent<NavMeshAgent>();
        this.anim = obj.GetComponentInChildren<Animator>();
        this.clickMask = clickMask;
        this.skills = skills;
    }

    public override Type Tick()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("speed", speedPercent);

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 destination = Util.Instance.Click(50, clickMask);
            if (destination != Vector3.zero)
                agent.SetDestination(destination);

        }
        if (Input.GetKeyDown(KeyCode.Q))
            skills[typeof(Kick)].OnSkillPressed();

        if (Input.GetKeyDown(KeyCode.E))
        {
            agent.ResetPath();
            agent.SetDestination(Util.Instance.DashMovimentation(transform.position, 5));
            anim.SetTrigger("roll");

        }

        return null;
    }
}
