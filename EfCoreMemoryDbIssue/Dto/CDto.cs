using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreMemoryDbIssue.Dto
{
    public class CDto
    {
        public int Id { get; set; }

        public int CId { get; set; }

        public string SomeText { get; set; }
    }
}
