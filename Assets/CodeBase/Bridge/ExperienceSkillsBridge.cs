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
        [SerializeField] private ExperiencePresenterContainer experiencePresenterContainer;
        [SerializeField] private PresenterContainer skillPresenterContainer;
        [SerializeField] private SkillsDependenciesContainer skillsDependenciesContainer;

        private void Start()
        {
            buttonsHandler.OnForgetRequest += OnForgetRequestHandle;
            buttonsHandler.OnStudyRequest += OnStudyRequestHandle;
            buttonsHandler.OnForgetAllRequest += OnForgetAllRequest;
        }

        private void OnDestroy()
        {
            buttonsHandler.OnForgetRequest -= OnForgetRequestHandle;
            buttonsHandler.OnStudyRequest -= OnStudyRequestHandle;
            buttonsHandler.OnForgetAllRequest -= OnForgetAllRequest;
        }

        private void OnForgetAllRequest()
        {
            foreach (var skillPresenter in skillPresenterContainer.SkillPresenters)
            {
                if (skillPresenter is IForgettableSkillPresenter { IsStudy: true } forgettableSkillPresenter)
                {
                    forgettableSkillPresenter.Forget();
                    experiencePresenterContainer.ExperiencePresenter.Add(forgettableSkillPresenter.Cost);
                }
            }
        }

        private void OnStudyRequestHandle(ISkillPresenter skillPresenter)
        {
            if (!(skillPresenter is IStudiedSkillPresenter studiedSkillPresenter))
                return;

            if (!skillsDependenciesContainer.GetPossibleStudySkill(studiedSkillPresenter.Id))
                return;
            
            if(!experiencePresenterContainer.ExperiencePresenter.TryTake(studiedSkillPresenter.Cost))
                return;
            
            ((IStudiedSkillPresenter)skillPresenterContainer.GetPresenterBySkillId(studiedSkillPresenter.Id)).Study();
        }

        private void OnForgetRequestHandle(ISkillPresenter skillPresenter)
        {
            if(!(skillPresenter is IForgettableSkillPresenter forgettableSkillPresenter))
                return;
            if (!skillsDependenciesContainer.GetPossibleForgetSkill(forgettableSkillPresenter.Id))
                return;

            experiencePresenterContainer.ExperiencePresenter.Add(forgettableSkillPresenter.Cost);
            forgettableSkillPresenter.Forget();
        }
    }
}