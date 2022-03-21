using Microsoft.AspNetCore.Mvc;

namespace WorkCalculator.Controllers;

[ApiController]
[Route("{studentId}/User/[controller]")]
public class WorkController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Work>> Get(string studentId)
    {
        if (!UserRepository.Users.ContainsKey(studentId)) return NotFound();

        return Ok(UserRepository.Users[studentId].Works);
    }

    [HttpPost]
    public ActionResult<Work> Create(string studentId, WorkModel workModel)
    {
        if (!UserRepository.Users.ContainsKey(studentId)) return NotFound();

        var u = UserRepository.Users[studentId];

        var entity = new Work
        {
            Id = Guid.NewGuid(),
            From = workModel.From,
            To = workModel.To,
            Note = workModel.Note,
            Wage = u.Settings.Wage
        };
        u.Works.Add(entity);

        return Ok(entity);
    }

    [HttpDelete]
    [Route("{workId:guid}")]
    public IActionResult Delete(string studentId, Guid workId)
    {
        if (!UserRepository.Users.ContainsKey(studentId)) return NotFound();

        var entity = UserRepository.Users[studentId].Works.Find(work => work.Id == workId);
        if (entity == null) return NotFound();

        UserRepository.Users[studentId].Works.Remove(entity);

        return NoContent();
    }
}