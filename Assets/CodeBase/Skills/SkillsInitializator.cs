using System.Collections.Generic;
using CodeBase.Skills.Models;
using CodeBase.Skills.Presenters;
using CodeBase.Skills.Views;
using CodeBase.UserInterface;
using UnityEngine;

namespace CodeBase.Skills
{
    public class SkillsInitializator : MonoBehaviour
    {
        [SerializeField] private UIObserver uiObserver;
        [SerializeField] private Transform parentViews;
        [SerializeField] private SkillsDependenciesContainer skillsDependenciesContainer;
        [SerializeField] private PresenterContainer presenterContainer;
        
        private readonly List<ISkillView> _skillViews = new List<ISkillView>();
        private readonly SkillInfoParser _skillsInfoParser = new SkillInfoParser();
        
        private List<ISkill> _skills = new List<ISkill>();

        private void Awake()
        {
            _skills = _skillsInfoParser.ParseData();
            _skillViews.AddRange( parentViews.GetComponentsInChildren<ISkillView>());
            uiObserver.Init(_skillViews, presenterContainer);

            presenterContainer.SetSkillPresenters(CreatePresenters());
            skillsDependenciesContainer.Init(presenterContainer, _skillsInfoParser.GetDependencies());
        }

        private List<ISkillPresenter> CreatePresenters()
        {
            List<ISkillPresenter> skillPresenters = new List<ISkillPresenter>();
            if (_skills.Count != _skillViews.Count)
            {
                Debug.LogError("Количество навыков и вью отличается");
                return null;
            }

            for (int i = 0; i < _skills.Count; i++)
            {
                if (_skills[i] is IForgettableSkill forgettableSkill)
                {
                    skillPresenters.Add(new DynamicSkillPresenter(forgettableSkill, (IDynamicSkillView)GetViewByID(forgettableSkill.Id)));
                }
                else
                {
                    skillPresenters.Add(new SkillPresenter(_skills[i], GetViewByID(_skills[i].Id)));
                }
            }

            return skillPresenters;
        }

        private ISkillView GetViewByID(string id) => 
            _skillViews.Find(x => x.Id == id);
    }
}