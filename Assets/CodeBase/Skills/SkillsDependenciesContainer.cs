using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Skills.Presenters;
using UnityEngine;

namespace CodeBase.Skills
{
    public class SkillsDependenciesContainer : MonoBehaviour, ISkillsDependenciesContainer
    {
        private Dictionary<string,string[]> _dependencies;
        private IPresenterContainer _presenterContainer;

        public void Init(IPresenterContainer presenterContainer, Dictionary<string, string[]> dependencies)
        {
            _dependencies = dependencies;
            _presenterContainer = presenterContainer;
        }

        public bool GetPossibleStudySkill(string id)
        {
            string[] dependencies = _dependencies[id];
            
            if (dependencies == null || dependencies.Length == 0)
                return true;

            return dependencies
                .Any(t => SkillIsStudy(_presenterContainer.GetPresenterBySkillId(t)));
        }

        public bool GetPossibleForgetSkill(string id)
        {
            KeyValuePair<string, string[]>[] dependency = GetDependency(id);
            if (dependency.Length == 0)
                return true;
            
            if (!WasThereDependency(dependency))
                return true;
            
            return IsNotStudiedOrAreAnyOtherStudiedDependencies(id, dependency);
        }

        private bool WasThereDependency(KeyValuePair<string, string[]>[] dependency)
        {
            return dependency
                .Any(t => _presenterContainer.GetPresenterBySkillId(t.Key) is IStudiedSkillPresenter
                        { IsStudy: true }
                );
        }

        private bool IsNotStudiedOrAreAnyOtherStudiedDependencies(string id, KeyValuePair<string, string[]>[] dependency)
        {
            foreach (var t in dependency)
            {
                if (t.Value.Where(t1 => t1 != id)
                    .Any(t1 => ((IForgettableSkillPresenter)_presenterContainer
                        .GetPresenterBySkillId(t1)).IsStudy))
                    return true;
            }

            return false;
        }

        private KeyValuePair<string, string[]>[] GetDependency(string id)
        {
            List<KeyValuePair<string, string[]>> dependency = new List<KeyValuePair<string, string[]>>();
            foreach (KeyValuePair<string, string[]> value in _dependencies)
            {
                if (value.Key == id)
                    continue;

                dependency
                    .AddRange(from t in value.Value where t == id select value);
            }

            return dependency.ToArray();
        }

        private bool SkillIsStudy(ISkillPresenter skillPresenter)
        {
            if (skillPresenter is IStudiedSkillPresenter studiedSkill)
            {
                return studiedSkill.IsStudy;
            }

            return true;
        }
    }
}