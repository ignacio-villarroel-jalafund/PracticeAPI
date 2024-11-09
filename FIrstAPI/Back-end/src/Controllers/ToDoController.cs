using FirstAPi.Domain.DTOs;
using FirstAPi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPi.Controllers;

public class ToDoController : BaseController
{
    private readonly IToDoService _toDoService;

    public ToDoController(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseToDoDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddToDo([FromBody] ToDoDTO toDo)
    {
        var newToDo = await _toDoService.AddToDoAsync(toDo);
        var response = ResponseToDoDTO.FromDomain(newToDo);
        return CreatedAtAction(nameof(GetToDoById), new { Id = newToDo.Id }, response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseToDoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetToDoById(int id)
    {
        var toDo = await _toDoService.GetToDoByIdAsync(id);
        if (toDo == null)
        {
            return NotFound("To Do not found.");
        }

        var response = ResponseToDoDTO.FromDomain(toDo);

        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ResponseToDoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateToDO(int id, [FromBody] ToDoDTO toDo)
    {
        var updatedToDo = await _toDoService.UpdateToDoAsync(id, toDo);
        var response = ResponseToDoDTO.FromDomain(updatedToDo);

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseToDoDTO), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAllToDo()
    {
        var allToDo = await _toDoService.GetAllToDo();
        var response = allToDo.Select(toDo => ResponseToDoDTO.FromDomain(toDo));

        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteToDo(int id)
    {
        await _toDoService.DeleteToDoAsync(id);

        const string message = "To Do deleted succesfully";

        return Ok(message);
    }
}