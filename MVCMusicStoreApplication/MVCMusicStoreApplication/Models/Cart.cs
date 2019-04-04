using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStoreApplication.Models
{
    public class Cart
    {
        [Key]
        public int RecordID { get; set; }

        public string CartID { get; set; }

        public int AlbumID { get; set; }

        public virtual Album  AlbumSelected { get; set; }

        public int Count { get; set; }

        public DateTime DateCreated { get; set; }


    }
}