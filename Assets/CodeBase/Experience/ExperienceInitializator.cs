using System;
using CodeBase.Experience.Presenters;
using CodeBase.Experience.Views;
using CodeBase.UserInterface;
using UnityEngine;

namespace CodeBase.Experience
{
    public class ExperienceInitializator : MonoBehaviour, IExperiencePresenterContainer
    {
        private IExperiencePresenter _experiencePresenter;
        public IExperiencePresenter ExperiencePresenter => _experiencePresenter;
        
        [SerializeField] private ExperienceView experienceView;
        [SerializeField] private AddingExperienceButton addingExperienceButton;

        private void Awake()
        {
            _experiencePresenter = new ExperiencePresenter(new Models.Experience(), experienceView);
            addingExperienceButton.SetExperiencePresenter(_experiencePresenter);
        }

    }
}