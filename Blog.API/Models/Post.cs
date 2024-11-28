namespace Blog.API.Models;

public class Post : BaseModel<Guid>
{
    public Guid AuthorId { get; private set; }
    public Author? Author { get; private set; }

    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;
    public DateTime PostedAt { get; private set; } = DateTime.UtcNow;

    public Post(
        Guid authorId,
        string title,
        string content)
    {
        Validate(title, content);

        AuthorId = authorId;
        Title = title;
        Content = content;
    }

    public void Update(string title, string content)
    {
        Validate(title, content);

        Title = title;
        Content = content;
    }

    private static void Validate(string title, string content)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));
        ArgumentNullException.ThrowIfNullOrEmpty(content, nameof(content));

        Guards.ValidateStringLentgh(title, 5, 260);
        Guards.ValidateStringLentgh(content, 1, 3000);
    }
}
