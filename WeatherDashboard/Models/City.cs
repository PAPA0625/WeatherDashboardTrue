using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherDashboard.Models;

public partial class City
{
    [Key]
    public int CityId { get; set; }

    [StringLength(100)]
    public string CityNameEn { get; set; } = null!;

    [StringLength(100)]
    public string CityNameZhTw { get; set; } = null!;

    [StringLength(2)]
    public string CountryCode { get; set; } = null!;

    [ForeignKey("CountryCode")]
    [InverseProperty("Cities")]
    public virtual Country CountryCodeNavigation { get; set; } = null!;
}
