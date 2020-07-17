using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogPost_userpost_.Model
{
    public class Category 
    { 
        [Key]
        public int CategoryId { get; set; }
    
       
        public Types GetTypes { get; set; }
    }
}