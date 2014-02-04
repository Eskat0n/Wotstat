namespace Domain.Model.Criteria
{
    using System;
    using ByndyuSoft.Infrastructure.Domain;
    using JetBrains.Annotations;

    public class AccountNameCriterion : ICriterion
    {
        public AccountNameCriterion([NotNull] string name)
        {
            if (name == null)
                throw new ArgumentException("name");

            Name = name;
        }

        public string Name { get; set; }
    }
}