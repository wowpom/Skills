using System.Collections.Generic;
using CodeBase.Skills.Models;
using CodeBase.Skills.Presenters;
using CodeBase.Skills.Views;
using CodeBase.UserInterface;
using UnityEngine;

namespace CodeBase.Skills
{
    public class SkillsInitializator : MonoBehaviour, IPresenterContainer
    {
        public List<ISkillPresenter> SkillPresenters => _skillPresenters;
        private readonly List<ISkillPresenter> _skillPresenters = new List<ISkillPresenter>();
        
        [SerializeField] private UIObserver uiObserver;
        [SerializeField] private Transform parentViews;
        [SerializeField] private SkillsDependenciesContainer skillsDependenciesContainer;
        
        private readonly List<ISkillView> _skillViews = new List<ISkillView>();
        private readonly SkillInfoParser _skillsInfoParser = new SkillInfoParser();
        
        private List<ISkill> _skills = new List<ISkill>();

        public ISkill GetSkillById(string id) =>
            _skills.Find(x => x.Id == id);

        public ISkillPresenter GetPresenterBySkillId(string skillID) => 
            _skillPresenters.Find(x => x.Id == skillID);

        private void Awake()
        {
            _skills = _skillsInfoParser.ParseData();
            _skillViews.AddRange( parentViews.GetComponentsInChildren<ISkillView>());
            uiObserver.Init(_skillViews, this);

            CreatePresenters();
            skillsDependenciesContainer.Init(this, _skillsInfoParser.GetDependencies());
        }

        private void CreatePresenters()
        {
            if (_skills.Count != _skillViews.Count)
            {
                Debug.LogError("Количество навыков и вью отличается");
                return;
            }

            for (int i = 0; i < _skills.Count; i++)
            {
                if (_skills[i] is IForgettableSkill forgettableSkill)
                {
                    _skillPresenters.Add(new DynamicSkillPresenter(forgettableSkill, (IDynamicSkillView)GetViewByID(forgettableSkill.Id)));
                }
                else
                {
                    _skillPresenters.Add(new SkillPresenter(_skills[i], GetViewByID(_skills[i].Id)));
                }
            }
        }

        private ISkillView GetViewByID(string id) => 
            _skillViews.Find(x => x.Id == id);
    }
}