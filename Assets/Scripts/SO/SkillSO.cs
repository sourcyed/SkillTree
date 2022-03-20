using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill", fileName = "New Skill")]
public class SkillSO : ScriptableObject
{
    public bool isLocked = true;
    public bool canBeUnlocked = false;
    public SkillSO[] requiredSkills;

    public void Unlock()
    {
        isLocked = false;
    }
}

