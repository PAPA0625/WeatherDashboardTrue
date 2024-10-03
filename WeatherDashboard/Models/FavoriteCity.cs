using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherDashboard.Models;

public partial class FavoriteCity
{
    [Key]
    [Column("FavoriteCityID")]
    public int FavoriteCityId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(100)]
    public string CityName { get; set; } = null!;

    [StringLength(10)]
    public string? CountryCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AddedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("FavoriteCities")]
    public virtual User User { get; set; } = null!;
}
