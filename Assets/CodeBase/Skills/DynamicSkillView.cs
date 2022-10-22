using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Skills
{
    [RequireComponent(typeof(Image))]
    public class DynamicSkillView : MonoBehaviour, IDynamicSkillView
    {
        [SerializeField]
        private string id;
        public string Id => id;

        [SerializeField] private Sprite _availableSprite;
        [SerializeField] private Sprite _unavailableSprite;
        [SerializeField] private Sprite _studiedSprite;

        private Image _image;

        private void Awake() =>
            _image = GetComponent<Image>();

        public void SetAvailableView() =>
            _image.sprite = _availableSprite;

        public void SetUnavailableView() =>
            _image.sprite = _unavailableSprite;

        public void SetStudiedView() =>
            _image.sprite = _studiedSprite;
    }
}
