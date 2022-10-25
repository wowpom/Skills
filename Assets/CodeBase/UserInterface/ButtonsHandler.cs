using System;
using CodeBase.Skills.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UserInterface
{
    public class ButtonsHandler : MonoBehaviour
    {
        public event Action<ISkillPresenter> OnStudyRequest = delegate {  }; 
        public event Action<ISkillPresenter> OnForgetRequest = delegate {  };
        public event Action OnForgetAllRequest = delegate {  };

        [SerializeField] private Button studyButton;
        [SerializeField] private Button forgetButton;
        [SerializeField] private Button forgetAllButton;
        
        private ISkillPresenter _selectedSkillPresenter;
    
        public void SetSkillPresenter(ISkillPresenter skillPresenter)
        {
            Unsubscribe();
            _selectedSkillPresenter?.Select(false);

            _selectedSkillPresenter = skillPresenter;
            if (skillPresenter is IForgettableSkillPresenter forgettableSkillPresenter)
            {
                forgettableSkillPresenter.OnForget += UpdateSkillDataHandle;
                forgettableSkillPresenter.OnStudy += UpdateSkillDataHandle;
                UpdateButtonsInteractable(forgettableSkillPresenter);
            }
            else
            {
                studyButton.interactable = false;
                forgetButton.interactable = false;
            }

            _selectedSkillPresenter?.Select(true);

        }

        private void UpdateSkillDataHandle()
        {
            if(_selectedSkillPresenter is IForgettableSkillPresenter forgettableSkillPresenter)
                UpdateButtonsInteractable(forgettableSkillPresenter);
        }

        private void UpdateButtonsInteractable(IForgettableSkillPresenter forgettableSkill)
        {
            studyButton.interactable = !forgettableSkill.IsStudy;
            forgetButton.interactable = forgettableSkill.IsStudy;
        }

        private void Start()
        {
            studyButton.onClick.AddListener(OnStudyHandle);
            forgetButton.onClick.AddListener(OnForgetHandle);
            forgetAllButton.onClick.AddListener(OnForgetAllHandle);

        }

        private void OnDestroy()
        {
            studyButton.onClick.RemoveListener(OnStudyHandle);
            forgetButton.onClick.RemoveListener(OnForgetHandle);
            forgetAllButton.onClick.RemoveListener(OnForgetAllHandle);
        }

        private void Unsubscribe()
        {
            if (_selectedSkillPresenter is IForgettableSkillPresenter forgettableSkill)
            {
                forgettableSkill.OnForget -= UpdateSkillDataHandle;
                forgettableSkill.OnStudy -= UpdateSkillDataHandle;
            }
        }

        private void OnForgetAllHandle() =>
            OnForgetAllRequest();
        
        private void OnForgetHandle() =>
            OnForgetRequest(_selectedSkillPresenter);

        private void OnStudyHandle() => 
            OnStudyRequest(_selectedSkillPresenter);
    }
}
