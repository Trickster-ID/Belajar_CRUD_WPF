﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belajarCRUDWPF.Model
{
    [Table("TB_M_Supplier")]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Supplier()
        {

        }
        public Supplier(string name, string address, string email, string password, Role role)
        {
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Password = password;
            this.Role = role;
        }
    }
}
