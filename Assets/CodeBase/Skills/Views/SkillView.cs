using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Skills.Views
{
    public class SkillView : MonoBehaviour, ISkillView
    {
        public event Action<string> OnSelect = delegate {  };

        [SerializeField] private string id;
        [SerializeField] private GameObject selectObject;
        public string Id => id;

        public void Select(bool isSelect) =>
            selectObject.SetActive(isSelect);

        public void OnPointerDown(PointerEventData eventData) =>
            OnSelect(id);
    }
}
