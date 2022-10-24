using System;
using UnityEngine.EventSystems;

namespace CodeBase.Skills.Views
{
    public interface ISkillView: IPointerDownHandler
    {
        event Action<string> OnSelect;

        string Id { get; }
    }
}
