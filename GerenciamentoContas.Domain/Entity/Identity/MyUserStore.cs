﻿using Dapper;
using GerenciamentoContas.Domain.Entity.Identy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoContas.Domain.Entity.Identity
{
    public class MyUserStore : IUserStore<MyUser>
    {
        public static DbConnection GetOpenConnection()
        {
            var connection = new SqlConnection("User ID=sa;Initial Catalog=GerenciamentoContas_DB;Data Source=DESKTOP-IGQJCON/SQLEXPRESS");
            connection.Open();
            return connection;  
        }
        public async Task<IdentityResult> CreateAsync(MyUser user, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                await connection.ExecuteAsync(
                    "insert into Users([Id]," +
                    "[UserName]," +
                    "[NormalizedUserName]"+
                    "[PasswordHash]" +
                    "Values(@id,@username,@normalizedUserName,@passwordHash)",
                    new
                {
                    id = user.Id,
                    userName = user.UserName,
                    NormalizedUserName = user.NormalizedUserName,
                    password = user.PasswordHash
                });                
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(MyUser user, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                await connection.ExecuteAsync("delete * from Users where Id = @id", new
                {
                    id = user.Id,                    
                });
            }
            return IdentityResult.Success;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<MyUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<MyUser>("select * from Users where Id = @id", new { id = userId });
            }
        }

        public async Task<MyUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<MyUser>("select * from Users where normalizedUserName = @name", new { nome = normalizedUserName });
            }
        }

        public Task<string> GetNormalizedUserNameAsync(MyUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(MyUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(MyUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(MyUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(MyUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(MyUser user, CancellationToken cancellationToken)
        {
            using (var connection = GetOpenConnection())
            {
                await connection.ExecuteAsync(
                    "insert into Users([Id]," +
                    "[UserName]," +
                    "[NormalizedUserName]" +
                    "[PasswordHash]" +
                    "Values(@id,@username,@normalizedUserName,@passwordHash)", new
                {
                    id = user.Id,
                    userName = user.UserName,
                    NormalizedUserName = user.NormalizedUserName,
                    password = user.PasswordHash
                });
            }
            return IdentityResult.Success;
        }
    }
}
