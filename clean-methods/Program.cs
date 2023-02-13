if (condition1)
{
  if (condition2)
  {
    // do something complicated
  }
}

if (condition1)
{
  if (condition2)
  {
    DoSomethingComplicated();
  }
}

// Fail fast
static void RegisterUser(string userName, string password)
{
  if (!string.IsNullOrWhiteSpace(userName))
  {
    if (!string.IsNullOrWhiteSpace(password))
    {
      // Register the user
    }
    else
    {
      throw new ArgumentException("Password cannot be empty");
    }
  }
  else
  {
    throw new ArgumentException("User name cannot be empty");
  }
}

static void RegisterUser(string userName, string password)
{
  if (string.IsNullOrWhiteSpace(userName))
  {
    throw new ArgumentException("User name cannot be empty");
  }
  if (string.IsNullOrWhiteSpace(password))
  {
    throw new ArgumentException("Password cannot be empty");
  }
  // Register the user
}

static bool IsValidStupid(string userName)
{
  bool isValid = false;
  const int minUserLength = 3;
  if (userName.Length >= minUserLength)
  {
    const int maxUserLength = 20;
    if (userName.Length <= maxUserLength)
    {
      bool isAlphaNumeric = userName.All(char.IsLetterOrDigit);
      if (isAlphaNumeric)
      {
        if (!ContainsCursedWord(userName))
        {
          isValid = IsUniqueUsername(userName);
        }
      }
    }
  }
  return isValid;
}

static bool isValid(string username)
{
  const int minUserLength = 3;
  if (username.Length < minUserLength) return false;
  const int maxUserLength = 20;
  if (username.Length > maxUserLength) return false;
  bool isAlphaNumeric = username.All(char.IsLetterOrDigit);
  if (!isAlphaNumeric) return false;
  if (ContainsCursedWord(username)) return false;
  return IsUniqueUsername(username);
}
