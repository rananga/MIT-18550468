using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SMS.Common
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string HrUser = "HrUser";
        public const string ProgOfficeUser = "ProgOfficeUser";
        public const string LecturerUser = "LecturerUser";
        public const string AdminUser = "AdminUser";
        public const string FinanceUser = "FinanceUser";
        public const string ExamUser = "ExamUser";
    }

    public enum Log4NetMsgType
    {
        Error = 0,
        Warning = 1,
        Info = 2
    }

    public enum ActiveState
    {
        [Description("Active")]
        Active = 1,
        [Description("Inactive")]
        Inactive = 0
    }

    public enum Gender
    {
        [Description("Male")]
        Male = 0,
        [Description("Female")]
        Female = 1
    }

    public enum TitleTeacher
    {
        [Description("Rev")]
        Rev = 0,
        [Description("Ven")]
        Ven = 1,
        [Description("Prof")]
        Prof = 2,
        [Description("Dr")]
        Dr = 3,
        [Description("Mr")]
        Mr = 4,
        [Description("Mrs")]
        Mrs = 5,
        [Description("Ms")]
        Ms = 6
    }
    public enum TitleStud
    {
        [Description("Mr")]
        Mr = 1,
        [Description("Ms")]
        Ms = 2
    }
    public enum Fluency
    {
        [Description("None")]
        None = 0,
        [Description("Very Good")]
        VeryGood = 1,
        [Description("Good")]
        Good = 2,
        [Description("Average")]
        Average = 3,
        [Description("Weak")]
        Weak = 4
    }
    public enum Relationship
    {
        [Description("Father")]
        Father = 0,
        [Description("Mother")]
        Mother = 1,
        [Description("Guardian")]
        Guardian = 2
    }
    public enum SibRelationship
    {
        [Description("Sister")]
        Sister = 0,
        [Description("Brother")]
        Brother = 1,
    }
    public enum StudGrade
    {
        [Description("Grade 1")]
        Grade1 = 0,
        [Description("Grade 2")]
        Grade2 = 1,
        [Description("Grade 3")]
        Grade3 = 2,
        [Description("Grade 4")]
        Grade4 = 3,
        [Description("Basic")]
        Basic = 4,
        [Description("Junior Part 1")]
        JuniorPart1 = 5,
        [Description("Junior Part 2")]
        JuniorPart2 = 6,
        [Description("Senior Part 1")]
        SeniorPart1 = 7,
        [Description("Senior Part 2")]
        SeniorPart2 = 8,
        [Description("Diploma")]
        Diploma = 9
    }
  
    public enum PrefectType
    {
        [Description("Junior Prefect")]
        Junior = 0,
        [Description("Senior Prefect")]
        Senior = 1,
        [Description("Pending Prefect")]
        PendingPrefect = 2
    }
    public enum MembershipType
    {
        [Description("Member")]
        Member = 0,
        [Description("Committee Member")]
        CommitteeMember = 1
    }
    public enum CommitteeMemberType
    {
        [Description("None")]
        None = 0,
        [Description("President")]
        President = 1,
        [Description("Vice President")]
        VisePresident = 2,
        [Description("Secretary")]
        Secretary = 3,
        [Description("Vice Secretary")]
        ViseSecretary = 4,
        [Description("Treasurer")]
        Treasurer = 5,
        [Description("Vice Treasurer")]
        ViseTreasurer = 6,
    }
    public enum StudStatus
    {
        [Description("Active")]
        Active = 0,
        [Description("Inactive")]
        Inactive = 1,
        [Description("On Leave")]
        OnLeave = 2,
        [Description("Transferred")]
        Transferred = 3
    }
    public enum TeacherStatus
    {
        [Description("Active")]
        Active = 0,
        [Description("Inactive")]
        Inactive = 1,
        [Description("On Leave")]
        OnLeave = 2
    }
   
    public enum Conduct
    {
        [Description("Excellent")]
        Excellent = 0,
        [Description("Very Good")]
        VeryGood = 1,
        [Description("Satisfactory")]
        Satisfactory = 2
    }

    public enum EnvelopType
    {
        [Description("Student Wise")]
        StudentWise = 1,
        [Description("Class Wise")]
        ClassWise = 2,
   
    }
    
}
