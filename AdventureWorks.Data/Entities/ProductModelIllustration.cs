﻿using System;
using System.Collections.Generic;

namespace AdventureWorks.Data.Entities
{
    public partial class ProductModelIllustration : IEntity
    {
        public int ProductModelId { get; set; }
        public int IllustrationId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Illustration Illustration { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
