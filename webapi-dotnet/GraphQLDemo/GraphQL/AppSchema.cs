using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLDemo.GraphQL.Queries;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL
{
    public class AppSchema : Schema
    {
        public AppSchema(EmployeeQuery query)
        {
            this.Query = query;
        }
    }
}