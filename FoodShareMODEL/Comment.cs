using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace FoodShare.Model{
	 	//comment
		public class Comment
	{
   		     
      	/// <summary>
		/// mid
        /// </summary>		
		private int _mid;
        public int mid
        {
            get{ return _mid; }
            set{ _mid = value; }
        }        
		/// <summary>
		/// UId1
        /// </summary>		
		private int _uid1;
        public int UId1
        {
            get{ return _uid1; }
            set{ _uid1 = value; }
        }        
		/// <summary>
		/// U1path
        /// </summary>		
		private string _u1path;
        public string U1path
        {
            get{ return _u1path; }
            set{ _u1path = value; }
        }        
		/// <summary>
		/// U1name
        /// </summary>		
		private string _u1name;
        public string U1name
        {
            get{ return _u1name; }
            set{ _u1name = value; }
        }        
		/// <summary>
		/// UId2
        /// </summary>		
		private int _uid2;
        public int UId2
        {
            get{ return _uid2; }
            set{ _uid2 = value; }
        }        
		/// <summary>
		/// U2name
        /// </summary>		
		private string _u2name;
        public string U2name
        {
            get{ return _u2name; }
            set{ _u2name = value; }
        }        
		/// <summary>
		/// U2path
        /// </summary>		
		private string _u2path;
        public string U2path
        {
            get{ return _u2path; }
            set{ _u2path = value; }
        }        
		/// <summary>
		/// addtime
        /// </summary>		
		private DateTime _addtime;
        public DateTime addtime
        {
            get{ return _addtime; }
            set{ _addtime = value; }
        }        
		/// <summary>
		/// isdel
        /// </summary>		
		private bool _isdel;
        public bool isdel
        {
            get{ return _isdel; }
            set{ _isdel = value; }
        }        
		/// <summary>
		/// comment
        /// </summary>		
		private string _comment;
        public string comment
        {
            get{ return _comment; }
            set{ _comment = value; }
        }        
		   
	}
}

