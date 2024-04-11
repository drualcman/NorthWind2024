namespace NorthWind.Membership.Entities.Dtos.UserRegistration;
public class UserRegistrationDto
{
    public string Email { get;  }
    public string Password { get;  }
    public string FirstName { get;  }
    public string LastName { get;  }

    public UserRegistrationDto(string email, string password, string firstName, string lastName)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }
}
