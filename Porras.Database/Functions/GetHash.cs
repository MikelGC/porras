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
        Name="GetHash", IsDeterministic=false, IsPrecise= true,
        DataAccess= DataAccessKind.None, SystemDataAccess= SystemDataAccessKind.None)]
    [return: SqlFacet(IsFixedLength = true, MaxSize = 64)]
    public static  SqlBinary GetHash(SqlString password, SqlBinary salt)
    {
        if (password.IsNull || salt.IsNull) return SqlBinary.Null;
        var rfc = new System.Security.Cryptography.Rfc2898DeriveBytes(password.Value, salt.Value);
        return new SqlBinary(rfc.GetBytes(64));
    }
}
