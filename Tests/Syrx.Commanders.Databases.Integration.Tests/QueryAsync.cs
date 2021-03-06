﻿//  ============================================================================================================================= 
//  author       : david sexton (@sextondjc | sextondjc.com)
//  date         : 2017.09.29 (21:39)
//  modified     : 2017.10.01 (20:40)
//  licence      : This file is subject to the terms and conditions defined in file 'LICENSE.txt', which is part of this source code package.
//  =============================================================================================================================

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Syrx.Tests.Models;
using Xunit;
using static Xunit.Assert;

namespace Syrx.Commanders.Databases.Integration.Tests
{
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public abstract partial class QueryAsync
    {
        protected QueryAsync(QueryAsyncFixture serverFixture)
        {
            _commander = serverFixture.Commander;
        }

        private readonly ICommander<QueryAsync> _commander;

        [Fact]
        public async Task ExceptionsAreReturnedToCaller()
        {
            var result = await ThrowsAnyAsync<Exception>(() => _commander.QueryAsync<int>());
            const string expected = "22012: division by zero";
            Equal(expected, result.Message);
        }

        [Fact]
        public async Task OneTypeWithNoParameters()
        {
            var result = await _commander.QueryAsync<PocoA>();
            NotNull(result);
            True(result.Any());
        }

        [Fact]
        public async Task OneTypeWithParameters()
        {
            var result = await _commander.QueryAsync<PocoA>(new {Id = 3});
            NotNull(result);
            True(result.Any());
            Single(result);

            // check values 
            var first = result.First();
            Equal(3, first.PocoA_Id);
            Equal("A13", first.Name);
            Equal(17, first.Value);
        }

        [Fact]
        public void SupportsCancellationToken()
        {
            var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));

            var task = _commander.QueryAsync<int>(cancellationToken: tokenSource.Token);
            var exception = Throws<AggregateException>(() => task.Wait(TimeSpan.FromSeconds(5)));
            var innerExceptions = exception.InnerExceptions;
            Single(innerExceptions);
            IsAssignableFrom<Exception>(innerExceptions.Single());
            const string expected =
                "57014: canceling statement due to user request";
            Equal(expected, innerExceptions.Single().Message);
        }
    }
}