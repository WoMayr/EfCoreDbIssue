using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreMemoryDbIssue.Dto
{
    public class ADto
    {
        public int Id { get; set; }

        public BDto PropertyB { get; set; }

        public int PropertyBId { get; set; }
    }
}
