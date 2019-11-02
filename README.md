## NeedleBuddy (working title)
Discarded needles aren't anyone's buddy; :syringe: this app can help! :calling:

Our smartphone-friendly Progressive Web Application can be at your fingertips, so the next time you spot a discarded needle, you can report it right away. Don't worry about having to exhaustively describe its location, the app will pick up for current GPS coordinates and report them to a friendly volunteer. Once they are able to collect the needle, you will receive a text message indicating it was successful; they may use your phone number to ask follow-up questions.

Are you feeling confident? Our app will also link you to the [Safe Needle Disposal](https://www.regina.ca/home-property/safety-emergencies/safe-needle-disposal/) walkthrough, and provide you with a list of possible drop-off sites.

### Installation
1. Needlebuddy requires Node, Postgress 11.5, and .NET Core 3.0
2. Run the included database table creation script
3. Add the following entries to your appsettings.json file:
```
  "SwiftBaseUrl": "http://smsgateway.ca/services/message.svc/",
  "SigningKey": "<your confidential signing key (also update in database)>",
  "ConnectionStrings": {
    "NeedleBuddyDatabase": "<your postgres connection string>"
  },
```
4. Run `npm build` and `npm start` to initialize the front-end
5. Run `dotnet build` and `dotnet run` to initialize the back-end
