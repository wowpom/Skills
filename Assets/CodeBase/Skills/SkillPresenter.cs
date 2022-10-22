namespace CodeBase.Skills
{
    public class SkillPresenter : ISkillPresenter
    {
        private readonly ISkill _skill;
        private readonly ISkillView _skillView;

        public SkillPresenter(ISkill skill, ISkillView skillView)
        {
            _skill = skill;
            _skillView = skillView;
        }
        
        public void Dispose()
        {
            
        }
    }
}