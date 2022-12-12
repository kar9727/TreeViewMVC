using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TreeViewMVC.Models
{

    public class Category
    {
        
        [Key]
        public int nodeId { get; set; }

       
        public string nodeName { get; set; }

         
        public bool IsActive { get; set; }

        public DateTime startdate { get; set; }

       
        public int? parentNodeId { get; set; }
        [ForeignKey("parentNodeId")]
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Childs { get; set; }
    }
}