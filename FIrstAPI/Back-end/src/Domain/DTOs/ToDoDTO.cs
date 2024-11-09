using FirstAPi.Domain.Entities;

namespace FirstAPi.Domain.DTOs;

public record ToDoDTO
(
    string Title,
    string Description,
    bool IsCompleted
)
{
    public ToDo ToDomain()
    {
        return new ToDo
        {
            Title = Title,
            Description = Description,
            IsCompleted = IsCompleted
        };
    }
}