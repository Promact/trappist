﻿using Promact.Trappist.DomainModel.ApplicationClasses.Question;
using System.Collections.Generic;

namespace Promact.Trappist.DomainModel.ApplicationClasses.Test
{
   public class TestAC
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public List<CategoryAC> CategoryAcList { get; set; }
    }
}
