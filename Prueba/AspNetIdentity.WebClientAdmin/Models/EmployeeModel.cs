using System;
using System.Collections.Generic;

namespace AspNetIdentity.WebClientAdmin.Models
{
    public class PrivacyPolicyModel
    {
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TextButton { get; set; }
    }

    public class AboutModel
    {
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class ProcessModel
    {
        public int Id_UserTest { get; set; }
        public int Id_StatusTest { get; set; }
        public string Test { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public int ApplicationTime { get; set; }
    }

    public class TechnicalTestQuestion
    {
        public int Id_Question { get; set; }
        public int Id_Type { get; set; }
        public string Question { get; set; }
        public bool Has_Time { get; set; }
        public int Time { get; set; }
        public List<TechnicalTestAnswer> Answers { get; set; }
    }

    public class TechnicalTestAnswer
    {
        public int Id_Answer { get; set; }
        public string Answer { get; set; }
    }

    public class QA
    {
        public string q { get; set; }
        public string a { get; set; }
    }
}