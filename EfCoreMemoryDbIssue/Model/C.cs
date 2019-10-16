using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreMemoryDbIssue.Model
{
    public class C
    {
        public int Id { get; set; }

        public int BId { get; set; }

        public string SomeText { get; set; }


        public B B { get; set; }
    }
}
