﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_SQL_SERVER.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = ""; // имя пользователя
        public int Age { get; set; } // возраст пользователя
    }
}
