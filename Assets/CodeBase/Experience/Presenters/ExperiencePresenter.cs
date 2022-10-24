using CodeBase.Experience.Models;
using CodeBase.Experience.Views;

namespace CodeBase.Experience.Presenters
{
    public class ExperiencePresenter : IExperiencePresenter
    {
        private readonly IExperience _experience;
        
        private readonly IExperienceView _experienceView;
        
        public void Add(int valueExp) => 
            _experience.Add(valueExp);

        public bool TryTake(int value) => 
            _experience.TryTake(value);

        public ExperiencePresenter(IExperience experience, IExperienceView experienceView)
        {
            _experience = experience;
            _experienceView = experienceView;
            _experience.OnExperienceCountChanged += _experienceView.SetView;
            _experienceView.Init(_experience.ExperienceCount);
        }

        ~ExperiencePresenter() => 
            _experience.OnExperienceCountChanged -= _experienceView.SetView;
    }
}