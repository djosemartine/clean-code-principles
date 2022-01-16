// 1.
void StupidBooleanComparison()
{
  if (loggedIn == true) { }
}
void CompareBooleansImplicitly()
{
  if (loggedIn) { }
}

// 2.
void StupidBooleanAssignment()
{
  bool goingToTakeTheBus;
  if (cashInWallet >= 1.25)
  {
    goingToTakeTheBus = true;
  }
  else
  {
    goingToTakeTheBus = false;
  }
}

void AssignBooleansImplicitly()
{
  bool goingToTakeTheBus = cashInWallet >= 1.25;
}

// 3.
void DoNotBeAntiNegative()
{
  if (!isNotLoggedIn) { }
}

void BePositive()
{
  if (loggedIn) { }
}

// 4.Ternay operators

/// <summary>
///   Do not Repeat Yourself
///   YAGNI You Ain't Gonna Need It
/// </summary>
void StupidConditional()
{
  int registrationFee;
  if (isSpeaker)
  {
    registrationFee = 0;
  }
  else
  {
    registrationFee = 25;
  }
}

void PreferTernary()
{
  int registrationFee = isSpeaker ? 0 : 25;
}

// 5.Be Strongly Typed, Not "Stringly" Typed
void StringlyTyped()
{
  if (employeeType == "Manager") { }
}

/// <summary>
///   No Typos, searchable, and replaceable
///    
/// </summary>
void StronglyTyped()
{
  if (employee.Type == EmployeeType.Manager) { }
}

// 6. Avoid Magic Numbers
void MagicNumbers()
{
  if (age >= 21) { }

  if (employee.Type == 2) { }
}

void AvoidMagicNumbers()
{
  const int legalAge = 21;
  if (age >= legalAge) { }

  if (employee.Type == EmployeeType.Manager) { }
}

// 7. Avoid complex conditionals

void ComplexConditional()
{
  if (employee.Age > 55
    && employee.YearsEmployed > 10
    && employee.IsRetired == true) { }

  if ((fileExt == ".mp4"
      || fileExt == ".mpg"
      || fileExt == ".avi")
      && (isAdmin == true || isEditor == true)) { }
}

void ComplexConditional()
{
  const int MinimumAgeForPension = 55;
  const int MinimumYearsEmployed = 10;
  bool eligibleForPension =
    employee.Age > MinimumAgeForPension
    && employee.YearsEmployed > MinimumYearsEmployed
    && employee.IsRetired;
  if (eligibleForPension) { }

  if (ValidFileRequest(fileExtension, isEditor, isAdmin)) { }
}

bool ValidFileRequest(string fileExtension, bool isEditor, bool isAdmin)
{
  var validFileExtensions = new List<string>() { ".mp4", ".mpg", ".avi" };

  bool validFileType = validFileExtensions.Contains(fileExtension);
  bool userIsAllowedToViewFile = isAdmin || isEditor;
  return validFileType && userIsAllowedToViewFile;
}

// 8. Favor Polymorphism over switch statements

void StupidLoginUser(User user)
{
  switch (user.Status)
  {
    case UserStatus.Active:
      // Active user
      break;
    case UserStatus.Inactive:
      // Inactive user
      break;
    case UserStatus.Locked:
      // Locked user
      break;
    default:
  }
}

void LoginUser(User user)
{
  user.Login();
}


// 9. Be declarative
List<User> NonDeclarative()
{
  var matchingUsers = new List<User>();
  foreach (var user in users)
  {
    if (user.AccountBalance < minAccountBalance
      && user.Status == UserStatus.Active)
    {
      matchingUsers.Add(user);
    }
  }
  return matchingUsers;
}

List<ActiveUser> BeDeclarative(List<User> users)
{
  return users
        .Where(user => user.AccountBalance < minAccountBalance)
        .Where(user => user.Status == UserStatus.Active);
}

// 10. Table Driven Methods

decimal StupidConditionals(int age){
  if(age < 20){
    return 345.60m;
  }
  else if(age < 30){
    return 419.50m;
  }
  else if(age < 40){
    return 500.00m;
  }
  else{
    return 595.00m;
  }
}

// Create InsuranceRate table

decimal GetInsuranceRate(int age)
{
  var rates = new Dictionary<int, decimal>()
  {
    { 20, 345.60m },
    { 30, 419.50m },
    { 40, 500.00m },
    { 50, 595.00m }
  };
  return rates[age];
}