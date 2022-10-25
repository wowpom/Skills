using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.Skills.Views
{
    [RequireComponent(typeof(Image))]
    public class DynamicSkillView : MonoBehaviour, IDynamicSkillView
    {
        public event Action<string> OnSelect = delegate {  };

        [SerializeField]
        private string id;
        public string Id => id;

        [SerializeField] private Sprite _availableSprite;
        [SerializeField] private Sprite _studiedSprite;
        [SerializeField] private Text textSkillId;
        [SerializeField] private GameObject selectObject;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            textSkillId.text = id;
        }
        
        public void SetAvailableView() =>
            _image.sprite = _availableSprite;

        public void SetStudiedView() =>
            _image.sprite = _studiedSprite;

        public void OnPointerDown(PointerEventData eventData) => 
            OnSelect(id);
        
        public void Select(bool isSelect) =>
            selectObject.SetActive(isSelect);
    }
}
