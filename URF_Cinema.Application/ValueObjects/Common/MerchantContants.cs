﻿namespace URF_Cinema.Application.ValueObjects.Common
{
    public class MerchantContants
    {
        public static string InsertSprocName => "sproc_MerchantInsert";
        public static string UpdateSprocName => "sproc_MerchantUpdate";
        public static string UpdateActiveSprocName => "sproc_MerchantUpdateActive";
        public static string DeleteSprocName => "sproc_MerchantDeleteById";
        public static string SelectWithCriteriaSprocName => "sproc_MerchantSelectByCriteria";
        public static string SelectByIdSprocName => "sproc_MerchantSelectById";
        public static string SelectPagingSprocName => "sproc_MerchantSelectByCriteriaPaging";
    }
}
