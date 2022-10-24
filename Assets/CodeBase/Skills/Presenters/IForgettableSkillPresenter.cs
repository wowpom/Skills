using System;

namespace CodeBase.Skills.Presenters
{
    public interface IForgettableSkillPresenter : IStudiedSkillPresenter
    {
        event Action OnForget;
        
        void Forget();
    }
}