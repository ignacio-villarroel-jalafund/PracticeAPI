using Microsoft.AspNetCore.Mvc;

public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseUser), statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddUser([FromBody] UserDTO userDTO)
    {
        var newUser = await _userService.CreateUserAsync(userDTO);
        var response = ResponseUser.FromDomain(newUser);
        return CreatedAtAction(nameof(GetUserById), new { Id = response.Id }, response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseUser), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUserById(Guid id)
    {
        var existingUser = await _userService.GetUserByIdAsync(id);
        if (existingUser == null)
        {
            throw new ArgumentException("User Not Found");
        }

        var response = ResponseUser.FromDomain(existingUser);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseUser), statusCode: StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAllUser()
    {
        var allUsers = await _userService.GetAllUserAsync();
        var response = allUsers.Select(user => ResponseUser.FromDomain(user));
        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ResponseUser), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UserDTO userDTO)
    {
        var updateUser = await _userService.UpdateUserAsync(id, userDTO);
        if (updateUser == null)
        {
            throw new ArgumentException("User Not Found");
        }
        Console.WriteLine(updateUser.LastName + "asdada");

        var response = ResponseUser.FromDomain(updateUser);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ResponseUser), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeteleUser(Guid id)
    {
        await _userService.DeleteUserAsync(id);

        var response = "User Deleted Succesfuly";
        return Ok(response);
    }
}