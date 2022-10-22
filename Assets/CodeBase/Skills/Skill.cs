using System;
using System.Collections.Generic;

namespace CodeBase.Skills
{
    public class Skill : ISkill
    {
        private readonly string _id;
        public string Id { get; }
        
        public Skill (string id) => 
            _id = id;
    }
}
