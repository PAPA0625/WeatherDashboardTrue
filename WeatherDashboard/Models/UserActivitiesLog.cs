using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherDashboard.Models;

[Table("UserActivities_Log")]
public partial class UserActivitiesLog
{
    [Key]
    [Column("ActivityID")]
    public int ActivityId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string ActivityType { get; set; } = null!;

    [StringLength(200)]
    public string? ActivityDetail { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Timestamp { get; set; }
}
