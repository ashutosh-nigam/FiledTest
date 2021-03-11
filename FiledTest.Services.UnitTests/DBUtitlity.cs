using System;
using System.Collections.Generic;
using System.Text;

namespace FiledTest.Services.UnitTests
{
    public class DBUtitlity
    {
        FiledTest.Data.FiledTestDataContext filedTestDataContext;
        public DBUtitlity()
        {
            filedTestDataContext = new Data.FiledTestDataContext();
        }
    }
}
