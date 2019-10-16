using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreMemoryDbIssue.Model
{
    public class B
    {
        public int Id { get; set; }

        public List<C> PropertyCList { get; set; }
    }
}
