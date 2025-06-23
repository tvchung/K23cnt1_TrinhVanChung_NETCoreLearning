using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TvcLesson10EF.Models;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Tên thể loại không được để trống")]
    [StringLength(100, ErrorMessage = "Tên thể loại không được vượt quá 100 ký tự")]
    [Display(Name = "Tên thể loại")]
    public string CategoryName { get; set; } = String.Empty;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
