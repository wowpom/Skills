using System.Collections.Generic;
using CodeBase.Skills.Presenters;
using UnityEngine;

namespace CodeBase.Skills
{
    public class PresenterContainer : MonoBehaviour, IPresenterContainer
    {
        private List<ISkillPresenter> _skillPresenters = new List<ISkillPresenter>();
        public List<ISkillPresenter> SkillPresenters => _skillPresenters;

        public void SetSkillPresenters(List<ISkillPresenter> skillPresenters) =>
            _skillPresenters = skillPresenters;
    
        public ISkillPresenter GetPresenterBySkillId(string skillID) => 
            _skillPresenters.Find(x => x.Id == skillID);
    }
}
