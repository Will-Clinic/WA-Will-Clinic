# Washington Will Clinic
**Iteration 1:** Andres Ibarra, Jeff Martinez, Zachary Johnson, Ariel R. Pedraza, Luay Younus, Dustin Mundy<br/>
**Iteration 2:** Josh Taylor, Philip Werner, Kevin Farrow, Brent Williams, Tiger Hsu<br/>
**Iteration 3:** Andrew Baik, Earl Jay Caoile, Mario Nishio, Eric Singleton<br/>
**Version:** 1.3.0

[**App Deployed on Azure**](https://www.vetswillclinic.org/)

## Table of Contents

1. [Overview](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#overview)
2. [Getting Started](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#getting-started)
3. [Architecture](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#architecture)
4. [FAQs](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#faqs)
5. [Reporting Issues/Bugs](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#reporting-issuesbugs)
6. [Change Log](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#change-log)
7. [License](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#license)

## [Overview](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)
The WA Vets Will Clinic was founded in 2012 by the Spokane County Bar Association Young Lawyers Division in collaboration with Army OneSource, Gonzaga University School of Law, Red Cross - Inland Northwest Region, Vet Center (U.S. Department of Veterans Affairs), and  Washington State Department of Veterans Affairs.

The purpose of the WA Vets Will Clinic is to provide free estate planning documents to eligible veterans of the U.S. Armed Forces.

## [Getting Started](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)

### Veterans Process
After registering for an account, an email verification link will be sent to the veteran. Once the provided link has been clicked (or the address copied and pasted into the veteran's browser if the veteran does not have HTML email support) and the veteran has been successfully logged in, veterans will be presented
with their personal profile. This profile page provides a link to filling
out the veteran's intake form containing all of the information necessary
for an attorney to render services for that veteran. In addition, the profile
gives the veteran a choice of up to three libraries at which the veteran has
elected to meet with attorneys. The date and time that each library selection
has been made is recorded into the database, and matches with attorneys will
be prioritized based upon that date in a first-come-first-serve manner.

### Attorneys Process
After registering for an account, an email verification link will be sent to the attorney. Once the provided link has been clicked (or the address copied and pasted into the attorney's browser if the attorney does not have HTML email support), another form will be presented in which the attorney will provide their bar number for verification with the Washington State Bar Association along with some additional information. The attorney's bar number will be checked against the WSBA to ensure the attorney is allowed to practice law and that they are who they say they are via a match against their provided email address.

Once the attorney has verified their email and status as an attorney, the
attorney will be able to log in. Upon logging in, attorneys will be presented
with their personal profile. This profile page gives the attorney options
to define the libraries at which they can meet with veterans in the state
of Washington. Additionally, the attorney can specify their meeting schedule
in terms of weekly recurring times or specific dates and times. 

After an attorney selects the times and locations that they are open to
meeting with veterans, any veterans matching the attorney's chosen locations
will appear on their profile. At this time, the attorney can choose to
initiate the matching process. Alternative meeting locations are presented
to the attorney in case one of the locations the veteran chose is more
convenient to the attorney.

## [Architecture](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)
![Database Schema](/Resources/dbSchema.png)

## External Services

The Washington Will Clinic makes use of the following services:

- Azure for cryptographically secured storage of secrets (API keys, database connection strings, etc.), application hosting, database management, and account registration for SendGrid 
- SendGrid for email verification, notifications, and administrative communications to users of the site
- The Washington State Bar Association's website for verification of attorneys' bar status via web scraping (with permission from the WSBA)

## [FAQs](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)
1. How long does the application process for veterans normally take?
  + The application process for a veteran can vary, but the average time for completion is 45 minutes if all necessary documents are available. Veterans can save their progress at any point during the application process should they need to stop.
  
2. How long does the application process for attorneys normally take?
  + The application process for an attorney should take an average of 5
  minutes. A verification of the lawyer's bar status will take place based
  on the current status of the Washington State Bar Association's records
  which should only take a few seconds to complete.

3. I'm not sure if I qualify for the Will Clinic, what can be counted as an asset?
  + For a description of what can be considered an asset, please review [**this**](https://www.sapling.com/12085934/examples-personal-assets) helpful article.
4. I've completed my application, now what?
  + Ensure that libraries are chosen for meeting locations with attorneys.
  Once libraries are chosen, you are placed into the pool of eligible 
  veterans to receive services based on the date and time that you selected
  your meeting locations. An attorney should be able to then match with you
  on a first-come-first-serve basis within a few days.

5. As a veteran, how many times can I use the Washington Will Clinic?
  + A veteran can only have one active application at a time, but if the veteran needs to update their will again at a later date and they still qualify for assistance, a veteran can always reuse the Washington Veterans Will Clinic's services.

6. A lot of this information is sensitive, are my documents protected?
  + Security is an important issue for all people involved. All accounts are secured with user information hidden. All data transmissions on the site
  are encrypted. In addition, your information will be kept confidential and
  private until both the veteran and attorney have agreed to be matched for
  services.

7. As a developer, can I learn more about the application including the functionality and general code-base?
  + [Yes you can](https://github.com/Will-Clinic/WA-Will-Clinic/wiki). During iteration 3, documentation has been included within the repository's wiki pages. There you will find explanations such as interface break downs and tutorials on implementations like Azure Key Vaults. 
  
## [Reporting Issues/Bugs](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)
If users encounter any issues or bugs while using this site, they can be reported through the issues tab found [here](https://github.com/Will-Clinic/WA-Will-Clinic/issues)

## [Change Log](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)
### Iteration 3
Hot Fixes:

* Fixed the email validation link to appropriately route and pass in parameters to validate a veteran registration

Major Updates:

* Updated from 2.0 to 2.1.2 to prepare for deprecation
* Re-implemented Azure Key Vaults and included documentation with application breakdown and tutorial
* Filtered libraries without an associated lawyer so veterans cannot select a library without a lawyer
* Refactored Intake form to save upon early exiting, and it will validate the if all of the required inputs to ensure that nothing is missing
* Cleaned up profile CSS and added link functionality to access specific pages quickly

## [License](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)
The Washington Will Clinic's source code as found within this repository
is licensed under the MIT License. License terms can be found within the
[LICENSE](/LICENSE) document at the root of this repository.

## Resources
https://css-tricks.com/almanac/properties/p/page-break/
