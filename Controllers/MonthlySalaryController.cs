using HRMSAPPLICATION.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMSAPPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlySalaryController : ControllerBase
    {
        HrmsystemContext _context;
        public MonthlySalaryController(HrmsystemContext context)
        {
            _context = context;
        }
        [HttpGet("{year},{month},{empid}")]   

        public Object Get(int year,int month,int empid) {

            Console.WriteLine(year+":"+month+":"+empid);

            var salary = _context.Database.SqlQueryRaw<Double>("EXEC CalculateMonthlySalaryForMonthYear @Year =" + year + ", @Month  =" + month + ", @EmployeeId =" + empid + ";");
            return salary;
        
        }  
        
    }
}
