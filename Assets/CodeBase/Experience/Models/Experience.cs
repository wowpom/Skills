using System;

namespace CodeBase.Experience.Models
{
    public class Experience : IExperience
    {
        public event Action<int> OnExperienceCountChanged = delegate {  };
        public int ExperienceCount => _experienceCount;

        private int _experienceCount = 0;

        public bool TryTake(int value)
        {
            if (_experienceCount - value >= 0)
            {
                _experienceCount -= value;
                OnExperienceCountChanged(_experienceCount);
                return true;
            }

            return false;
        }

        public void Add(int value)
        {
            _experienceCount += value;
            OnExperienceCountChanged(_experienceCount);
        }
    }
}