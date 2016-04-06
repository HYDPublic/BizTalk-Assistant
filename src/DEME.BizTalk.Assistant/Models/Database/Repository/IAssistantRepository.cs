using System;
using System.Collections.Generic;

namespace DEME.BizTalk.Assistant.Models.Database.Repository
{
    public interface IAssistantRepository
    {
        #region BusinessProcess

        /// <summary>
        /// Gets a business process from the database based on a linq query
        /// </summary>
        /// <param name="p">Query on which to base the select</param>
        /// <returns></returns>
        BusinessProcess GetOneBusinessProcess(Func<BusinessProcess, bool> p);

        /// <summary>
        /// Get all business processes from the database based on linq query
        /// </summary>
        /// <param name="p">Linq query to define where clause</param>
        /// <returns></returns>
        IEnumerable<BusinessProcess> GetAllBusinessProcess(Func<BusinessProcess, bool> p);

        /// <summary>
        /// Add a business process to the database
        /// </summary>
        /// <param name="businessProcess">The business process to add</param>
        void Add(BusinessProcess businessProcess);

        /// <summary>
        /// Update a business process from the database
        /// </summary>
        /// <param name="businessProcess">The business process to update</param>
        void Update(BusinessProcess businessProcess);

        /// <summary>
        /// Remove a business process from the database
        /// </summary>
        /// <param name="businessProcess">The business process to remove</param>
        void Remove(BusinessProcess businessProcess);

        #endregion

        #region Routing

        /// <summary>
        /// Gets a routing from the database based on a linq query
        /// </summary>
        /// <param name="p">Query on which to base the select</param>
        /// <returns></returns>
        Routing GetOneRouting(Func<Routing, bool> p);

        /// <summary>
        /// Get all routings from the database based on linq query
        /// </summary>
        /// <param name="p">Linq query to define where clause</param>
        /// <returns></returns>
        IEnumerable<Routing> GetAllRouting(Func<Routing, bool> p);

        /// <summary>
        /// Add a routing to the database
        /// </summary>
        /// <param name="routing">The routing to add</param>
        void Add(Routing routing);

        /// <summary>
        /// Update a routing from the database
        /// </summary>
        /// <param name="routing">The routing to update</param>
        void Update(Routing routing);

        /// <summary>
        /// Remove a routing from the database
        /// </summary>
        /// <param name="routing">The routing to remove</param>
        void Remove(Routing routing);

        #endregion
    }
}
