using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherDashboard.Models;

[Index("Email", Name = "IX_Users_Email", IsUnique = true)]
[Index("Username", Name = "IX_Users_Username", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string Username { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(256)]
    public string PasswordHash { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<FavoriteCity> FavoriteCities { get; set; } = new List<FavoriteCity>();

    [InverseProperty("User")]
    public virtual ICollection<UserActivity> UserActivities { get; set; } = new List<UserActivity>();
}
