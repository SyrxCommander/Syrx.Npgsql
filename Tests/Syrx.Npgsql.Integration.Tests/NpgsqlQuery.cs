//  ============================================================================================================================= 
//  author       : david sexton (@sextondjc | sextondjc.com)
//  date         : 2017.09.29 (21:39)
//  modified     : 2017.10.01 (20:41)
//  licence      : This file is subject to the terms and conditions defined in file 'LICENSE.txt', which is part of this source code package.
//  =============================================================================================================================

using Syrx.Commanders.Databases.Integration.Tests;
using Xunit;

namespace Syrx.Npgsql.Integration.Tests
{
    [Collection("Syrx.Npgsql.Query")]
    public class NpgsqlQuery : Query
    {
        public NpgsqlQuery(NpgsqlQueryFixture serverFixture) : base(serverFixture)
        {            
        }
    }
}