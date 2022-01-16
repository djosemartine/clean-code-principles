## Why naming matters?

> Understanding the programmers intent is the biggest problem
- The name should say it all
- Use specific class names, method names, functions, variables

## Classes
### Stupid names
WebsiteBO
Utilities
Common
MyRulesFunctions
AbleUtils
*Manager / *Processor / *Info

### Class Naming Guidelines
- Good class names are nouns, not verbs
- Be specific
- Single responsibility
- Avoid generic suffixes
- Avoid abbreviations
User
Product
CertificateOfIntegrity

## Methods
Use self-explanatory in which the reader does not need to read the method to know what it does
### Stupid names
Go
Complete
ProcessAsync
DoIt
Start
onInit

### Clean names
GetActiveUsers
IsValidSubmission
SendEmail
PrintDocument

> Explain what the class/method does out loud. 
Am I describing one thing?

## Avoid side effects
Check password should not logout the user
Save the User should not send an e-mail
Make sure your method name does not lie to the reader

## Naming Warning signs
And, Or, If
AccessOrDeny
CreateOrDelete
SendAndPublish

## Avoid abbreviations
RegUsr
RegisterUser

## Naming booleans
open    isOpen
start   done
status  isActive
login   loggedIn

# References
- https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions