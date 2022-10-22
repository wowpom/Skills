using System;
using System.Collections.Generic;

namespace CodeBase.Skills
{
    public class DynamicSkill : Skill, IForgettableSkill
    {
        public event Action OnStudy;
        public event Action OnForget;

        public bool IsStudy => _isStudy;
        private bool _isStudy = false;
        
        private readonly int _cost;
        private readonly List<ISkill> _dependentSkills;


        public DynamicSkill(string id, int cost, List<ISkill> dependentSkills) : base(id)
        {
            _cost = cost;
            _dependentSkills = dependentSkills;
        }

        public void Forget()
        {
            _isStudy = false;
            OnForget();
        }
        
        public void Study()
        {
            _isStudy = true;
            OnStudy();
        }

        public int GetCost() =>
            _cost;

        public bool GetIsPossibleStudy()
        {
            for (int i = 0; i < _dependentSkills.Count; i++)
            {
                if (_dependentSkills[i] is IStudiedSkill skill)
                {
                    if (skill.IsStudy)
                        return true;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}