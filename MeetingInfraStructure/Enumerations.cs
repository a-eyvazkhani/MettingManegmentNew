using System;
using System.Collections.Generic;

using System.Text;


namespace MeetingInfraStructure
{
    public enum StageEntityType
    {
        Project = 0,
        Metting = 1,
        User = 2
    }

    public enum AssignType
    {
        Resource,
        ProjectServerGroup,
        CustomFields,
        SharePointGroup
    }

    public enum UserRole
    {
        Resource,
        Approval,
        FinalApproval
    }

    public enum StageObjectType
    {
        None,
        Group = 1,
        Resource = 2,
        CustomField = 3,
        Owner = 4,
        SelectiveApprover = 5,
        SelectiveTaskApprvoer = 6

    }

    public enum CustomField_EntityAndType
    {
        Cost = 1,
        Date = 2,
        Duration = 3,
        Flag = 4,
        Number = 5,
        Text = 6
    }

    public enum CustomField_CustomAttributes
    {
        SingleLine = 1,
        MultiLine = 2,
        LookupTable = 3,
        Formula = 4
    }

    public enum CMMCategoryType
    {
        Level = 0,
        Type = 1
    }

    public class CMMCategoryTypeValue
    {
        public static string Level { get { return "موجودیت"; } }

        public static string Type { get { return "نوع"; } }
    }

    public static class CMMTOMFieldType
    {
        public const string Target = "Target";
        public const string Operation = "Operation";
        public const string Measure = "Measure";
    }

    public static class AudienceType
    {
        public const string SMS = "SMS";
        public const string EMail = "EMail";
        public const string All = "All";
    }

    public enum WeeKDays
    {
        Saturday = 1,
        Sunday = 2,
        Monday = 3,
        Tuesday = 4,
        Wednesday = 5,
        Thursday = 6,
        Friday = 7
    }

    public enum CmmScheduleType
    {
        Weekly = 0,
        Dayly = 1,
        Monthly = 2
    }

    public enum PWAObjectType
    {
        none = 0,
        Project = 1,
        Task = 2,
        Resource = 3
    }
    public enum PersonType
    {
        Internal = 0,
        External = 1
    }
    public enum AlertType
    {
        SMS = 0,
        Email = 1,
        Both = 2
    }

    public enum FormFieldDataType
    {
        none = 0,
        NUMERIC = 1,
        TEXT = 2,
        MULTILIE_TEXT = 3,
        FLAG = 4
    }

    public enum PhoneType
    {
        Mobile = 0,
        Office = 1
    }

    public enum ExistanceType
    {
        Person = 0,
        Company = 1
    }

    public enum ScheduleJobType
    {
        EMAIL = 1,
        SMS = 2,
        EmailSms = 3
    }

    public enum KartableType
    {
        Task = 1,
        Approval = 2
    }

    public enum TaskAttachmentFilterType
    {
        All = 0,
        Yes = 1,
        No = 2
    }
}