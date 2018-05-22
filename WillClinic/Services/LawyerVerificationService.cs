using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillClinic.Services
{
    public class LawyerVerificationService : ILawyerVerificationService
    {
        /// <summary>
        /// Builds a URL for the lawyer directory page of a specific lawyer on the WSBA site based on how it was set up 2018-05-22
        /// </summary>
        /// <param name="barNumber">Bar number of lawyer</param>
        /// <returns>url of legal directory page</returns>
        string BuildUrl(int num)
        {
            //build a url like the working example below:
            //https://www.mywsba.org/personifyebusiness/LegalDirectory/LegalProfile.aspx?Usr_ID=000000009999
            string sampleNumber = "000000009999";
            string baseUrl = "https://www.mywsba.org/personifyebusiness/LegalDirectory/LegalProfile.aspx?Usr_ID=";

            //Not all bar numbers are of the same length - some are four digits, some are five, in the future one might be six.
            //This will prepend zeros to get the number to the right length 
            string barNumber = num.ToString();
            StringBuilder sb = new StringBuilder();
            while (sb.Length < sampleNumber.Length - barNumber.Length)
                sb.Append('0');
            sb.Append(barNumber);
            return baseUrl + sb.ToString();
        }

        /// <summary>
        /// Given a Washington State Bar Association LegalDirectory URL, hit the site, scrape relevant data, and
        /// package into a struct for easy access elsewhere. Utilizes the ScrapySharp NuGet package
        /// </summary>
        /// <param name="url">Url where information can be scrapped</param>
        /// <returns> struct with info</returns>
        async Task<BarInfo> FetchBarInfoAsync(string url)
        {
            //Strange redirects were in the WSBA site, so needed to set up a mock browser
            ScrapingBrowser browser = new ScrapingBrowser();
            WebPage lawyer = await browser.NavigateToPageAsync(new Uri(url));

            //Mock browser has retreived page. Now retrieve information using classes/IDs in the HTML
            string name = lawyer.Html.CssSelect(".name").First().InnerText;
            string type = lawyer.Html.CssSelect("#dnn_ctr2977_DNNWebControlContainer_ctl00_lblLicenseType").First().InnerText;
            string eligible = lawyer.Html.CssSelect("#dnn_ctr2977_DNNWebControlContainer_ctl00_lblEligibleToPractice").First().InnerText;
            string email = lawyer.Html.CssSelect("#dnn_ctr2977_DNNWebControlContainer_ctl00_lblEmail").First().InnerText;

            //Return information in new package
            return new BarInfo()
            {
                Name = name,
                Type = type,
                Eligible = eligible,
                Email = email
            };
        }

        /// <summary>
        /// Information being scrapped from WSBA site in a easier format to handle.
        /// </summary>
        public struct BarInfo
        {
            public string Name;
            public string Type;
            public string Eligible;
            public string Email;
        }

        /// <summary>
        /// This checks the users name and bar number against the Washington State Bar Association website. 
        /// IF the name matches exactly, lisence type is lawyer, AND eligibility is yes return true. Else
        /// return false because the lawyer is not valid.
        /// </summary>
        /// <param name="name">Name of lawyer, must be full name as given to the bar association</param>
        /// <param name="barNumber"> bar number as a string</param>
        /// <param name="email">string that holds the provided email</param>
        /// <returns>true if lawyer is valid and information matches, false otherwise</returns>
        public async Task<bool> IsValidLawyerAsync(string name, int barNumber, string email)
        {
            BarInfo lawyer = await FetchBarInfoAsync(BuildUrl(barNumber));
            return (lawyer.Eligible.ToLower().Trim() == "yes"
                 && lawyer.Name.ToLower().Trim() == name.ToLower().Trim()
                 && lawyer.Type.ToLower().Trim() == "lawyer"
                 && lawyer.Email == email);
        }
    }
}
