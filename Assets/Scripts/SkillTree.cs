using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;
    private void Awake() => skillTree = this;

    public GameObject SkillHolder;

    List<Skill> SkillList = new List<Skill>();

    private void Start()
    {
        foreach (Skill skill in SkillHolder.GetComponentsInChildren<Skill>())
        {
            SkillList.Add(skill);
        }
        UpdateAllSkillUI();
    }

    public void CheckAllSkillDependencies()
    {
        foreach (Skill skill in SkillList)
        {
            skill.CheckDependencies();
        }
    }

    public void UpdateAllSkillUI()
    {
        CheckAllSkillDependencies();
        foreach (Skill skill in SkillList)
        {
            skill.UpdateUI();
        }
    }
}

