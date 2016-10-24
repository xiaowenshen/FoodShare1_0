using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareMODEL
{
	/// <summary>
	/// MyWorks:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MyWorks
	{
		public MyWorks()
		{}
		#region Model
		private int _wid;
		private string _wtitle;
		private string _introduce;
		private int _uid;
		private bool _isdel;
        private string _path;

        public string path
        {
            get { return _path; }
            set { _path = value; }
        }
		private DateTime _addtime;
		/// <summary>
		/// 
		/// </summary>
		public int WId
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WTitle
		{
			set{ _wtitle=value;}
			get{return _wtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string introduce
		{
			set{ _introduce=value;}
			get{return _introduce;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UId
		{
			set{ _uid=value;}
			get{return _uid;}
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
		#endregion Model

	}
}

