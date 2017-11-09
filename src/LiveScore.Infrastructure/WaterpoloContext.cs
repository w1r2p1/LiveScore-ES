﻿using LiveScore.QueryStack;
using Microsoft.EntityFrameworkCore;

namespace LiveScore.Infrastructure
{
	public class WaterpoloContext : DbContext
	{
		public WaterpoloContext(DbContextOptions<WaterpoloContext> options) : base(options)
		{
		}

		public DbSet<LiveMatch> Matches { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<LiveMatch>().ToTable("LiveMatches");
			modelBuilder.Entity<LiveMatch>().OwnsOne(match => match.CurrentScore, score =>
			{
				score.Property(s => s.TotalGoals1);
				score.Property(s => s.TotalGoals2);
			});
		}
	}
}