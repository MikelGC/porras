//------------------------------------------------------------------------------
// <copyright file="CSSqlFunction.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [SqlFunction(
        Name="GetSalt", DataAccess=DataAccessKind.None, 
        IsDeterministic=false, IsPrecise=true, 
        SystemDataAccess=SystemDataAccessKind.None)]
    [return: SqlFacet(IsFixedLength= true, MaxSize=32)] 
    public static SqlBinary GetSalt()
    {
        var rng = System.Security.Cryptography.RNGCryptoServiceProvider.Create();
        byte[] salt = new byte[32];
        rng.GetBytes(salt);
        return new SqlBinary(salt);
    }
}
