﻿// <auto-generated />
using System;
using CodeAFriend.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeAFriend.Repository.Migrations
{
    [DbContext(typeof(CodeAFriendContext))]
    partial class CodeAFriendContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity("CodeAFriend.DataModel.Problem", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("UserName");

                    b.HasKey("Name");

                    b.HasIndex("UserName");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("CodeAFriend.DataModel.User", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Name");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CodeAFriend.DataModel.Problem", b =>
                {
                    b.HasOne("CodeAFriend.DataModel.User", "User")
                        .WithMany("Problems")
                        .HasForeignKey("UserName")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.OwnsOne("CodeAFriend.DataModel.ProblemSolution", "Solutions", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("Body")
                                .IsRequired();

                            b1.Property<int>("Language");

                            b1.Property<string>("Name")
                                .IsRequired();

                            b1.Property<string>("ProblemName")
                                .IsRequired();

                            b1.HasIndex("Name");

                            b1.ToTable("ProblemSolutions");

                            b1.HasOne("CodeAFriend.DataModel.User", "Submitter")
                                .WithMany()
                                .HasForeignKey("Name")
                                .OnDelete(DeleteBehavior.SetNull);

                            b1.HasOne("CodeAFriend.DataModel.Problem")
                                .WithMany("Solutions")
                                .HasForeignKey("ProblemName")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("CodeAFriend.DataModel.Vote", "Votes", b2 =>
                                {
                                    b2.Property<Guid>("ProblemSolutionId");

                                    b2.Property<Guid>("UserName");

                                    b2.Property<string>("Comment");

                                    b2.Property<string>("SubmitterName");

                                    b2.Property<short>("Value");

                                    b2.HasIndex("SubmitterName");

                                    b2.HasIndex("UserName");

                                    b2.ToTable("ProblemSolutionVotes");

                                    b2.HasOne("CodeAFriend.DataModel.User", "Submitter")
                                        .WithMany()
                                        .HasForeignKey("SubmitterName");

                                    b2.HasOne("CodeAFriend.DataModel.ProblemSolution")
                                        .WithMany("Votes")
                                        .HasForeignKey("UserName")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });

                    b.OwnsOne("CodeAFriend.DataModel.Tag", "Tags", b1 =>
                        {
                            b1.Property<string>("ProblemName");

                            b1.Property<string>("Text");

                            b1.ToTable("ProblemTags");

                            b1.HasOne("CodeAFriend.DataModel.Problem")
                                .WithMany("Tags")
                                .HasForeignKey("ProblemName")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("CodeAFriend.DataModel.TestCase", "TestCases", b1 =>
                        {
                            b1.Property<string>("ProblemName");

                            b1.Property<uint>("Number");

                            b1.Property<string>("ExpectedOutput");

                            b1.Property<string>("Input");

                            b1.ToTable("ProblemTestCases");

                            b1.HasOne("CodeAFriend.DataModel.Problem")
                                .WithMany("TestCases")
                                .HasForeignKey("ProblemName")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("CodeAFriend.DataModel.User", b =>
                {
                    b.OwnsOne("CodeAFriend.DataModel.UserScript", "Scripts", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("Body")
                                .IsRequired();

                            b1.Property<int>("Language");

                            b1.Property<string>("Name")
                                .IsRequired();

                            b1.Property<string>("UserName")
                                .IsRequired();

                            b1.ToTable("UserScripts");

                            b1.HasOne("CodeAFriend.DataModel.User")
                                .WithMany("Scripts")
                                .HasForeignKey("UserName")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
