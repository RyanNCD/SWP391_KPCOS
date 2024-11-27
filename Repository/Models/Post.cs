﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Post
{
    public int PostId { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public decimal? Price { get; set; }

    public string ImageUrl { get; set; }

    public int? FengShuiElementId { get; set; }

    public int? PackageId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ElementType FengShuiElement { get; set; }

    public virtual PostPackage Package { get; set; }

    public virtual User User { get; set; }
}