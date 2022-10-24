using System;

namespace CodeBase.Experience.Models
{
    public interface IExperience
    {
        event Action<int> OnExperienceCountChanged; 

        int ExperienceCount { get; }
        
        bool TryTake(int value);
        void Add(int value);
    }
}