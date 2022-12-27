using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataEntities
{
    public class FileData
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "File Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "File Type is required")]
        public FileTypes Type { get; set; }

        [Required(ErrorMessage = "File Size is required")]
        public int Size { get; set; }

        public DateTime? dateCreated { get; set; }

        public bool? encoded { get; set; }

        public string author  { get; set; }
    }
}
