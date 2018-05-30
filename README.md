# Washington Will Clinic
**Iteration 1:** Andres Ibarra, Jeff Martinez, Zachary Johnson, Ariel R. Pedraza, Luay Younus, Dustin Mundy<br/>
**Iteration 2:** Josh Taylor, Philip Werner, Kevin Farrow, Brent Williams, Tiger Hsu<br/>
**Version:** 1.2.0

[**App Deployed on Azure**](https://washingtonwillclinic.azurewebsites.net)

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
After registering for an account and logging in, veterans will be presented
with their personal profile. This profile page provides a link to filling
out the veteran's intake form containing all of the information necessary
for an attorney to render services for that veteran. In addition, the profile
gives the veteran a choice of up to three libraries at which the veteran has
elected to meet with attorneys. The date and time that each library selection
has been made is recorded into the database, and matches with attorneys will
be prioritized based upon that date in a first-come-first-serve manner.

### Attorneys Process
After registering for an account and logging in, attorneys will be presented
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
![Database Schema](https://i.imgur.com/1TC13OI.png "Microsoft SQL Database Schema")

## [FAQs](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)
1. How long does the application process for veterans normally take?
  + The application process for a veteran can vary, but the average time for completion is 45 minutes if all necessary documents are available. Veterans can save their progress at any point during the application process should they need to stop.
  
2. How long does the application process for attorneys normally take?
  + The application process for an attorney should take an average of 5 minutes. The verification process for attorneys so they'll be able to match with a veteran is dependent on when an admin will be able to get to their request.
  
3. I'm not sure if I qualify for the Will Clinic, what can be counted as an asset?
  + For a description of what can be considered an asset, please review [**this**](https://www.sapling.com/12085934/examples-personal-assets) helpful article.
4. I've completed my application, now what?
  + Once your application is completed, you will still have to search for a lawyer. This button can be found on the user's landing page.
  
5. As a veteran, how many times can I use the Washington Will Clinic?
  + A veteran can only have one active application at a time, but if the veteran needs to update their will again at a later date and they still qualify for assistance, a veteran can always reuse the Washington Veterans Will Clinic's services.

6. A lot of this information is sensitive, are my documents protected?
  + Security is an important issue for all people involved. All accounts are secured, with user information hidden.
  
## [Reporting Issues/Bugs](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)
If users encounter any issues or bugs while using this site, they can be reported through the issues tab found [here]()

## [Change Log](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)
### Iteration 2
- Intake form updated for ease and readability
- Basic matching by selected library complete (TODO range matching)
- About and resources pages updated
- Leagal documents built out into viable CSS
- Coloc schema update to change with logged in user type
- Attorney validation partial implimented. (TODO Intigrate email confirmation if Attorney has not registered an email)
- Veteran validation offloaded to Attorney at meeting time.

## [License](https://github.com/Will-Clinic/WA-Will-Clinic/new/master?readme=1#table-of-contents)
MIT Licensed

## Resources
https://css-tricks.com/almanac/properties/p/page-break/