using System.Collections.Generic;
using CodeBase.Skills;
using CodeBase.Skills.Views;
using UnityEngine;

namespace CodeBase.UserInterface
{
    public class UIObserver : MonoBehaviour
    {
        [SerializeField] private ButtonsHandler buttonsHandler;

        private List<ISkillView> _skillViews;

        private string _skillID;
        private SkillsInitializator _presenterContainer;

        public void Init(List<ISkillView> skillViews, SkillsInitializator presenterContainer)
        {
            _presenterContainer = presenterContainer;
            _skillViews = skillViews;
            for (int i = 0; i < skillViews.Count; i++)
                if (skillViews[i] is IDynamicSkillView)
                    skillViews[i].OnSelect += OnSelectHandle;
        }

        private void OnDestroy()
        {
            if(_skillViews == null)
                return;
            
            for (int i = 0; i < _skillViews.Count; i++)
            {
                _skillViews[i].OnSelect -= OnSelectHandle;
            }
        }

        private void OnSelectHandle(string skillId)
        {
            if (skillId == _skillID)
                return;
        
            _skillID = skillId;
            buttonsHandler.SetSkillPresenter(_presenterContainer.GetPresenterBySkillId(skillId));
        }
    }
}