using DEME.BizTalk.Assistant.Models.Database.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// Gets a business process from the database based ona linq query
        /// </summary>
        /// <param name="p">Query on which to base the select</param>
        /// <returns></returns>
        public BusinessProcess GetOne(Func<BusinessProcess, bool> p)
        {
            try
            {
                _logger.LogInformation($"Getting a business processes from database {p.ToString()}");
                return _context.BusinessProcessDbSet.Where(p).Single();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not get business processes from database {p.ToString()}", ex);
                return null;
            }
        }

        /// <summary>
        /// Get all business processes from the database based on linq query
        /// </summary>
        /// <param name="p">Linq query to define where clause</param>
        /// <returns></returns>
        public IEnumerable<BusinessProcess> GetAll(Func<BusinessProcess, bool> p)
        {
            try
            {
                _logger.LogInformation($"Getting all business processes from database {p.ToString()}");
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
    }
}
