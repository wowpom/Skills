using System;

namespace CodeBase.Skills
{
    public interface IForgettableSkill : IStudiedSkill
    {
        event Action OnForget;
        
        void Forget();
    }
}