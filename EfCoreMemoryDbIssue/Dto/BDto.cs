using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreMemoryDbIssue.Dto
{
    public class BDto
    {
        public int Id { get; set; }

        public List<CDto> PropertyCList { get; set; }
    }
}
