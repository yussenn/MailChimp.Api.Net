﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailChimp.Api.Net.Services.Reports;
using MailChimp.Api.Net.Services.Templates;


using MailChimp.Api.Net.Domain.Reports;
using MailChimp.Api.Net.Services.Campaigns;
using MailChimp.Api.Net.Domain.Campaigns;
using Newtonsoft.Json;

namespace MailChimp.Api.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            MailChimpReports reports = new MailChimpReports();

            try
            {
                //var x = reports.getoverviewbycampaignasync("3709ea682b").result;
                //var x2 = reports.getoverviewbycampaignasync("e6e1eb2be8").result;
                //var x3 = reports.getadviceasync("e6e1eb2be8").result;
                //var x4 = reports.getclickdetailsasync("e6e1eb2be8").result;
                //var x5 = reports.getclickdetailbylinkidasync("e6e1eb2be8", "6defea2fac").result;
                //var x6 = reports.getalllsubscribersinfoasync("e6e1eb2be8", "6defea2fac").result;

                ////subscriber_hash= the md5 hash of the lowercase version of the list member’s email address
                //// var x7 =reports.getspecificsubscriberinfoasync("e6e1eb2be8", "e6e1eb2be8", string subscriber_hash);
                //var x8 = reports.getdomainperformanceasync("e6e1eb2be8").result;
                //var x9 = reports.geteepurlactivityasync("e6e1eb2be8").result;
                //var x10 = reports.getemailactivityasync("e6e1eb2be8").result;
                //// var x11 = reports.getemailactivitybysubscriberasync("e6e1eb2be8",);
                //var x12 = reports.gettoplocationasync("e6e1eb2be8").result;
                //var x13 = reports.getrecipientsinfoasync("e6e1eb2be8").result;
                ////   var x14= reports.getspecificcampaignrecipientasync("e6e1eb2be8");
                //var x15 = reports.getreportforchildcampaignasync("e6e1eb2be8").result;
                //var x16 = reports.getunsubscriberlistasync("e6e1eb2be8").result;
                //  var x17 =getunsubscriberinfoasync("e6e1eb2be8", string subscriber_hash)

                //var k = reports.getoverviewasync().result;
                //var clickdetails = reports.getclickdetailsasync("3709ea682b").result;

                //var x = reports.getoverviewbycampaignasync("3709ea682b").result;
                //var performance = x.timeseries;
                //List<Timesery> listOfPerfmance = performance.ToList<Timesery>();
                //var templates = new MailChimpTemplates();

                // var z = reports.GetOverviewByCampaignAsync("3709ea682b").Result;

                //  var f = templates.GetTemplatesAsync().Result;

                //var k = templates.DeleteATemplateAsync("18085").Result;
                //var kk = templates.GetSpecificTemplateAsync("18085").Result;


                MCCampaignsOverview overview = new MCCampaignsOverview();

                Recipients recipients = new Recipients()
                {
                    list_id = "0a84a63afc"
                };

                Settings campaignSettings = new Settings()
                {
                  // subject_line="This is another Subject line ",
                     title="habijabi#4",
                    from_name = "Shahriar Hossain",
                    reply_to = "shossain@desme.com",
                    template_id = 18073,
                    authenticate = true,
                    auto_footer = false
                };
                Tracking campaignTracking = new Tracking()
                {
                    opens = true,
                    html_clicks = true,
                    text_clicks = true
                };

                var campaignCreationResult = overview.CreateCampaignAsync(Enum.CampaignType.regular, recipients, campaignSettings, campaignTracking).Result;


                if (campaignCreationResult.PostStatus == true)
                {
                    MCCampaignsCheckList mccheckList = new MCCampaignsCheckList();
                    var checkListResult = mccheckList.GetCampaignContentAsync(campaignCreationResult.id).Result;
                }
                else
                {
                    String.Format("Muri Khao!");
                }
                
               

                Console.Read();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            Console.Read();
        }
    }
}
