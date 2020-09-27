using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill
{
    public float cooldown { protected set; get; }

    public abstract void OnSkillPressed();
    public abstract void CastSkill();
}

