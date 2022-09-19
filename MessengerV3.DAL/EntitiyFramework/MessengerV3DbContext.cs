using System;
using System.Collections.Generic;
using MessengerV3.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MessengerV3.DAL.EntitiyFramework
{
    public partial class MessengerV3DbContext : DbContext
    {
        public MessengerV3DbContext()
        {
        }

        public MessengerV3DbContext(DbContextOptions<MessengerV3DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B6AHL5A;Database=MessengerV3Db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("Chat");

                entity.Property(e => e.ChatName).HasMaxLength(35);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Creator_Id");

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.ChatsNavigation)
                    .UsingEntity<Dictionary<string, object>>(
                        "ChatUser",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_User__Id"),
                        r => r.HasOne<Chat>().WithMany().HasForeignKey("ChatId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Chat__Id"),
                        j =>
                        {
                            j.HasKey("ChatId", "UserId").HasName("PK_Cnat_User_Id");

                            j.ToTable("ChatUsers");
                        });
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageDate).HasPrecision(3);

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_Id");

                entity.HasOne(d => d.MessageSender)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.MessageSenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Sender_Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.AboutUser).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
