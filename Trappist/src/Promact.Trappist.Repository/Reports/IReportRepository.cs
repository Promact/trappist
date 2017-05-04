﻿using Promact.Trappist.DomainModel.Models.Test;
using Promact.Trappist.DomainModel.Models.TestConduct;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promact.Trappist.Repository.Reports
{
    public interface IReportRepository
    {
        /// <summary>
        /// Method to get the details of all the Test-Attendees of the respective test
        /// </summary>
        /// <param name="testId">Id of the respective test</param>
        /// <returns>All test attendees of that respective test</returns>
        Task<IEnumerable<TestAttendees>> GetAllTestAttendeesAsync(int id);

        /// <summary>
        /// Method to set a candidate as Starred candidate
        /// </summary>
        /// <param name="id">Id of the candidate</param>
        /// <returns>Attendee Id</returns>
        Task SetStarredCandidateAsync(int id);

        /// <summary>
        /// Method to set all candidates with matching criteria as starred candidate
        /// </summary>
        /// <param name="status">Star status of the candidates</param>
        /// <param name="selectedTestStatus">Test end status of the candidates</param>
        /// <param name="searchString">The search string provided by the user</param>
        /// <returns>Star status of the candidates</returns>
        Task SetAllCandidateStarredAsync(bool status, int selectedTestStatus, string SearchString);

        /// <summary>
        /// Method to check whether a candidate exist or not
        /// </summary>
        /// <param name="attendeeId">Id of the candidate</param>
        /// <returns></returns>
        Task <bool> IsCandidateExistAsync(int attendeeId);
        
        /// <summary>
        ///Method to get test name 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Test> GetTestNameAsync(int id);
    }
}
