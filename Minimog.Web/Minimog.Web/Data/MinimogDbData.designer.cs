﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Minimog.Web.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Minimog")]
	public partial class MinimogDbDataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public MinimogDbDataDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SgMinimogConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MinimogDbDataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MinimogDbDataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MinimogDbDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MinimogDbDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.procGetProductDataAsJsonResult_20230806")]
		public ISingleResult<procGetProductDataAsJsonResult_20230806Result> procGetProductDataAsJsonResult_20230806()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<procGetProductDataAsJsonResult_20230806Result>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.procGetProductByIdAsJson_20230806")]
		public ISingleResult<procGetProductByIdAsJson_20230806Result> procGetProductByIdAsJson_20230806([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ProductId", DbType="UniqueIdentifier")] System.Nullable<System.Guid> productId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), productId);
			return ((ISingleResult<procGetProductByIdAsJson_20230806Result>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.procSaveUser")]
		public ISingleResult<procSaveUserResult> procSaveUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Username", DbType="NVarChar(50)")] string username, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Email", DbType="NVarChar(100)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Password", DbType="NVarChar(50)")] string password)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), username, email, password);
			return ((ISingleResult<procSaveUserResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.procLoginCheck")]
		public ISingleResult<procLoginCheckResult> procLoginCheck([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Email", DbType="NVarChar(60)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(10)")] string password)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), email, password);
			return ((ISingleResult<procLoginCheckResult>)(result.ReturnValue));
		}
	}
	
	public partial class procGetProductDataAsJsonResult_20230806Result
	{
		
		private string _JsonResult;
		
		public procGetProductDataAsJsonResult_20230806Result()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_JsonResult", DbType="NVarChar(MAX)")]
		public string JsonResult
		{
			get
			{
				return this._JsonResult;
			}
			set
			{
				if ((this._JsonResult != value))
				{
					this._JsonResult = value;
				}
			}
		}
	}
	
	public partial class procGetProductByIdAsJson_20230806Result
	{
		
		private string _JsonResult;
		
		public procGetProductByIdAsJson_20230806Result()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_JsonResult", DbType="NVarChar(MAX)")]
		public string JsonResult
		{
			get
			{
				return this._JsonResult;
			}
			set
			{
				if ((this._JsonResult != value))
				{
					this._JsonResult = value;
				}
			}
		}
	}
	
	public partial class procSaveUserResult
	{
		
		private System.Nullable<bool> _IsValid;
		
		private string _Message;
		
		public procSaveUserResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsValid", DbType="Bit")]
		public System.Nullable<bool> IsValid
		{
			get
			{
				return this._IsValid;
			}
			set
			{
				if ((this._IsValid != value))
				{
					this._IsValid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="NVarChar(50)")]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this._Message = value;
				}
			}
		}
	}
	
	public partial class procLoginCheckResult
	{
		
		private System.Nullable<bool> _IsValid;
		
		private string _Message;
		
		public procLoginCheckResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsValid", DbType="Bit")]
		public System.Nullable<bool> IsValid
		{
			get
			{
				return this._IsValid;
			}
			set
			{
				if ((this._IsValid != value))
				{
					this._IsValid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this._Message = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
