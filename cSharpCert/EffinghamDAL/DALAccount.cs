using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffinghamDAL
{
    public class DALAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountNumber { get; set; }

        [StringLength(100)]
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [StringLength(1)]
        [Required]
        public string AccountType { get; set; }
    }
}
