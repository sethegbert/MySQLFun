using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Models
{
    // we want to set up an instance of a bowler here. This info should match the info in the bowler table in mysql
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }
        [Required]
        public string BowlerLastName { get; set; }
        [Required]
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }
        [Required]
        public string BowlerAddress { get; set; }
        [Required]
        public string BowlerCity { get; set; }
        [Required]
        public string BowlerState { get; set; }
        [Required]
        public string BowlerZip { get; set; }
        public string BowlerPhoneNumber { get; set; }
        // here is a foreign key constraint for the team class
        [Required]
        public int TeamID { get; set; }
        public Team team { get; set; }
    }
}
