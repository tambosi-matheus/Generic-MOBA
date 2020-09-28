using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : BaseSkill
{
    public Animator anim;
    public Transform hitPosition, feedbackPosition;
    public float hitbox;
    public float duration;
    public LayerMask skillLayer;
    public GameObject feedback;

    public Kick(GameObject obj) : base() 
    {
        cooldown = 5;
        anim = obj.GetComponentInChildren<Animator>();
        PlayerController player = obj.GetComponent<PlayerController>();
        hitPosition = player.kickHitPosition;
        feedbackPosition = player.kickFeedbackPosition;
        feedback = player.kickFeedback;
        hitbox = player.kickHitbox;
        skillLayer = player.kickLayer;

    }
    public override void OnSkillPressed()
    {
        if (cooldown > 0)
        {
            CastSkill();
        }
    }

    public override void CastSkill()
    {
        anim.SetTrigger("kick");
        GameObject obj = Util.Instantiate(feedback, feedbackPosition.position, feedbackPosition.rotation);
        obj.transform.Rotate(new Vector3(0, 180, 0));

        Collider[] coll = Physics.OverlapSphere(hitPosition.position, hitbox, skillLayer);

        Debug.Log("Hit " + coll.Length + " enemies");
        if (coll.Length > 0)
        { 

            foreach (Collider enemy in coll)
            {                
                enemy.GetComponent<Dummy>().Hit();    
            }
        }
    }
}
