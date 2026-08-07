using Microsoft.AspNetCore.Mvc;

namespace EquipIT.Api.Controllers;

[ApiController]
[Route("api/equipment")]
public class EquipmentController : ControllerBase
{
    // TODO: Implement GET and PUT endpoints. Create a DTO to retrieve FirstName and LastName from the borrowing form.

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:int}/borrow")]
    public async Task<IActionResult> Borrow(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:int}/return")]
    public async Task<IActionResult> Return(int id)
    {
        throw new NotImplementedException();
    }
}
