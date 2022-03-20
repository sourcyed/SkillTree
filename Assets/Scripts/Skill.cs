using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static SkillTree;

public class Skill : MonoBehaviour
{
    [SerializeField] SkillSO skillSO;
    
    public TMP_Text lockStatusText;
    public TMP_Text titleText;

    public void CheckDependencies()
    {
        bool canBeUnlocked = true;
        foreach (SkillSO previousSkill in skillSO.requiredSkills)
        {
            if (previousSkill.isLocked)
            {
                canBeUnlocked = false;
                break;
            }
        }
        skillSO.canBeUnlocked = canBeUnlocked;
    }

    public void UpdateUI()
    {
        string lockStatus = !skillSO.isLocked ? "Unlocked" : skillSO.canBeUnlocked ? "Unlockable" : "Locked";
        lockStatusText.text = lockStatus;
        titleText.text = skillSO.name;

        GetComponent<Image>().color = !skillSO.isLocked ? Color.green : skillSO.canBeUnlocked ? Color.yellow : Color.white;
    }

    public void Buy()
    {
        if (!skillSO.canBeUnlocked || !skillSO.isLocked) return;
        
        skillSO.Unlock();
        skillTree.UpdateAllSkillUI();
    }
}

