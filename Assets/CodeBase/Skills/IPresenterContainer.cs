using System.Collections.Generic;
using CodeBase.Skills.Presenters;

namespace CodeBase.Skills
{
    public interface IPresenterContainer
    {
        List<ISkillPresenter> SkillPresenters { get; }
        ISkillPresenter GetPresenterBySkillId(string skillID);
    }
}