using FirstAPi.Domain.DTOs;
using FirstAPi.Domain.Entities;

namespace FirstAPi.Services.Interfaces;

public interface IToDoService
{
    Task<ToDo> AddToDoAsync(ToDoDTO toDo);
    Task<ToDo> UpdateToDoAsync(int id, ToDoDTO toDo);
    Task<ToDo?> GetToDoByIdAsync(int id);
    Task<IEnumerable<ToDo>> GetAllToDo();
    Task<bool> DeleteToDoAsync(int id);
}