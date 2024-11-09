using FirstAPi.Domain.Entities;

namespace FirstAPi.Domain.DTOs;

public record ResponseToDoDTO
(
    int Id,
    string Title,
    string? Description,
    bool IsCompleted
)
{
    public static ResponseToDoDTO FromDomain(ToDo toDo)
    {
        return new ResponseToDoDTO
        (
            toDo.Id,
            toDo.Title,
            toDo.Description,
            toDo.IsCompleted
        );
    }
}