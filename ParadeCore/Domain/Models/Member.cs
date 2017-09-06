using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParadeCore.Domain.Models
{
    public class Member : IEntity
    {
        private Member() { }

        public Member(
            string serviceNumber,
            string lastName = "",
            string firstName = "",
            RankEquivalence rank = RankEquivalence.PrivateRecruit,
            RankModifier rankModifier = RankModifier.Standard)
        {
            if (string.IsNullOrWhiteSpace(serviceNumber))
            {
                throw new ArgumentNullException(nameof(serviceNumber));
            }

            if (!Regex.IsMatch(serviceNumber, @"^[a-zA-Z]\d{8}"))
            {
                throw new ArgumentException("Service numbers must be in the form of A12345678");
            }

            this.ServiceNumber = serviceNumber.ToUpper();
            this.LastName = lastName;
            this.FirstName = firstName;

        }

        public int Id { get; private set; }

        [RegularExpression(@"^[a-zA-Z]\d{8}", ErrorMessage = "Invalid format", ErrorMessageResourceType = typeof(ArgumentException))]
        [Required]
        public string ServiceNumber { get; private set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Initials { get; set; }

        public virtual ICollection<AttendanceRecord> AttendanceRecords { get; private set; } = new List<AttendanceRecord>();

        // public virtual ICollection<UnitPosting> Postings { get; private set; } = new HashSet<UnitPosting>();



        public override bool Equals(object obj)
        {
            return this.ServiceNumber.Equals(((Member)obj).ServiceNumber, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return -1037692451 + EqualityComparer<string>.Default.GetHashCode(ServiceNumber);
        }
    }
}