using System;
using CodeBase.Experience;
using CodeBase.Skills;
using CodeBase.Skills.Presenters;
using CodeBase.UserInterface;
using UnityEngine;

namespace CodeBase.Bridge
{
    public class ExperienceSkillsBridge: MonoBehaviour
    {
        [SerializeField] private ButtonsHandler buttonsHandler;
        [SerializeField] private ExperienceInitializator experienceInitializator;
        [SerializeField] private SkillsInitializator skillsInitializator;
        [SerializeField] private SkillsDependenciesContainer skillsDependenciesContainer;

        private void Start()
        {
            buttonsHandler.OnForgetRequest += OnForgetRequestHandle;
            buttonsHandler.OnStudyRequest += OnStudyRequestHandle;
            buttonsHandler.OnForgetAllRequest += OnForgetAllRequest;
        }

        private void OnForgetAllRequest()
        {
            foreach (var skillPresenter in skillsInitializator.SkillPresenters)
            {
                if (skillPresenter is IForgettableSkillPresenter forgettableSkillPresenter)
                {
                    forgettableSkillPresenter.Forget();
                    experienceInitializator.ExperiencePresenter.Add(forgettableSkillPresenter.Cost);
                }
            }
        }

        private void OnStudyRequestHandle(ISkillPresenter skillPresenter)
        {
            if (!(skillPresenter is IStudiedSkillPresenter studiedSkillPresenter))
                return;

            if (!skillsDependenciesContainer.GetPossibleStudySkill(studiedSkillPresenter.Id))
                return;
            
            if(!experienceInitializator.ExperiencePresenter.TryTake(studiedSkillPresenter.Cost))
                return;
            
            ((IStudiedSkillPresenter)skillsInitializator.GetPresenterBySkillId(studiedSkillPresenter.Id)).Study();
        }

        private void OnForgetRequestHandle(ISkillPresenter skillPresenter)
        {
            if(!(skillPresenter is IForgettableSkillPresenter forgettableSkillPresenter))
                return;
            if (!skillsDependenciesContainer.GetPossibleForgetSkill(forgettableSkillPresenter.Id))
                return;

            experienceInitializator.ExperiencePresenter.Add(forgettableSkillPresenter.Cost);
            forgettableSkillPresenter.Forget();
        }
    }
}