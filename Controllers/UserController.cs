using Microsoft.AspNetCore.Mvc;

namespace WorkCalculator.Controllers;

[ApiController]
[Route("{studentId}/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult<UserSettings> Get(string studentId)
    {
        if (!UserRepository.Users.ContainsKey(studentId)) return NotFound();

        return Ok(UserRepository.Users[studentId].Settings);
    }

    [HttpPut]
    public ActionResult<UserSettings> Update(string studentId, UserSettingsModel model)
    {
        if (!UserRepository.Users.ContainsKey(studentId)) return NotFound();

        var s = UserRepository.Users[studentId].Settings;
        s.Wage = model.Wage;
        s.FullName = model.FullName;

        return Ok(s);
    }
}