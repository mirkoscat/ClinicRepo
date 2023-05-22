using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
	public class DataDbContext:DbContext
	{
        
        public DataDbContext(DbContextOptions<DataDbContext> opt):base(opt) 
        {
            
        }
    }
}
