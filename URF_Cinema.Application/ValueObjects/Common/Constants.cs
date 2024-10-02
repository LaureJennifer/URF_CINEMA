namespace URF_Cinema.Application.ValueObjects.Common
{
    public class QueryConstant
    {
        public class OperatorTypes
        {
            public const string GreaterThan = ">";

            public const string GreaterThanOrEqual = ">=";

            public const string Equal = "=";

            public const string LessThan = "<";

            public const string LessThanOrEqual = "<=";

            public const string None = "";
        }

        public class MatchTypes
        {
            public const bool Contain = false;

            public const bool Equal = true;
        }
    }

    public class PersonalClaimTypeConstant
    {
        //• type1 - free no ads: value1 =0.5
        //• type2 - free ads: value2 = 1
        //• type3 - pack1: value3 = 1,1
        //• type4 - pack2: value4 = 1,2
        //• type5 - pack3: value5 = 1,4

        //• Free No ads
        //Grandparent = 0.01 * BEE * value1
        //Patent= 0.1*BEE* value1
        //F1 = 0.1*BEE* value1

        //• Free ads
        //Grandparent = 0.01*BEE* value2
        //Patent= 0.1*BEE* value2
        //F1 = 0.1*BEE* value2 

        //• Các pack.
        //Grandparent = 0.01*BEE* value2
        //Patent= 0.1 * BEE * value2
        //F1 = 0.1 * BEE * value2
        public class PersonalClaimTypes
        {

            public const int Type1 = 1;
            public const int Type2 = 2;
            public const int Type3 = 3;
            public const int Type4 = 4;
            public const int Type5 = 5;
        }

        public class PersonalClaimTypeCoefficients
        {
            public const decimal Type1Coefficient = 0.5m;
            public const decimal Type2Coefficient = 1.0m;
            public const decimal Type3Coefficient = 1.1m;
            public const decimal Type4Coefficient = 1.2m;
            public const decimal Type5Coefficient = 1.4m;
        }
    }

    public class ClaimDefault
    {
        public const int ExploitEarnBase = 1000;

        public const int ClaimTimesPerDay = 5;

        public const int DurationClaimMinute = 2;


        public const int GrandParentQuantity = 10;

        public const int ParentQuantity = 100;

        public const int PersonalQuantity = 1000;

        public const int F1Quantity = 100;

        public const int F2Quantity = 10;
    }

    public class PoolDefault
    {
        public const int PoolSize = 10;

    }

    public class KYCDefault
    {
        public const int MinAmountOfSatoshi = 200000;
    }
    public static class AppRole
    {
        public const string Admin = "Administrator";
        public const string Customer = "Customer";
        public const string Manager = "Manager";
        public const string Accountant = "Accountant";
        public const string HR = "Human Resource";
        public const string Warehouse = "Warehouse staff";
        public const string Id = "id";
        public const string UserName = "userName";
        public const string Localhost = "localHost";
        public const string RoleNames = "roleNames";
        public const string Password = "password";
    }
    public class Email
    {
        public const string Key = "Setting.Email.";
        public const string EmailSend = "Setting.Email.EmailSend";
        public const string Password = "Setting.Email.Password";
        public const string Smtp = "Setting.Email.Smtp";
        public const string Port = "Setting.Email.Port";
    }
    public class ConstsToken
    {
        public const string Issuer = "https://localhost:7005";
        public const string Audience = "https://localhost:7005";
        public const string SecretKey = "keytoken_NVT25102002@123456789abcdefgh";
    }
    public class Roles
    {
        public const string Admin = "ADMIN";
        public const string Staff = "Nhân viên";
        public static string GetFormatRoles(params string[] roles)
        {
            var result = string.Join(",", roles);
            return result;
        }
        public static bool IsModuleManager(List<string> roleCodes)
        {
            return roleCodes.Any(c => c != Admin && c != Staff);
        }
    }
}
