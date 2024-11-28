namespace Blog.API.Models;

public class Author : BaseModel<Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string FullName => $"{FirstName.ToTitleCase()} {LastName.ToTitleCase()}";

    public Author(string firstName, string lastName)
    {
        FirstName = firstName.ToTitleCase();
        LastName = lastName.ToTitleCase();
    }

    public void Update(string firstName, string lastName)
    {
        Validate(firstName, lastName);

        FirstName = firstName.ToTitleCase();
        LastName = lastName.ToTitleCase();
    }


    private static void Validate(string firstName, string lastName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(firstName, nameof(firstName));
        ArgumentNullException.ThrowIfNullOrEmpty(lastName, nameof(lastName));

        Guards.ValidateStringLentgh(firstName, 5, 30);
        Guards.ValidateStringLentgh(lastName, 5, 60);
    }
}
