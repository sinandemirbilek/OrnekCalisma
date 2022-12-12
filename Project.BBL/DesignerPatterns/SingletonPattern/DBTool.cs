﻿using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BBL.DesignerPatterns.SingletonPattern
{
    public class DBTool
    {
         DBTool() { }

        static MyContext _dbInstance;

        public static MyContext DBInstance 
        {
            get
            {
                if (_dbInstance is null) _dbInstance = new MyContext();
                return _dbInstance;
            }
            
        } 



    }
}
