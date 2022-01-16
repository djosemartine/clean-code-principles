public abstract class User
{
  public string FirstName;
  public string LastName;
  public UserStatus Status;
  public abstract void Login { get; }
}

public class ActiveUser : User
{
  public override void Login()
  {
    // Login as active user
  }
}

public class InactiveUser : User
{
  public override void Login()
  {
    // Login as inactive user
  }
}

public class LockedUser : User
{
  public override void Login()
  {
    // Login as locked user
  }
}