using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherDashboard.Models;

public partial class Country
{
    [Key]
    [StringLength(2)]
    public string CountryCode { get; set; } = null!;

    [StringLength(100)]
    public string CountryNameEn { get; set; } = null!;

    [StringLength(100)]
    public string CountryNameZhTw { get; set; } = null!;

    [InverseProperty("CountryCodeNavigation")]
    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
