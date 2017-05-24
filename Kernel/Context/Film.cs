//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Films.Kernel.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Film : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            Name = string.Empty;
            IssueDate = DateTime.Now;
            Country = string.Empty;
            Genre = string.Empty;
            Duration = 0;

            this.Actors = new HashSet<Actor>();
        }
        public Film(string name, string country, int duration) : this()
        {
            Name = name;
            Country = country;
            Duration = duration;
        }

        public string Name { get; set; }
        public DateTime IssueDate { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actor> Actors { get; set; }
        public IEnumerable<long> ActorIds { get; set; }

        public void ClearActors()
        {
            Actors.Clear();
        }

        public void Update(Film film)
        {
            Name = film.Name;
            IssueDate = film.IssueDate;
            Country = film.Country;
            Genre = film.Genre;
            Duration = film.Duration;
        }
    }
}
