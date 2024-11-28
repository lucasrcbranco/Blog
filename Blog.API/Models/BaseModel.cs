namespace Blog.API.Models;

public class BaseModel<T> 
{
    public T? Id { get; private set; }

    public BaseModel()
    {
        if(Id is Guid)
        {
            Id = (T)(object)Guid.NewGuid();
        }
        else
        {
            Id = default;
        }
    }
}
