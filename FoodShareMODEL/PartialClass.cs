using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareMODEL
{
  
        public partial class MyStrategy
        {
            private int test;


            public int Test
            {
                get
                {
                    return test;
                }

                set
                {
                    test = value;
                }
            }
        }

    public partial class FoodMenu
    {
        private string _cTitle;
        private string _cIntroduce;
        private string _path;

        public string CTitle
        {
            get
            {
                return _cTitle;
            }

            set
            {
                _cTitle = value;
            }
        }

        public string CIntroduce
        {
            get
            {
                return _cIntroduce;
            }

            set
            {
                _cIntroduce = value;
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }

            set
            {
                _path = value;
            }
        }
    }

}
