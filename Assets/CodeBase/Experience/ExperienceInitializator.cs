using System;
using CodeBase.Experience.Presenters;
using CodeBase.Experience.Views;
using CodeBase.UserInterface;
using UnityEngine;

namespace CodeBase.Experience
{
    public class ExperienceInitializator : MonoBehaviour
    {
        [SerializeField] private ExperienceView experienceView;
        [SerializeField] private AddingExperienceButton addingExperienceButton;
        [SerializeField] private ExperiencePresenterContainer experiencePresenterContainer;

        private void Awake()
        {
            experiencePresenterContainer.SetExperiencePresenter(new ExperiencePresenter(new Models.Experience(),
                experienceView));
            addingExperienceButton.SetExperiencePresenter(experiencePresenterContainer.ExperiencePresenter);
        }

    }
}