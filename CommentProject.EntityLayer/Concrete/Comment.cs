﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string CommentDetails { get; set; }

        public DateTime CommentDate { get; set; }

        public bool Status { get; set; }

        public int ContentID { get; set; }

        public Content Content { get; set; }

        public int AppUserID { get; set; }

        public AppUser AppUser { get; set; }

    }
}
