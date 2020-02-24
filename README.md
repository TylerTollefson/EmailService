# UniqueEmailService
Simple ASP .NET Core webservice that gets a unique count of emails, provided a list of emails.
Expanding into an email validation service that can validate a single email or a list of emails.

POST Methods:

RetrieveUnqiueCount - Provided a list of emails, it will return the amount of unique emails in the list.

TODO - isValidEmail - Provided a single email, will return whether or not the email is valid.

TODO - isValidEmailBatch - Provided a list of emails, will return an object that states whether the whole list is valid, and a list of invalid emails if they exist.
