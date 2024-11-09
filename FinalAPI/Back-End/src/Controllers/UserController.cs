using Microsoft.AspNetCore.Mvc;

public class UserController : BaseController
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseUserDTO), statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddUser([FromBody] RequestUserDTO userDTO)
    {
        var newUser = await _userService.CreateUser(userDTO);
        var response = new ResponseUserDTO
        {
            Id = newUser.Id,
            Name = newUser.Name,
            LastName = newUser.LastName,
            Occupation = newUser.Occupation
        };
        return CreatedAtAction(nameof(GetUserById), new { Id = response.Id }, response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseUserDTO), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUserById(Guid id)
    {
        var existingUser = await _userService.GetUserById(id);

        if (existingUser == null)
        {
            throw new ArgumentException("User not found");
        }

        var response = new ResponseUserDTO
        {
            Id = existingUser.Id,
            Name = existingUser.Name,
            LastName = existingUser.LastName,
            Occupation = existingUser.Occupation
        };
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseUserDTO), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetAllUsers()
    {
        var allUsers = await _userService.GetAllUsers();
        var response = allUsers.Select(user =>
        new ResponseUserDTO
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            Occupation = user.Occupation
        });

        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ResponseUserDTO), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateUser(Guid id, [FromBody] RequestUserDTO userDTO)
    {
        var updatedUser = await _userService.UpdateUser(id, userDTO);
        if (updatedUser == null)
        {
            throw new ArgumentException("User not found");
        }

        var response = new ResponseUserDTO
        {
            Id = updatedUser.Id,
            Name = updatedUser.Name,
            LastName = updatedUser.LastName,
            Occupation = updatedUser.Occupation
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ResponseUserDTO), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUser(Guid id)
    {
        var response = await _userService.DeleteUser(id);
        string message = "User deleted succesfully";
        if (!response)
        {
            message = "An error ocured trying to delete the user";
            return Ok(message);
        }

        return Ok(message);
    }
}