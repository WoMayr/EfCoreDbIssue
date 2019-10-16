using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreMemoryDbIssue.Model
{
    public class A
    {
        public int Id { get; set; }

        public B PropertyB { get; set; }

        public int PropertyBId { get; set; }
    }
}
