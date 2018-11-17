using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.DAL;
using WEB_APP_SCHOOL_NET.Models;

namespace WEB_APP_SCHOOL_NET.Common
{
    public class cls_Common
    {
        private static ApplicationUserManager _userManager;
        public static ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private static ApplicationUser _userProfile;
        public static ApplicationUser UserProfile
        {
            get
            {
                return _userProfile ?? LoggedInUserProfile();
            }
        }


        private static ApplicationUser LoggedInUserProfile()
        {
            var userid = LoggedInUserID();
            var profile = UserManager.Users.Where(w => w.Id == userid).FirstOrDefault();
            return profile;

        }
        public static string LoggedInUserID()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            if (userId != null)
                return userId;
            else
                return string.Empty;
        }
        public static bool IsAuthenticate()
        {
            var status = HttpContext.Current.User.Identity.IsAuthenticated;
            return status;
        }

        public static bool IsSuperAdmin()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            if (userId != null)
                return UserManager.IsInRole(userId, "SYSADMIN");
            else
                return false;
        }
        
        public static string ProcessMyDataItem(object myValue)
        {
            if (myValue == null || myValue.ToString()=="")
            {
                return "0.0";
            }

            return myValue.ToString();
        }

        public static string ProcessMyDataItemInt(object myValue)
        {
            if (myValue == null || myValue.ToString() == "")
            {
                return "0";
            }

            return myValue.ToString();
        }
        //public static bool IsTaxConsultant()
        //{
        //    var userId = HttpContext.Current.User.Identity.GetUserId();
        //    if (userId != null)
        //        return UserManager.IsInRole(userId, EnumConstants.RoleName.TaxConsultant.ToString());
        //    else
        //        return false;
        //}

        //public static bool IsUser()
        //{
        //    var userId = HttpContext.Current.User.Identity.GetUserId();
        //    if (userId != null)
        //        return UserManager.IsInRole(userId, EnumConstants.RoleName.User.ToString());
        //    else
        //        return false;
        //}


    }

    public class CommonBindControl
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        UnitOfWork unitofWork = new UnitOfWork();
        cls_ClassDTO _cls_ClassDTO = new cls_ClassDTO();
        public void BindMasterData(DropDownList dropDownList, EnumConstants.Masters enumConstants)
        {
            switch (enumConstants)
            {
                case EnumConstants.Masters.Role:
                    var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));
                    var roles = RoleManager.Roles;
                    dropDownList.DataSource = roles.ToList();
                    dropDownList.DataBind();
                    break;
                case EnumConstants.Masters.Organization:
                    dropDownList.DataSource = unitofWork.OrganzationRepository.All().OrderBy(o => o.Org_Id).ToList();
                    dropDownList.DataTextField = "Name";
                    dropDownList.DataValueField = "Org_Id";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.State:
                    dropDownList.DataSource = unitofWork.StateRepository.All().OrderBy(o => o.StateName).ToList();
                    dropDownList.DataTextField = "StateName";
                    dropDownList.DataValueField = "StateId";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.City:
                    dropDownList.DataSource = unitofWork.CityRepository.All().OrderBy(o => o.CityName).ToList();
                    dropDownList.DataTextField = "CityName";
                    dropDownList.DataValueField = "CityId";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.Cast:
                    dropDownList.DataSource = typeof(Common.EnumConstants.Caste).ToList();
                    dropDownList.DataTextField = "Key";
                    dropDownList.DataValueField = "Value";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.VehicleType:
                    dropDownList.DataSource = typeof(Common.EnumConstants.FuelUsed).ToList();
                    dropDownList.DataTextField = "Key";
                    dropDownList.DataValueField = "Value";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.FuelUsed:
                    dropDownList.DataSource = typeof(Common.EnumConstants.VehicleType).ToList();
                    dropDownList.DataTextField = "Key";
                    dropDownList.DataValueField = "Value";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.Religion:
                    dropDownList.DataSource = unitofWork.ReligionRepository.All().OrderBy(o => o.ReligionName).ToList();
                    dropDownList.DataTextField = "ReligionName";
                    dropDownList.DataValueField = "ReligionId";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.Class:
                    dropDownList.DataSource = _cls_ClassDTO.GetOrgClass();
                    dropDownList.DataTextField = "ClassName";
                    dropDownList.DataValueField = "ClassId";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));

                    break;
                case EnumConstants.Masters.Section:
                    dropDownList.DataSource = unitofWork.SectionRepository.All().OrderBy(o => o.SectionName).ToList();
                    dropDownList.DataTextField = "SectionName";
                    dropDownList.DataValueField = "SectionId";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.Subject:
                    dropDownList.DataSource = unitofWork.SubjectRepository.Filter(f => f.MST_CLASS.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
                    dropDownList.DataTextField = "SubjectName";
                    dropDownList.DataValueField = "SubjectId";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.Occupation:
                    dropDownList.DataSource = unitofWork.OccupationRepository.All().OrderBy(o => o.OccupationName).ToList();
                    dropDownList.DataTextField = "OccupationName";
                    dropDownList.DataValueField = "Occupation_ID";
                    dropDownList.DataBind();
                    dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.AcademicYear:
                    dropDownList.DataSource = unitofWork.FinYear.All().OrderByDescending(o => o.Fin_ID).ToList();
                    dropDownList.DataTextField = "Finyear_Format";
                    dropDownList.DataValueField = "Fin_ID";
                    dropDownList.DataBind();
                    //dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                case EnumConstants.Masters.ExamResultFormat:
                    ListItem li = new ListItem("Nursury-8th", "ExamReport.rdlc");
                    ListItem li11 = new ListItem("9th-11th", "ExamReport_ss.rdlc");
                    dropDownList.Items.Add(li);
                    dropDownList.Items.Add(li11);//.DataSource = BindExamResultFormat();
                    // dropDownList.DataTextField = "Finyear_Format";
                    // dropDownList.DataValueField = "Fin_ID";
                    // dropDownList.DataBind();
                    //dropDownList.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    break;
                default:
                    break;
            }
        }

        private List<ListItem> BindExamResultFormat()
        {
            List<ListItem> list = new List<ListItem>();
            ListItem li = new ListItem("Nursury-8th","ExamReport.rdlc");
            ListItem li11 = new ListItem("9th-11th", "ExamReport_ss.rdlc");
            list.Add(li);
            list.Add(li11);
            return list;
        }



    }

    public static class Crypto
    {
        private const int PBKDF2IterCount = 1000; // default for Rfc2898DeriveBytes
        private const int PBKDF2SubkeyLength = 256 / 8; // 256 bits
        private const int SaltSize = 128 / 8; // 128 bits

        /* =======================
         * HASHED PASSWORD FORMATS
         * =======================
         * 
         * Version 0:
         * PBKDF2 with HMAC-SHA1, 128-bit salt, 256-bit subkey, 1000 iterations.
         * (See also: SDL crypto guidelines v5.1, Part III)
         * Format: { 0x00, salt, subkey }
         */

        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            // Produce a version 0 (see comment above) text hash.
            byte[] salt;
            byte[] subkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
            {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }

            var outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }

        // hashedPassword must be of the format of HashWithPassword (salt + Hash(salt+input)
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

            // Verify a version 0 (see comment above) text hash.

            if (hashedPasswordBytes.Length != (1 + SaltSize + PBKDF2SubkeyLength) || hashedPasswordBytes[0] != 0x00)
            {
                // Wrong length or version header.
                return false;
            }

            var salt = new byte[SaltSize];
            Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
            var storedSubkey = new byte[PBKDF2SubkeyLength];
            Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, PBKDF2SubkeyLength);

            byte[] generatedSubkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, PBKDF2IterCount))
            {
                generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }
            return ByteArraysEqual(storedSubkey, generatedSubkey);
        }

        // Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            var areSame = true;
            for (var i = 0; i < a.Length; i++)
            {
                areSame &= (a[i] == b[i]);
            }
            return areSame;
        }
    }
    public class EnumConstants
    {
        [Flags]
        public enum StudentPromotedStatus
        {
            [Description("New Admission")]
            NewAdmission = 0,
            [Description("Student Promoted")]//old class Track and student promoted to another high class.
            StudentPromoted = 1,
            [Description("Promoted")]//Pass with grase
            Promoted = 2,
            [Description("Passed")]
            Passed = 3,
            [Description("Failed")]
            Failed = 4,
            [Description("Drop-Out")]
            DropOut = 5
        }

        [Flags]
        public enum FuelUsed
        {
            [Description("Petrol")]
            Petrol = 1,
            [Description("Diesel")]
            Diesel = 2,
            [Description("CNG")]
            CNG = 3          
        }

        [Flags]
        public enum VehicleType
        {
            [Description("Bus")]
            Bus = 1,
            [Description("Car")]
            Car = 2,
            [Description("Traveller")]
            Traveller = 3,
            [Description("Other")]
            Other = 4
        }

        [Flags]
        public enum MonthName
        {
            January = 01,
            February = 02,
            March = 03,
            April = 04,
            May = 05,
            June = 06,
            July = 07,
            August = 08,
            September = 09,
            October = 10,
            November = 11,
            December = 12
        }

        [Flags]
        public enum Quaterly
        {
            [Description("April-June")]
            AprilJune=1,
            [Description("July-Sep")]
            JulySep=2,
            [Description("Oct-Dec")]
            OctDec=3,
            [Description("Jan-March")]
            JanMarch=4
        }

        [Flags]
        public enum HalfYearly
        {
            [Description("First HalfYearly")]
            FirstHalfYearly = 1,
            [Description("Second HalfYearly")]
            SecondHalfYearly = 2
            
        }

        [Flags]
        public enum SiteContent
        {
            Home,
            About,
            Course,
            Faculty,
            ShortAbout,
            ShortStudent,

        }


        [Flags]
        public enum Masters
        {
            [Description("Role")]
            Role,
            [Description("Group")]
            Group,
            [Description("City")]
            City,
            [Description("State")]
            State,
            [Description("Cast")]
            Cast,
            [Description("Organization")]
            Organization,
            [Description("Class")]
            Class,
            [Description("Subject")]
            Subject,
            [Description("Section")]
            Section,
            [Description("Religion")]
            Religion,
            [Description("Occupation")]
            Occupation,
            [Description("Academic Year")]
            AcademicYear,
            [Description("Vehicle Type")]
            VehicleType,
            [Description("Fuel Used")]
            FuelUsed,
            [Description("Exam Result Format")]//Marksheet format:TODO from db
            ExamResultFormat

        }

        [Flags]
        public enum Caste
        {
            [Description("General")]
            General=1,
            [Display(Name = "Other Backward Caste")]
            OBC=2,
            [Display(Name = "Scheduled Caste")]
            SC=3,
            [Display(Name = "Scheduled Tribe")]
            ST=4
        }

        [Flags]
        public enum FeeDuration
        {
            [Description("OneTime")]
            OneTime=1,
            [Display(Name = "Monthly")]
            Monthly=2,
            [Display(Name = "Quartly")]
            Quartly=3,
            [Display(Name = "Half Yearly")]
            HalfYearly=4,
            [Display(Name = "Anually")]
            Anually=5
        }

        [Flags]
        public enum Status
        {
            [Description("Deactive")]
            Deactive,
            [Display(Name = "Active")]
            Active,
            [Display(Name = "Delete")]
            Delete
        }
        [Flags]
        public enum Session
        {
            [Description("2017-2018")]
            Current
        }

        [Flags]
        public enum PaymentType
        {
            Cheque =1,
            Cash = 2,
            NetBanking = 3,
            Wallet = 4
        }

        [Flags]
        public enum ExamType
        {
             [Description("HalfYearly Exam")]
            HalfYearly =3,//1
             [Description("Annually Exam")]
            Annually = 4,//2
             [Description("Quarterly Exam")]
            Quarterly = 2,//3
             [Description("Monthly Exam")]
            MonthlyExam=1//4
        }
    }

    public static class EnumExtensions
    {

        // This extension method is broken out so you can use a similar pattern with 
        // other MetaData elements in the future. This is your base method for each.
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        // This method creates a specific call to the above method, requesting the
        // Description MetaData attribute.
        public static string ToName(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        private string description;

        /// <span class="code-SummaryComment"><summary></span>
        /// Gets the description stored in this attribute.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><value>The description stored in the attribute.</value></span>
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Initializes a new instance of the
        /// <span class="code-SummaryComment"><see cref="EnumDescriptionAttribute"/> class.</span>
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="description">The description to store in this attribute.</span>
        /// <span class="code-SummaryComment"></param></span>
        public EnumDescriptionAttribute(string description)
            : base()
        {
            this.description = description;
        }
    }
    public static class EnumHelper
    {

        /// <span class="code-SummaryComment"><summary></span>
        /// Gets the <span class="code-SummaryComment"><see cref="DescriptionAttribute" /> of an <see cref="Enum" /> </span>
        /// type value.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="value">The <see cref="Enum" /> type value.</param></span>
        /// <span class="code-SummaryComment"><returns>A string containing the text of the</span>
        /// <span class="code-SummaryComment"><see cref="DescriptionAttribute"/>.</returns></span>
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            //Type typeOfT = typeof(T);
            //T obj = Activator.CreateInstance<T>();

            //PropertyInfo[] propInfo = value.GetType().GetProperties();

            //foreach (PropertyInfo property in propInfo)
            //{
            //          var field = (value.GetType())Attribute.GetCustomAttribute(property, typeof(value.GetType()), false);
            //    //if(field != null) {
            //    //}
            //}

            var Type = value.GetType();
            var Name = Enum.GetName(Type, value);
            if (Name == null)
                return null;

            var Field = Type.GetField(Name);
            if (Field == null)
                return null;

            var Attr = Field.GetCustomAttribute<EnumDescriptionAttribute>();
            if (Attr == null)
                return null;

            //return Attr.Description

            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Converts the <span class="code-SummaryComment"><see cref="Enum" /> type to an <see cref="IList" /> </span>
        /// compatible object.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="type">The <see cref="Enum"/> type.</param></span>
        /// <span class="code-SummaryComment"><returns>An <see cref="IList"/> containing the enumerated</span>
        /// type value and description.<span class="code-SummaryComment"></returns></span>
        public static IList ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value,Convert.ToInt32(value).ToString()));
            }

            return list;
        }
    }
    public static class Enumeration
    {
        public static IDictionary<int, string> GetAll<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var dictionary = new Dictionary<int, string>();

            foreach (int value in Enum.GetValues(enumerationType))
            {
                var name = Enum.GetName(enumerationType, value);
                dictionary.Add(value, name);
            }

            return dictionary;
        }
        public static string GetDescription(Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])
             fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Converts the <span class="code-SummaryComment"><see cref="Enum" /> type to an <see cref="IList" /> </span>
        /// compatible object.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="type">The <see cref="Enum"/> type.</param></span>
        /// <span class="code-SummaryComment"><returns>An <see cref="IList"/> containing the enumerated</span>
        /// type value and description.<span class="code-SummaryComment"></returns></span>
        public static IList ToList(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
            }

            return list;
        }
        public static string ToDescription(this Enum value)
        {
            DescriptionAttribute[] da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return da.Length > 0 ? da[0].Description : value.ToString();
        }
    }

    public static class ExtensionMethod
    {
        //public static EntityCollection<T> ToEntityCollection<T>(this List<T> list) where T : class
        //{
        //    EntityCollection<T> entityCollection = new EntityCollection<T>();
        //    list.ForEach(entityCollection.Add);
        //    return entityCollection;
        //}
        public enum DateTimeFormat
        {
            Date, // 25 Apr 2014
            DateWithDayPrefix, // Wed, 16 Apr 2014 
            DateWithFullDayPrefix, // Saturday, 12 Apr 2014
            DateWithTime, // 12 Apr 2014 01:34 PM
            DateTimeStamp, // 12 Apr 2014 13:34
            DateJson, // 2014-04-12
            DateTimeJson, // 2014-04-12 13:34:20
            DateLocal // 2014/04/12
        }

        /// <summary>
        /// Returns formatted date string for display purpose
        /// </summary>
        public static string DisplayDate(this string date)
        {
            return DisplayDate(date, DateTimeFormat.Date);
        }

        /// <summary>
        /// Returns formatted date string for display purpose
        /// </summary>
        public static string DisplayDate(this string date, DateTimeFormat format)
        {
            switch (format)
            {
                case DateTimeFormat.DateWithDayPrefix:
                    return string.Format("{0:ddd, dd MMM yyyy}", date);

                case DateTimeFormat.DateWithFullDayPrefix:
                    return string.Format("{0:dddd, dd MMM yyyy}", date);

                case DateTimeFormat.DateWithTime:
                    return string.Format("{0:dd MMM yyyy h:mm tt}", date);

                case DateTimeFormat.DateTimeStamp:
                    return string.Format("{0:dd MMM yyyy HH:mm}", date);

                case DateTimeFormat.DateJson:
                    return string.Format("{0:yyyy-MM-dd}", date);

                case DateTimeFormat.DateTimeJson:
                    return string.Format("{0:yyyy-MM-dd HH:mm:ss}", date);

                case DateTimeFormat.DateLocal:
                    return string.Format("{0:yyyy/MM/dd}", date);

                case DateTimeFormat.Date:
                default:
                    return string.Format("{0:dd MMM yyyy}", date);
            }
        }

        /// <summary>
        /// Returns formatted date string in Database timestamp format.
        /// </summary>
        public static string DBTimestamp(this DateTime date)
        {
            return string.Format("{0:yyyy-MM-dd hh:mm:ss.fff}", date);
        }

        public static DataTable AsDataTable<T>(this IEnumerable<T> list)
        where T : class
        {
            DataTable dtOutput = new DataTable("tblOutput");

            //if the list is empty, return empty data table
            if (list.Count() == 0)
                return dtOutput;

            //get the list of  public properties and add them as columns to the
            //output table           
            PropertyInfo[] properties = list.FirstOrDefault().GetType().
                GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo propertyInfo in properties)
                dtOutput.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);

            //populate rows
            DataRow dr;
            //iterate through all the objects in the list and add them
            //as rows to the table
            foreach (T t in list)
            {
                dr = dtOutput.NewRow();
                //iterate through all the properties of the current object
                //and set their values to data row
                foreach (PropertyInfo propertyInfo in properties)
                {
                    dr[propertyInfo.Name] = propertyInfo.GetValue(t) ?? DBNull.Value;// propertyInfo.GetValue(t, null);
                }
                dtOutput.Rows.Add(dr);
            }
            return dtOutput;
        }


    }

}