﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Domain.Common
{
   public class BaseEntity : AuditableModel
    {
        public int Id { get; set; }
    }
}
