using System;

namespace CodeBase.Skills.Models
{
    public interface IForgettableSkill : IStudiedSkill
    {
        event Action OnForget;
        
        void Forget();
    }
}