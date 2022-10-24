using System;
using CodeBase.Skills.Models;
using CodeBase.Skills.Views;

namespace CodeBase.Skills.Presenters
{
    public class DynamicSkillPresenter : IForgettableSkillPresenter
    {
        public event Action OnStudy = delegate { };
        public event Action OnForget = delegate { };

        public string Id => _forgettableSkill.Id;
        public bool IsStudy => _forgettableSkill.IsStudy;
        public int Cost => _forgettableSkill.Cost;
        
        private readonly IForgettableSkill _forgettableSkill;
        private readonly IDynamicSkillView _skillView;

        public DynamicSkillPresenter(IForgettableSkill forgettableSkill, IDynamicSkillView skillView)
        {
            _forgettableSkill = forgettableSkill;
            _skillView = skillView;
            
            _forgettableSkill.OnForget += OnForgetHandle;
            _forgettableSkill.OnStudy += OnStudyHandle;
        }

        ~DynamicSkillPresenter()
        {
            _forgettableSkill.OnForget -= OnForgetHandle;
            _forgettableSkill.OnStudy -= OnStudyHandle;
        }
        
        public void Study() => 
            _forgettableSkill.Study();


        public void Forget() => 
            _forgettableSkill.Forget();
        
        private void OnStudyHandle()
        {
            _skillView.SetStudiedView();
            OnStudy();
        }

        private void OnForgetHandle()
        {
            _skillView.SetAvailableView();
            OnForget();
        }
    }
}
