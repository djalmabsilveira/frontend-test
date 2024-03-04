using Microsoft.AspNetCore.Mvc;
using WebApplication_Teste.DataAccess;
using WebApplication_Teste.Models;

namespace WebApplication_Teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyDAO _companyDAO;

        public CompanyController(CompanyDAO companyDAO)
        {
            _companyDAO = companyDAO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var companies = await _companyDAO.GetCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyDAO.GetCompanyAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return company;
        }

        [HttpPost]
        public async Task<IActionResult> PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _companyDAO.AddCompanyAsync(company);
            return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest("O ID da empresa na URL não corresponde ao ID da empresa no corpo da solicitação.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var updated = await _companyDAO.UpdateCompanyAsync(id, company);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var deleted = await _companyDAO.DeleteCompanyAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
