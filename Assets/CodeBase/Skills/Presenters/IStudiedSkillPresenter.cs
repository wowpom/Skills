using System;

namespace CodeBase.Skills.Presenters
{
    public interface IStudiedSkillPresenter : ISkillPresenter
    {
        event Action OnStudy;
        
        bool IsStudy { get; }

        int Cost { get; }
        void Study();
    }
}