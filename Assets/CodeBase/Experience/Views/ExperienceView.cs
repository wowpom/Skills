using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Experience.Views
{
    [RequireComponent(typeof(Text))]
    public class ExperienceView : MonoBehaviour, IExperienceView
    {
        private Text _textView;

        public void Init(int experience)
        {
            _textView = GetComponent<Text>();
            SetView(experience);
        }

        public void SetView(int experience) => 
            _textView.text = experience.ToString();
    }
}