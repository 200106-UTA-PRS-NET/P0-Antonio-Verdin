using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    class JsonUsers
    {

        public string Name { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public DateTime LastOrder { get; set; }

    }
}
