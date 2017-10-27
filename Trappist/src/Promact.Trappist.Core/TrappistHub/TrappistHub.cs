﻿using Microsoft.AspNetCore.SignalR;
using Promact.Trappist.DomainModel.DbContext;
using Promact.Trappist.DomainModel.Models.TestConduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Promact.Trappist.Core.TrappistHub
{
    public class TrappistHub : Hub
    {
       /// <summary>
       /// This method gets the generated report of the candidate and then sends back to the report display page 
       /// </summary>
       /// <param name="testAttendee"></param>
       /// <returns>Sends the testAttendee object to getReport method in client side</returns>
        public Task SendReport(TestAttendees testAttendee)
        {
            return Clients.All.InvokeAsync("getReport", testAttendee);
        }

        /// <summary>
        /// This method gets the id of the candidate who requests for resume test and pass this id to getAttendeeIdWhoRequestedForResumeTest method in test report page
        /// </summary>
        /// <param name="attendeeId"></param>
        /// <returns>invokes the method getAttendeeIdWhoRequestedForResumeTest and pass the id in test report page</returns>
        public Task SendCandidateIdWhoRequestedForResumeTest(int attendeeId)
        {
            return Clients.All.InvokeAsync("getAttendeeIdWhoRequestedForResumeTest", attendeeId);
        }
    }
}
