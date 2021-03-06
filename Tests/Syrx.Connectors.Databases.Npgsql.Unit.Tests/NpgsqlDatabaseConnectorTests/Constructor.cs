﻿//  ============================================================================================================================= 
//  author       : david sexton (@sextondjc | sextondjc.com)
//  date         : 2017.09.29 (21:39)
//  modified     : 2017.10.01 (20:41)
//  licence      : This file is subject to the terms and conditions defined in file 'LICENSE.txt', which is part of this source code package.
//  =============================================================================================================================

using System;
using System.Collections.Generic;
using Syrx.Settings.Databases;
using Xunit;
using static Xunit.Assert;

namespace Syrx.Connectors.Databases.Npgsql.Unit.Tests.NpgsqlDatabaseConnectorTests
{
    public class Constructor
    {
        private readonly IDatabaseCommanderSettings _settings;
        public Constructor()
        {
            _settings = new DatabaseCommanderSettings(
                new List<DatabaseCommandNamespaceSetting>
                {
                    new DatabaseCommandNamespaceSetting(
                        typeof(DatabaseCommandNamespaceSetting).Namespace,
                        new List<DatabaseCommandTypeSetting>
                        {
                            new DatabaseCommandTypeSetting(
                                typeof(DatabaseCommandTypeSetting).FullName,
                                new Dictionary<string, DatabaseCommandSetting>
                                {
                                    ["Retrieve"] =
                                    new DatabaseCommandSetting("test.alias", "select 'Readers.Test.Settings'")
                                })
                        })
                }
                , new List<ConnectionStringSetting>
                {
                    new ConnectionStringSetting("test.alias", "connectionString")
                });
        }        

        [Fact]
        public void NullSettingsThrowsArgumentNullException()
        {
            var result = Throws<ArgumentNullException>(() => new NpgsqlDatabaseConnector(null));
            Equal("Value cannot be null.\r\nParameter name: settings", result.Message);
        }

        [Fact]
        public void Successfully()
        {
            var result = new NpgsqlDatabaseConnector(_settings);
            NotNull(result);
        }
    }
}