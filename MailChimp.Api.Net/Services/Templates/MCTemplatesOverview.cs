﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Api.Net.Domain.Templates;
using MailChimp.Api.Net.Enum;
using Newtonsoft.Json;

namespace MailChimp.Api.Net.Services.Templates
{
    // =====================================================
    // AUTHOR      : Shahriar Hossain
    // PURPOSE     : Manage your MailChimp templates. A template is an HTML file used to create the layout and basic design for a campaign.
    // =====================================================

    public class MCTemplatesOverview
    {
        /// <summary>
        /// Get all templates
        /// </summary>
        public async Task<RootTemplate> GetTemplatesAsync()
        {
            string endpoint = Authenticate.EndPoint(TargetTypes.templates, SubTargetType.not_applicable, SubTargetType.not_applicable);

            string content;
            using (var client = new HttpClient())
            {
                Authenticate.ClientAuthentication(client);

                content = await client.GetStringAsync(endpoint);
            }

            return JsonConvert.DeserializeObject<RootTemplate>(content);
        }

        /// <summary>
        /// Get information about a specific template
        /// <param name="template_id">The unique id for the template.</param>
        /// </summary>
        public async Task<Template> GetTemplatesByIdAsync(string template_id)
        {
            string endpoint = Authenticate.EndPoint(TargetTypes.templates, SubTargetType.not_applicable, SubTargetType.not_applicable, template_id);

            string content;
            using (var client = new HttpClient())
            {
                Authenticate.ClientAuthentication(client);

                content = await client.GetStringAsync(endpoint);
            }

            return JsonConvert.DeserializeObject<Template>(content);
        }

    }
}
