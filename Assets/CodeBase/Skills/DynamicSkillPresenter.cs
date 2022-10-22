using UnityEngine;

namespace CodeBase.Skills
{
    public class DynamicSkillPresenter : MonoBehaviour, ISkillPresenter
    {
        private readonly IForgettableSkill _forgettableSkill;
        private readonly IDynamicSkillView _skillView;

        public DynamicSkillPresenter(IForgettableSkill forgettableSkill, IDynamicSkillView skillView)
        {
            _forgettableSkill = forgettableSkill;
            _skillView = skillView;

            _forgettableSkill.OnForget += _skillView.SetAvailableView;
            _forgettableSkill.OnStudy += _skillView.SetStudiedView;
        }
    
        public void Dispose()
        {
            _forgettableSkill.OnForget -= _skillView.SetAvailableView;
            _forgettableSkill.OnStudy -= _skillView.SetStudiedView;
        }
    }
}
