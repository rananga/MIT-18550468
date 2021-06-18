using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Data
{
    public static class PermissionConstants
    {
        public const string Admin = "Admin";
        public const string AdminUser = "AdminUser";
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

    public enum TitleStaff
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
        [Description("Elder Brother")]
        ElderBrother = 0,
        [Description("Younger Brother")]
        YoungerBrother = 1,
    }
    public enum Grades
    {
        [Description("Grade 01")]
        Grade1 = 1,
        [Description("Grade 02")]
        Grade2 = 2,
        [Description("Grade 03")]
        Grade3 = 3,
        [Description("Grade 04")]
        Grade4 = 4,
        [Description("Grade 05")]
        Grade5 = 5,
        [Description("Grade 06")]
        Grade6 = 6,
        [Description("Grade 07")]
        Grade7 = 7,
        [Description("Grade 08")]
        Grade8 = 8,
        [Description("Grade 09")]
        Grade9 = 9,
        [Description("Grade 10")]
        Grade10 = 10,
        [Description("Grade 11")]
        Grade11 = 11,
        [Description("Grade 12")]
        Grade12 = 12,
        [Description("Grade 13")]
        Grade13 = 13
    }
    public enum Classes
    {
        [Description("A")]
        A = 1,
        [Description("B")]
        B = 2,
        [Description("C")]
        C = 3,
        [Description("D")]
        D = 4,
        [Description("E")]
        E = 5,
        [Description("F")]
        F = 6,
        [Description("G")]
        G = 7,
        [Description("H")]
        H = 8,
        [Description("I")]
        I = 9,
        [Description("J")]
        J = 10,
        [Description("K")]
        K = 11,
        [Description("L")]
        L = 12,
        [Description("M")]
        M = 13,
        [Description("EE-M")]
        EE_M = 14,
        [Description("EE-B")]
        EE_B = 15,
        [Description("T")]
        T = 16
    }

    public enum Medium
    {
        [Description("Sinhala")]
        Sinhala = 0,
        [Description("English")]
        English = 1
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
    public enum ActiveStatus
    {
        [Description("Active")]
        Active = 0,
        [Description("Inactive")]
        Inactive = 1
    }
    public enum QualificationType
    {
        [Description("Diploma")]
        Diploma = 0,
        [Description("Degree")]
        Degree = 1,
        [Description("Master")]
        Master = 2,
        [Description("PHD")]
        PHD = 3
    }

    public enum Term
    {
        [Description("Term 1")]
        Term1 = 0,
        [Description("Term 2")]
        Term2 = 1,
        [Description("Term 3")]
        Term3 = 2
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
