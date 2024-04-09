﻿using System.ComponentModel.DataAnnotations;

namespace MedCare.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int id { get; set; }
    }
}
