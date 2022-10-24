using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Skills.Views
{
    public class SkillView : MonoBehaviour, ISkillView
    {
        public event Action<string> OnSelect = delegate {  };

        [SerializeField] private string id;
        public string Id => id;

        public void OnPointerDown(PointerEventData eventData) =>
            OnSelect(id);
    }
}
