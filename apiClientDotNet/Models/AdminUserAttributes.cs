using System.Collections.Generic;
using Newtonsoft.Json;

namespace apiClientDotNet.Models 
{
    public class AdminUserAttributes
    {
        [JsonProperty("emailAddress")]
        public string EmailAddress;
        
        [JsonProperty("firstName")]
        public string FirstName;
        
        [JsonProperty("lastName")]
        public string LastName;
        
        [JsonProperty("displayName")]
        public string DisplayName;
        
        [JsonProperty("companyName")]
        public string CompanyName;
        
        [JsonProperty("department")]
        public string Department;
        
        [JsonProperty("division")]
        public string Division;
        
        [JsonProperty("title")]
        public string Title;
        
        [JsonProperty("twoFactorAuthPhone")]
        public string TwoFactorAuthPhone;
        
        [JsonProperty("workPhoneNumber")]
        public string WorkPhoneNumber;
        
        [JsonProperty("mobilePhoneNumber")]
        public string MobilePhoneNumber;
        
        [JsonProperty("accountType")]
        public string AccountType;
        
        [JsonProperty("location")]
        public string Location;
        
        [JsonProperty("jobFunction")]
        public string JobFunction;
        
        [JsonProperty("assetClasses")]
        public List<string> AssetClasses;
        
        [JsonProperty("industries")]
        public List<string> Industries;
        
        [JsonProperty("userName")]
        public string UserName;
        
        [JsonProperty("smsNumber")]
        public string SmsNumber;
        
        [JsonProperty("currentKey")]
        public UserKey CurrentKey;
        
        [JsonProperty("previousKey")]
        public UserKey PreviousKey;
    }
}