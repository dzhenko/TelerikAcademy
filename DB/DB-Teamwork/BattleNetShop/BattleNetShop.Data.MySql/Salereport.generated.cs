#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;

namespace BattleNetShop.Data.MySql	
{
	public partial class Salereport
	{
		private int _report_id;
		public virtual int Report_id
		{
			get
			{
				return this._report_id;
			}
			set
			{
				this._report_id = value;
			}
		}
		
		private int _product_id;
		public virtual int Product_id
		{
			get
			{
				return this._product_id;
			}
			set
			{
				this._product_id = value;
			}
		}
		
		private string _productName;
		public virtual string ProductName
		{
			get
			{
				return this._productName;
			}
			set
			{
				this._productName = value;
			}
		}
		
		private string _vendorName;
		public virtual string VendorName
		{
			get
			{
				return this._vendorName;
			}
			set
			{
				this._vendorName = value;
			}
		}
		
		private int _totalQuantitySold;
		public virtual int TotalQuantitySold
		{
			get
			{
				return this._totalQuantitySold;
			}
			set
			{
				this._totalQuantitySold = value;
			}
		}
		
		private int _totalIncomes;
		public virtual int TotalIncomes
		{
			get
			{
				return this._totalIncomes;
			}
			set
			{
				this._totalIncomes = value;
			}
		}
		
	}
}
#pragma warning restore 1591
