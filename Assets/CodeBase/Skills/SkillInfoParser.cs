using System.Collections.Generic;
using CodeBase.Skills.Models;
using SimpleJSON;
using UnityEngine;

namespace CodeBase.Skills
{
    public class SkillInfoParser
    {
        private const string SkillsDataPath = "SkillsData";
        private const string Skills = "skills";
        private const string Typeof = "typeof";
        private const string Base = "base";
        private const string ID = "id";
        private const string Cost = "cost";
        private const string IdDependecy = "idDependecy";
        
        private Dictionary<string, string[]> _dependencies;
        public List<ISkill> ParseData()
        {
            List<ISkill> skills = new List<ISkill>();
            _dependencies = new Dictionary<string, string[]>();
            JSONObject json = (JSONObject)JSON.Parse(Resources.Load<TextAsset>(SkillsDataPath).text);
            if (json == null)
                return null;
            
            JSONNode jsonNode = json[Skills];
            if (jsonNode == null)
                return null;
            
            for (int i = 0; i < jsonNode.Count; i++)
            {
                if (jsonNode[i][Typeof] == Base)
                {
                    skills.Add(new Skill(jsonNode[i][ID]));
                }
                else
                {
                    skills.Add(new DynamicSkill(jsonNode[i][ID], jsonNode[i][Cost]));
                    _dependencies.Add(jsonNode[i][ID], jsonNode[i][IdDependecy]);
                }
            }
            return skills;
        }
    
        public Dictionary<string, string[]> GetDependencies() =>
            _dependencies;
    }
}