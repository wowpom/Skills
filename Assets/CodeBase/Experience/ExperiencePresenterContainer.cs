using CodeBase.Experience.Presenters;
using UnityEngine;

namespace CodeBase.Experience
{
    public class ExperiencePresenterContainer : MonoBehaviour, IExperiencePresenterContainer
    {
        public IExperiencePresenter ExperiencePresenter => _experiencePresenter;
        private IExperiencePresenter _experiencePresenter;

        public void SetExperiencePresenter(IExperiencePresenter experiencePresenter) => 
            _experiencePresenter = experiencePresenter;
    }
}
