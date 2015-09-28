﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VacCheck
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Id_Game")]
	public partial class Id_GameDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertGame(Game instance);
    partial void UpdateGame(Game instance);
    partial void DeleteGame(Game instance);
    partial void InsertRelation(Relation instance);
    partial void UpdateRelation(Relation instance);
    partial void DeleteRelation(Relation instance);
    partial void InsertId(Id instance);
    partial void UpdateId(Id instance);
    partial void DeleteId(Id instance);
    #endregion
		
		public Id_GameDataContext() : 
				base(global::VacCheck.Properties.Settings.Default.Id_GameConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public Id_GameDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Id_GameDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Id_GameDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Id_GameDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Game> Games
		{
			get
			{
				return this.GetTable<Game>();
			}
		}
		
		public System.Data.Linq.Table<Relation> Relations
		{
			get
			{
				return this.GetTable<Relation>();
			}
		}
		
		public System.Data.Linq.Table<Id> Ids
		{
			get
			{
				return this.GetTable<Id>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Games")]
	public partial class Game : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<System.DateTime> _date;
		
		private string _map;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OndateChanging(System.Nullable<System.DateTime> value);
    partial void OndateChanged();
    partial void OnmapChanging(string value);
    partial void OnmapChanged();
    #endregion
		
		public Game()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this.OndateChanging(value);
					this.SendPropertyChanging();
					this._date = value;
					this.SendPropertyChanged("date");
					this.OndateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_map", DbType="NVarChar(50)")]
		public string map
		{
			get
			{
				return this._map;
			}
			set
			{
				if ((this._map != value))
				{
					this.OnmapChanging(value);
					this.SendPropertyChanging();
					this._map = value;
					this.SendPropertyChanged("map");
					this.OnmapChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Relations")]
	public partial class Relation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _Game_Id;
		
		private System.Nullable<int> _Player_Id;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnGame_IdChanging(System.Nullable<int> value);
    partial void OnGame_IdChanged();
    partial void OnPlayer_IdChanging(System.Nullable<int> value);
    partial void OnPlayer_IdChanged();
    #endregion
		
		public Relation()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Game_Id", DbType="Int")]
		public System.Nullable<int> Game_Id
		{
			get
			{
				return this._Game_Id;
			}
			set
			{
				if ((this._Game_Id != value))
				{
					this.OnGame_IdChanging(value);
					this.SendPropertyChanging();
					this._Game_Id = value;
					this.SendPropertyChanged("Game_Id");
					this.OnGame_IdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Player_Id", DbType="Int")]
		public System.Nullable<int> Player_Id
		{
			get
			{
				return this._Player_Id;
			}
			set
			{
				if ((this._Player_Id != value))
				{
					this.OnPlayer_IdChanging(value);
					this.SendPropertyChanging();
					this._Player_Id = value;
					this.SendPropertyChanged("Player_Id");
					this.OnPlayer_IdChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Ids")]
	public partial class Id : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id1;
		
		private System.Nullable<long> _Steam_ID;
		
		private System.Nullable<bool> _OWban;
		
		private System.Nullable<bool> _VACban;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId1Changing(int value);
    partial void OnId1Changed();
    partial void OnSteam_IDChanging(System.Nullable<long> value);
    partial void OnSteam_IDChanged();
    partial void OnOWbanChanging(System.Nullable<bool> value);
    partial void OnOWbanChanged();
    partial void OnVACbanChanging(System.Nullable<bool> value);
    partial void OnVACbanChanged();
    #endregion
		
		public Id()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Id", Storage="_Id1", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id1
		{
			get
			{
				return this._Id1;
			}
			set
			{
				if ((this._Id1 != value))
				{
					this.OnId1Changing(value);
					this.SendPropertyChanging();
					this._Id1 = value;
					this.SendPropertyChanged("Id1");
					this.OnId1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Steam_ID", DbType="BigInt")]
		public System.Nullable<long> Steam_ID
		{
			get
			{
				return this._Steam_ID;
			}
			set
			{
				if ((this._Steam_ID != value))
				{
					this.OnSteam_IDChanging(value);
					this.SendPropertyChanging();
					this._Steam_ID = value;
					this.SendPropertyChanged("Steam_ID");
					this.OnSteam_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OWban", DbType="Bit")]
		public System.Nullable<bool> OWban
		{
			get
			{
				return this._OWban;
			}
			set
			{
				if ((this._OWban != value))
				{
					this.OnOWbanChanging(value);
					this.SendPropertyChanging();
					this._OWban = value;
					this.SendPropertyChanged("OWban");
					this.OnOWbanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VACban", DbType="Bit")]
		public System.Nullable<bool> VACban
		{
			get
			{
				return this._VACban;
			}
			set
			{
				if ((this._VACban != value))
				{
					this.OnVACbanChanging(value);
					this.SendPropertyChanging();
					this._VACban = value;
					this.SendPropertyChanged("VACban");
					this.OnVACbanChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
