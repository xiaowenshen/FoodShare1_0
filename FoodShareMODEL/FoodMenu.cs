using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareMODEL
{
	/// <summary>
	/// FoodMenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FoodMenu
	{
		public FoodMenu()
		{}
		#region Model
		private int _fid;
		private string _fname;
		private int _cid;
		private string _cname;
        private int _classID;
        private int _uId;
        private string _fIntroduce;
		/// <summary>
		/// 
		/// </summary>
		public int FId
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FName
		{
			set{ _fname=value;}
			get{return _fname;}
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
		public string CName
		{
			set{ _cname=value;}
			get{return _cname;}
		}

        public int ClassID
        {
            get
            {
                return _classID;
            }

            set
            {
                _classID = value;
            }
        }

        public int UId
        {
            get
            {
                return _uId;
            }

            set
            {
                _uId = value;
            }
        }

        public string FIntroduce
        {
            get
            {
                return _fIntroduce;
            }

            set
            {
                _fIntroduce = value;
            }
        }
        #endregion Model

    }
}

