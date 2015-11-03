﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailChimp.Api.Net.ErrorMessages;
using MailChimp.Api.Net.Enum;
using System.Net.Http;
using System.Net.Http.Headers;

using MailChimp.Api.Net.Mapper;
using MailChimp.Api.Net.CustomException;

namespace MailChimp.Api.Net.Services
{
    internal static class Authenticate
    {
        /// <summary>
        /// Retrieve the API key from App.Config and check if its valid
        /// </summary>
        public static string FeatchApiKey()
        {
            try
            {
                string apiKey = ConfigurationManager.AppSettings["MailChimpApiKey"].ToString();
                if (!String.IsNullOrEmpty(apiKey))
                {
                    return apiKey;
                }
                else
                {
                    string msg = MailChimpExceptionMessage.NullOrEmptyMessage(CommandProperty.apikey);
                    throw new MailChimpExceptions(msg);
                }
            }
            catch (NullReferenceException ex)
            {
                string message = String.Format("MailChimp API Key missing! To resolve Add a key named 'MailChimpApiKey' in your config and SET its value with your mailchimp API key!");
                throw new MailChimpExceptions(message);
            }
            catch (Exception ex)
            {
                throw new MailChimpExceptions(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Get the datacenter prefix based on the API key passed
        /// </summary>
        private static string GetDatacenterPrefix()
        {
            string apikey = FeatchApiKey();
            //  The key should contain a '-'
            if (!apikey.Contains('-'))
            {
                return MailChimpExceptionMessage.InvalidMessage(CommandProperty.apikey);
            }

            return apikey.Split('-')[1];
        }


        /// <summary>
        /// Return the endpoint to caller method
        /// <param name="type">v3.0 Mailchimp EndPoint targetType, example: reports, lists etc</param>
        /// <param name="subType" optional>Expects id for particular list/campaign etc</param>
        /// <param name="id" optional>Expects id for particular list/campaign etc</param>
        /// <param name="linkId" optional>NOT IMPLEMENTED YET</param>
        /// </summary>
        public static string EndPoint(TargetTypes type, SubTargetType subType, SubTargetType childSubType, string id = "", string param2 = "")
        {
            string subCategory = EnumMapper.Map(subType);
            string subChildCategory = EnumMapper.Map(childSubType);

            var dataCenter = GetDatacenterPrefix();
            if (id != "")
            {
                if (subCategory != "")
                {
                    if (param2 != "")
                    {
                        if (subChildCategory != "")
                        {
                            return String.Format("https://{0}.api.mailchimp.com/3.0/{1}/{2}/{3}/{4}/{5}", dataCenter, type, id, subCategory, param2, childSubType);
                        }
                        else
                        {
                            return String.Format("https://{0}.api.mailchimp.com/3.0/{1}/{2}/{3}/{4}", dataCenter, type, id, subCategory, param2);
                        }
                    }
                    else
                    {
                        return String.Format("https://{0}.api.mailchimp.com/3.0/{1}/{2}/{3}", dataCenter, type, id, subCategory);
                    }

                }
                else
                {
                    return String.Format("https://{0}.api.mailchimp.com/3.0/{1}/{2}", dataCenter, type, id);
                }
            }
            else
            {
                return String.Format("https://{0}.api.mailchimp.com/3.0/{1}", dataCenter, type);
            }
        }

        /// <summary>
        /// Return the endpoint to caller method
        /// <param name="id" optional>Expects id for particular list/campaign etc</param>
        /// </summary>
        public static void ClientAuthentication(HttpClient client)
        {
            //HEADS UP!!!! THIS PORTION NEEDS TO REFACTOR !
            //Method name have to change
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Basic", Authenticate.FeatchApiKey());
        }

    }
}
