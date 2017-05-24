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
    
    public partial class Actor : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actor()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            MiddleName = string.Empty;
            Birth = DateTime.Now;

            Films = new HashSet<Film>();
        }
        public Actor(string firstName, string lastName, DateTime birth): this()
        {
            FirstName = firstName;
            LastName = lastName;
            Birth = birth;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birth { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Film> Films { get; set; }

        public void ClearFilms()
        {
            Films = new HashSet<Film>();
        }

        public void Update(Actor actor)
        {
            FirstName = actor.FirstName;
            LastName = actor.LastName;
            MiddleName = actor.MiddleName;
            Birth = actor.Birth;
        }
        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}";
        }
    }
}
