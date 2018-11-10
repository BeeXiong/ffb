using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using System.Configuration;

namespace FantasyFootballPlayoffs.DAL
{
    public static class parameterFactory
    {
        public static string getDevParameter(string parameterName)
        {
            string parameterString;
            parameterString = "";

            //code to access parameter in development database
            try
            {
                var chain = new Amazon.Runtime.CredentialManagement.CredentialProfileStoreChain();
                Amazon.Runtime.CredentialManagement.CredentialProfile basicProfile;
                Amazon.Runtime.AWSCredentials credentials;
                if (chain.TryGetProfile("bee", out basicProfile))
                {
                    Amazon.Runtime.CredentialManagement.AWSCredentialsFactory.TryGetAWSCredentials(basicProfile, basicProfile.CredentialProfileStore, out credentials);
                    // Use basicProfile
                    var ssmClient = new AmazonSimpleSystemsManagementClient(credentials, Amazon.RegionEndpoint.USEast2);
                    var response = ssmClient.GetParameter(new GetParameterRequest
                    {
                        Name = parameterName,
                        WithDecryption = true
                    });
                    parameterString = response.Parameter.Value;
                }
            }
            catch (Exception e)
            {
                //attempt to retreive connection string failed
            }
            return parameterString;
        }
        public static string getProdParameter(string parameterName)
        {
            string parameterString;
            parameterString = "";
            try
            {
                var appConfig = ConfigurationManager.AppSettings;
                string awsKey = appConfig["awsKey"];
                string awsSec = appConfig["awsSecret"];

                var ssmClient = new AmazonSimpleSystemsManagementClient(awsKey, awsSec, Amazon.RegionEndpoint.USEast2);
                var response = ssmClient.GetParameter(new GetParameterRequest
                {
                    Name = parameterName,
                    WithDecryption = true
                });
                parameterString = response.Parameter.Value;
            }
            catch (Exception e)
            {
                //attempt to retreive connection string failed
            }
            return parameterString;
        } 


    }
}