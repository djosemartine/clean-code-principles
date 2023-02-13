# Functions vs Methods
Both are pieces of code, called by name. Methods are associated with an object.

# When to create a function
Duplications, indentation, unclear intent, multiple task

# Eliminate indentation

## Use a return when it enhances readability
In certain routines, once you know the answer, you want to return it to the calling routine immediately. If the routine is defined in such a way that it doesn't require any further cleanup once it detects an error, not returning immediately means that you have to write more code

## Mayfly variables
Initializes variables jus-int-ime
Do one thing

## Number of parameters
Strive for 0-2 parameters

## Signs is too long
Whitespace & comments
Scrolling required
Naming issues
Multiple conditionals
Hard to digest

## Handling exceptions
Only catch the exception you can handle. Otherwise crash immediately 
### Unrecoverable
Null reference
Access denied
Not found
Workflow cannot continue
### Recoverable
RetryConnection
Give up at some point
### Ignorable
Logging failed
Optional data not available