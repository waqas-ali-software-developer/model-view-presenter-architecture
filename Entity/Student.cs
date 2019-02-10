using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Student
    {
        [Required, RangeAttribute(0, 100)]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is Compulsary"), StringLength(35)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Compulsary"), StringLength(35)]
        public string LastName { get; set; }
       [Range(1, 100, ErrorMessage = "Country is compulsary")]
        public int CountryId { get; set; }
       [Range(1, 100, ErrorMessage = "Gender is compulsary")]
        public int GenderId { get; set; }

    }
}
