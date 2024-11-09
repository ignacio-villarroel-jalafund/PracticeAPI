using FirstAPi.Domain.DTOs;
using FirstAPi.Domain.Entities;
using FirstAPi.Repositories.Interfaces;
using FirstAPi.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace FirstAPi.Services.Concretes;

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _toDoRepository;

    public ToDoService(IToDoRepository todoRepository)
    {
        _toDoRepository = todoRepository;
    }

    public async Task<ToDo> AddToDoAsync(ToDoDTO toDo)
    {
        var newToDo = new ToDo
        {
            Title = toDo.Title,
            Description = toDo.Description,
            IsCompleted = toDo.IsCompleted
        };

        var result = await _toDoRepository.CreateAsync(newToDo);

        if (result == null)
        {
            throw new ArgumentException("Failed to create news");
        }

        return result;
    }

    public async Task<bool> DeleteToDoAsync(int id)
    {
        var toDo = await _toDoRepository.GetByIdAsync(id);

        if (toDo == null)
        {
            throw new ArgumentException("ToDo not found");
        }

        return await _toDoRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ToDo>> GetAllToDo()
    {
        return await _toDoRepository.GetAllAsync();
    }

    public async Task<ToDo?> GetToDoByIdAsync(int id)
    {
        var toDo = await _toDoRepository.GetByIdAsync(id);

        if (toDo == null)
        {
            throw new ArgumentException("ToDo not found");
        }

        return toDo;
    }

    public async Task<ToDo> UpdateToDoAsync(int id, ToDoDTO toDo)
    {
        var updateToDo = await _toDoRepository.GetByIdAsync(id);

        if (updateToDo == null)
        {
            throw new ArgumentException("Todo to update not found");
        }

        updateToDo.Title = toDo.Title != "" ? toDo.Title : updateToDo.Title;
        updateToDo.Description = toDo.Description;
        updateToDo.IsCompleted = toDo.IsCompleted;

        var result = await _toDoRepository.UpdateAsync(updateToDo);

        if (result == null)
        {
            throw new ArgumentException("Failed to update ToDo");
        }

        return result;
    }
}