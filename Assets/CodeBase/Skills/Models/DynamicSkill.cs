using System;
using System.Collections.Generic;

namespace CodeBase.Skills.Models
{
    public class DynamicSkill : Skill, IForgettableSkill
    {
        public event Action OnStudy;
        public event Action OnForget;

        public int Cost { get; set; }
        public bool IsStudy => _isStudy;
        private bool _isStudy = false;

        public DynamicSkill(string id, int cost) : base(id) => 
            Cost = cost;

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
    }
}