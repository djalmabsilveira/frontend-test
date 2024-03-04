using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication_Teste.Dao.DataAccess;
using WebApplication_Teste.Models;

namespace WebApplication_Teste.DataAccess
{
    public class CompanyDAO
    {
        private readonly Context _context;

        public CompanyDAO(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _context.Company.ToListAsync();
        }

        public async Task<ActionResult<Company>> GetCompanyAsync(int id)
        {
            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return new NoContentResult();
            }
            return company;
        }


        public async Task AddCompanyAsync(Company company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCompanyAsync(int id, Company company)
        {
            if (id != company.Id)
            {
                return false;
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return false;
            }

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(company => company.Id == id);
        }
    }
}
