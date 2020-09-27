using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Animator anim;

    public void Hit()
    {
        anim.SetTrigger("hit1");
    }
}
