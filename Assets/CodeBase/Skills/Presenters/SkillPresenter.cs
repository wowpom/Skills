using CodeBase.Skills.Models;
using CodeBase.Skills.Views;

namespace CodeBase.Skills.Presenters
{
    public class SkillPresenter : ISkillPresenter
    {
        public string Id => _skill.Id;

        private readonly ISkill _skill;
        private readonly ISkillView _skillView;

        public SkillPresenter(ISkill skill, ISkillView skillView)
        {
            _skill = skill;
            _skillView = skillView;
        }
        
        public void Select(bool isSelect) => 
            _skillView.Select(isSelect);
    }
}