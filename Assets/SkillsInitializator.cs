using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Skills;
using UnityEngine;

public class SkillsInitializator : MonoBehaviour
{
    [SerializeField] private List<DynamicSkillView> _skillViews = new List<DynamicSkillView>();
    private ISkill _baseSkill;
    private List<ISkill> _skills = new List<ISkill>();


    private void Awake()
    {
        _baseSkill = new Skill("0");

        _skills.Add(new DynamicSkill("1", 200, new List<ISkill>( { _baseSkill }));
    }
}
