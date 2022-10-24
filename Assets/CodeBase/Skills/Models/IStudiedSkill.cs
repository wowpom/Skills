using System;

namespace CodeBase.Skills.Models
{
    public interface IStudiedSkill : ISkill
    {
        event Action OnStudy;
        
        bool IsStudy { get; }

        int Cost { get; set; }

        void Study();
    }
}