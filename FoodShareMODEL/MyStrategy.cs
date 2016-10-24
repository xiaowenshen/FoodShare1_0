using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareMODEL
{
	/// <summary>
	/// MyStrategy:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MyStrategy
	{
		public MyStrategy()
		{}
		#region Model
		private int _sid;
		private DateTime _addtime= DateTime.Now;
		private bool _isdel= false;
		private string _stitle;
		private string _scontent;
		private int _uid;
		private string _path;
        private string uname;

        public string Uname
        {
            get
            {
                return uname;
            }

            set
            {
                uname = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SId
		{
			set{ _sid=value;}
			get{return _sid;}
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
		public bool isdel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string STitle
		{
			set{ _stitle=value;}
			get{return _stitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SContent
		{
			set{ _scontent=value;}
			get{return _scontent;}
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
		public string Path
		{
			set{ _path=value;}
			get{return _path;}
		}
		#endregion Model

	}
}

