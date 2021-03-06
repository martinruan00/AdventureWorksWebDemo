﻿using System;
using System.Collections.Generic;

namespace AdventureWorks.Data.Entities
{
    public partial class AwbuildVersion : IEntity
    {
        public byte SystemInformationId { get; set; }
        public string DatabaseVersion { get; set; }
        public DateTime VersionDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
