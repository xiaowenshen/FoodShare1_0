﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareMODEL
{
	/// <summary>
	/// CookBook:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CookBook
	{
		public CookBook()
		{}
		#region Model
		private int _cid;
		private string _ctitle;
		private string _cintroduce;
		private string _ccontent;
		private int? _stepcount;
		private bool _isdel;
		private DateTime _addtime;
		private int _uid;
        private string _path;

        public string path
        {
            get { return _path; }
            set { _path = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int CId
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CTitle
		{
			set{ _ctitle=value;}
			get{return _ctitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CIntroduce
		{
			set{ _cintroduce=value;}
			get{return _cintroduce;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CContent
		{
			set{ _ccontent=value;}
			get{return _ccontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? stepcount
		{
			set{ _stepcount=value;}
			get{return _stepcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isdel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		#endregion Model

	}
}

