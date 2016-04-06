using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEME.BizTalk.Assistant.Models.Database.Context
{
    public class AssistantContextSeedData
    {
        private AssistantContext _context;

        public AssistantContextSeedData(AssistantContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (!_context.BusinessProcessDbSet.Any())
            {
                BusinessProcess bp1 = new BusinessProcess
                {
                    Source = "AX",
                    Process = "Budget",
                    Destination = "Routing"
                };
                _context.BusinessProcessDbSet.Add(bp1);

                BusinessProcess bp2 = new BusinessProcess
                {
                    Source = "AX",
                    Process = "Employee",
                    Destination = "Routing"
                };
                _context.BusinessProcessDbSet.Add(bp2);

                BusinessProcess bp3 = new BusinessProcess
                {
                    Source = "AX",
                    Process = "Budget",
                    Destination = "Amos"
                };
                _context.BusinessProcessDbSet.Add(bp3);


                BusinessProcess bp4 = new BusinessProcess
                {
                    Source = "AX",
                    Process = "Budget",
                    Destination = "Gorsele"
                };
                _context.BusinessProcessDbSet.Add(bp4);

                _context.RoutingDbSet.Add(new Routing
                {
                    Source = bp1,
                    ChangeType = "Name",
                    Destination = bp3
                });

               _context.SaveChanges();
            }
        }
    }
}
