using System.Collections.Generic;

namespace CodeBase.Skills
{
    public interface ISkillsDependenciesContainer
    {
        void Init(IPresenterContainer presenterContainer, Dictionary<string, string[]> dependencies);
        bool GetPossibleStudySkill(string id);
        bool GetPossibleForgetSkill(string id);
    }
}