using CodeBase.Experience.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UserInterface
{
    [RequireComponent(typeof(Button))]
    public class AddingExperienceButton : MonoBehaviour
    {
        private Button _button;
        private IExperiencePresenter _experiencePresenter;

        public void SetExperiencePresenter(IExperiencePresenter experiencePresenter)
        {
            _experiencePresenter = experiencePresenter;
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClickHandle);
        }

        private void OnDestroy()
        {
            if(_experiencePresenter != null)
                _button.onClick.RemoveListener(OnButtonClickHandle);
        }

        private void OnButtonClickHandle() => 
            _experiencePresenter.Add(1);
    }
}
