using System.Collections.Generic;
using System.Web;
using System;

namespace apiClientDotNet.Utils
{
    public class QueryBuilder
    {
        public string Query { get; private set; }
        public QueryBuilder()
        {
            Query = "?";
        }

        public void AddParameter(string key, object value)
        {
            if(key != null || value!= null || key != String.Empty || value.ToString() != String.Empty)
            {
                var thisParam = HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(value.ToString());
                if (Query != "?")
                {
                    thisParam = "&" + thisParam;
                }
                Query += thisParam;
            }
        }

        public static string DictionaryToQueryString(Dictionary<string,string> queryParams) 
        {
            var queryString = "";
            var dictionarySize = queryParams.Count;
            var count = 0;
            foreach (var parameter in queryParams)
            {
                count++;
                if (parameter.Value != null)
                {
                    queryString += HttpUtility.UrlEncode(parameter.Key) + "=" + HttpUtility.UrlEncode(parameter.Value.ToString());
                }
                if (count < dictionarySize)
                {
                    queryString += "&";
                }
            }
            return queryString;
        }
    }
 }