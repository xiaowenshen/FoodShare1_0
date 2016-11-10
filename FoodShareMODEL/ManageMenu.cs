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

	public partial class ManageMenu
	{
		public ManageMenu()
		{}
		#region Model
		private int _menuid;
		private string _menuname;
		private int _uid;
		private string _menuintroduce;
		private DateTime _addtime= DateTime.Now;
		private bool _isdel= false;
		private string _path="images/2.jpg";
		/// <summary>
		/// 
		/// </summary>
		public int MenuId
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
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
		public string MenuIntroduce
		{
			set{ _menuintroduce=value;}
			get{return _menuintroduce;}
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
		public string path
		{
			set{ _path=value;}
			get{return _path;}
		}
		#endregion Model

	}
}

