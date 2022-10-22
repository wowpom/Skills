using System;

namespace CodeBase.Skills
{
    public interface IStudiedSkill : ISkill
    {
        event Action OnStudy;
        
        bool IsStudy { get; }

        int GetCost();

        bool GetIsPossibleStudy();

        void Study();
    }
}