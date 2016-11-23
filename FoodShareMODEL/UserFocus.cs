using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareMODEL
{
	/// <summary>
	/// UserFocus:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserFocus
	{
		public UserFocus()
		{}
		#region Model
		private int _focusid;
		private int _uid1;
		private string _u1name;
		private int _uid2;
		private string _u2name;
		private string _u2path;
		private string _u2introduce;
		private bool _isdel= false;
		private DateTime _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int FocusId
		{
			set{ _focusid=value;}
			get{return _focusid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UId1
		{
			set{ _uid1=value;}
			get{return _uid1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string U1name
		{
			set{ _u1name=value;}
			get{return _u1name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UId2
		{
			set{ _uid2=value;}
			get{return _uid2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string U2name
		{
			set{ _u2name=value;}
			get{return _u2name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string U2path
		{
			set{ _u2path=value;}
			get{return _u2path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string U2Introduce
		{
			set{ _u2introduce=value;}
			get{return _u2introduce;}
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

