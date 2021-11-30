using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UserManagementService.Models.Configuration
{
    public class SecurityQuestionConfiguration : IEntityTypeConfiguration<SecurityQuestion>
    {
        public void Configure(EntityTypeBuilder<SecurityQuestion> builder)
        {
            var questionOne = new SecurityQuestion
            {
                Id = Guid.Parse("f3124fb0-79ce-403b-8cd4-eceafaf2a0ff"),
                Question = "Was ist Ihr Lieblingsessen?"
            };

            var questionTwo = new SecurityQuestion()
            {
                Id = Guid.Parse("5e1e640d-17cc-4d36-8e50-81deaeb6b215"),
                Question = "Wie lautet der Geburtsname Ihrer Mutter?"
            };
            var questionThree = new SecurityQuestion()
            {
                Id = Guid.Parse("f7f78ebd-22d5-4861-893e-7dceee4ee4fe"),
                Question = "Wie lautet Ihre Lieblingsprimzahl?"
            };

            builder.HasData(questionOne, questionTwo, questionThree);
        }
    }
}
