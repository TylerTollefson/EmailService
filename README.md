# UniqueEmailService
Simple ASP .NET Core webservice that gets a unique count of emails, provided a list of emails.
Expanding into an email validation service that can validate a single email or a list of emails.

###### How to run:
To test the solution, download it on your machine and debug through visual studio. Once debugging a swagger UI will appear that will allow you to test the methods.

## POST Methods:

RetrieveUnqiueCount - Provided a list of emails, it will return the amount of unique emails in the list.
isValidEmail - Provided an email, will validate it and return true or false depending if it is valid or not

## TODO
- [x] POST method: isValidEmail - Provided a single email, will return whether or not the email is valid.
- [ ] POST method: isValidEmailBatch - Provided a list of emails, will return an object that states whether the whole list is valid, and a list of invalid emails if they exist.
- [ ] Host service and set up dedicated URL
- [ ] Document how to call the service once hosted
