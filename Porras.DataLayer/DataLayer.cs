
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.SqlServer.Types;
using System.Runtime.Serialization;
using inercya.EntityLite;	
using inercya.EntityLite.Extensions;		

namespace Porras.Entities
{
	[Serializable]
	[DataContract]
	[SqlEntity(BaseTableName="AppUsers")]
	public partial class AppUser
	{
		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, IsKey=true, IsAutoincrement=true, IsReadOnly = true, ColumnName ="UserId", BaseColumnName ="UserId", BaseTableName = "AppUsers" )]
		public Int32 UserId { get; set; }

		[DataMember]
		[SqlField(DbType.String, 256, ColumnName ="UserEmail", BaseColumnName ="UserEmail", BaseTableName = "AppUsers" )]
		public String UserEmail { get; set; }

		[DataMember]
		[SqlField(DbType.String, 256, ColumnName ="UserName", BaseColumnName ="UserName", BaseTableName = "AppUsers" )]
		public String UserName { get; set; }

		[DataMember]
		[SqlField(DbType.Binary, 64, ColumnName ="PasswordHash", BaseColumnName ="PasswordHash", BaseTableName = "AppUsers" )]
		public Byte[] PasswordHash { get; set; }

		[DataMember]
		[SqlField(DbType.Binary, 32, ColumnName ="PasswordSalt", BaseColumnName ="PasswordSalt", BaseTableName = "AppUsers" )]
		public Byte[] PasswordSalt { get; set; }

		[DataMember]
		[SqlField(DbType.DateTimeOffset, 10, Scale=7, ColumnName ="CreatedDate", BaseColumnName ="CreatedDate", BaseTableName = "AppUsers" )]
		public DateTimeOffset CreatedDate { get; set; }

		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, ColumnName ="CreatedBy", BaseColumnName ="CreatedBy", BaseTableName = "AppUsers" )]
		public Int32 CreatedBy { get; set; }

		[DataMember]
		[SqlField(DbType.DateTimeOffset, 10, Scale=7, ColumnName ="ModifiedDate", BaseColumnName ="ModifiedDate", BaseTableName = "AppUsers" )]
		public DateTimeOffset ModifiedDate { get; set; }

		[DataMember]
		[SqlField(DbType.Int32, 4, Precision = 10, ColumnName ="ModifiedBy", BaseColumnName ="ModifiedBy", BaseTableName = "AppUsers" )]
		public Int32 ModifiedBy { get; set; }


	}

	public partial class AppUserRepository : Repository<AppUser> 
	{
		public AppUserRepository(DataService DataService) : base(DataService)
		{
		}

		public new PorrasDataService  DataService  
		{
			get { return (PorrasDataService) base.DataService; }
			set { base.DataService = value; }
		}

		public AppUser Get(string projectionName, System.Int32 userId)
		{
			return ((IRepository<AppUser>)this).Get(projectionName, userId, FetchMode.UseIdentityMap);
		}

		public AppUser Get(string projectionName, System.Int32 userId, FetchMode fetchMode = FetchMode.UseIdentityMap)
		{
			return ((IRepository<AppUser>)this).Get(projectionName, userId, fetchMode);
		}

		public AppUser Get(Projection projection, System.Int32 userId)
		{
			return ((IRepository<AppUser>)this).Get(projection, userId, FetchMode.UseIdentityMap);
		}

		public AppUser Get(Projection projection, System.Int32 userId, FetchMode fetchMode = FetchMode.UseIdentityMap)
		{
			return ((IRepository<AppUser>)this).Get(projection, userId, fetchMode);
		}

		public AppUser Get(string projectionName, System.Int32 userId, params string[] fields)
		{
			return ((IRepository<AppUser>)this).Get(projectionName, userId, fields);
		}

		public AppUser Get(Projection projection, System.Int32 userId, params string[] fields)
		{
			return ((IRepository<AppUser>)this).Get(projection, userId, fields);
		}

		public void Delete(System.Int32 userId)
		{
			var entity = new AppUser { UserId = userId };
			this.Delete(entity);
		}
	}

	public static partial class AppUserFields
	{
		public const string UserId = "UserId";
		public const string UserEmail = "UserEmail";
		public const string UserName = "UserName";
		public const string PasswordHash = "PasswordHash";
		public const string PasswordSalt = "PasswordSalt";
		public const string CreatedDate = "CreatedDate";
		public const string CreatedBy = "CreatedBy";
		public const string ModifiedDate = "ModifiedDate";
		public const string ModifiedBy = "ModifiedBy";
	}

}

namespace Porras.Entities
{
	public partial class PorrasDataService : DataService
	{
		partial void OnCreated();

		private void Init()
		{
			EntityNameToEntityViewTransform = TextTransform.None;
			EntityLiteProvider.DefaultSchema = "dbo";
			OnCreated();
		}

        public PorrasDataService() : base("Porras")
        {
			Init();
        }

        public PorrasDataService(string connectionStringName) : base(connectionStringName)
        {
			Init();
        }

        public PorrasDataService(string connectionString, string providerName) : base(connectionString, providerName)
        {
			Init();
        }

		private Porras.Entities.AppUserRepository _AppUserRepository;
		public Porras.Entities.AppUserRepository AppUserRepository
		{
			get 
			{
				if ( _AppUserRepository == null)
				{
					_AppUserRepository = new Porras.Entities.AppUserRepository(this);
				}
				return _AppUserRepository;
			}
		}
	}
}
