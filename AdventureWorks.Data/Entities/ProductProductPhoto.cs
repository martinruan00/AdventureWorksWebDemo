﻿using System;
using System.Collections.Generic;

namespace AdventureWorks.Data.Entities
{
    public partial class ProductProductPhoto : IEntity
    {
        public int ProductId { get; set; }
        public int ProductPhotoId { get; set; }
        public bool Primary { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductPhoto ProductPhoto { get; set; }
    }
}
