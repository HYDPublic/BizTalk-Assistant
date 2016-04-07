using DEME.BizTalk.Assistant.Models.Database.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;

namespace DEME.BizTalk.Assistant.Models.Database.Repository
{
    public class AssistantRepository : IAssistantRepository
    {
        private AssistantContext _context;
        private ILogger<AssistantRepository> _logger;

        public AssistantRepository(AssistantContext context, ILogger<AssistantRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region Business process

        /// <summary>
        /// Gets a business process from the database based on a linq query
        /// </summary>
        /// <param name="p">Query on which to base the select</param>
        /// <returns></returns>
        public BusinessProcess GetOneBusinessProcess(Func<BusinessProcess, bool> p)
        {
            try
            {
                _logger.LogInformation($"Getting a business process from database");
                return _context.BusinessProcessDbSet.Where(p).Single();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not get business process from database", ex);
                return null;
            }
        }

        /// <summary>
        /// Get all business processes from the database based on a linq query
        /// </summary>
        /// <param name="p">Linq query to define where clause</param>
        /// <returns></returns>
        public IEnumerable<BusinessProcess> GetAllBusinessProcesses(Func<BusinessProcess, bool> p)
        {
            try
            {
                _logger.LogInformation($"Getting all business processes from database");
                return _context.BusinessProcessDbSet.Where(p).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get business processes from database", ex);
                return null;
            }
        }

        /// <summary>
        /// Add a business process to the database
        /// </summary>
        /// <param name="businessProcess">The business process to add</param>
        public void Add(BusinessProcess businessProcess)
        {
            try
            {
                _logger.LogInformation($"Add a business process ({businessProcess.Source} - {businessProcess.Process} - {businessProcess.Destination}) to the database");

                _context.BusinessProcessDbSet.Add(businessProcess);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not add business process ({businessProcess.Source} - {businessProcess.Process} - {businessProcess.Destination}) to database", ex);
            }
        }

        /// <summary>
        /// Update a business process from the database
        /// </summary>
        /// <param name="businessProcess">The business process to update</param>
        public void Update(BusinessProcess businessProcess)
        {
            try
            {
                _logger.LogInformation($"Update a business process ({businessProcess.Source} - {businessProcess.Process} - {businessProcess.Destination}) to the database");

                _context.Update(businessProcess);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not update business process ({businessProcess.Source} - {businessProcess.Process} - {businessProcess.Destination}) to database", ex);
            }
        }

        /// <summary>
        /// Remove a business process from the database
        /// </summary>
        /// <param name="businessProcess">The business process to remove</param>
        public void Remove(BusinessProcess businessProcess)
        {
            try
            {
                _logger.LogInformation($"Remove a business process ({businessProcess.Source} - {businessProcess.Process} - {businessProcess.Destination}) to the database");

                _context.Remove(businessProcess);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not remove business process ({businessProcess.Source} - {businessProcess.Process} - {businessProcess.Destination}) to database", ex);
            }
        }
        #endregion

        #region Routing

        /// <summary>
        /// Gets a routing from the database based on a linq query
        /// </summary>
        /// <param name="p">Query on which to base the select</param>
        /// <returns></returns>
        public Routing GetOneRouting(Func<Routing, bool> p)
        {
            try
            {
                _logger.LogInformation($"Getting a routing from database");
                return _context.RoutingDbSet.Include(r => r.Source).Include(r => r.Destination).Where(p).Single();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not get routing from database", ex);
                return null;
            }
        }

        /// <summary>
        /// Get all routings from the database based on a linq query
        /// </summary>
        /// <param name="p">Linq query to define where clause</param>
        /// <returns></returns>
        public IEnumerable<Routing> GetAllRouting(Func<Routing, bool> p)
        {
            try
            {
                _logger.LogInformation($"Getting all routings from database");
                return _context.RoutingDbSet.Include(r => r.Source).Include(r => r.Destination).Where(p).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get routings from database", ex);
                return null;
            }
        }

        /// <summary>
        /// Add a routing to the database
        /// </summary>
        /// <param name="businessProcess">The routing to add</param>
        public void Add(Routing routing)
        {
            try
            {
                _logger.LogInformation($"Add a routing to the database");

                _context.RoutingDbSet.Add(routing);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not add routing to database", ex);
            }
        }

        /// <summary>
        /// Update a routing from the database
        /// </summary>
        /// <param name="businessProcess">The routing to update</param>
        public void Update(Routing routing)
        {
            try
            {
                _logger.LogInformation($"Update a routing to the database");

                _context.RoutingDbSet.Update(routing);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not update routing to database", ex);
            }
        }


        /// <summary>
        /// Remove a routing from the database
        /// </summary>
        /// <param name="businessProcess">The routing to remove</param>
        public void Remove(Routing routing)
        {
            try
            {
                _logger.LogInformation($"Remove a routing from the database");

                _context.RoutingDbSet.Remove(routing);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not remove routing from database", ex);
            }
        }
        #endregion
    }
}
