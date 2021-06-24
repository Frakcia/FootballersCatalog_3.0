using System.Collections.Generic;

namespace FootballersCatalog.Domain.Core.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private List<Footballer> footballers;
        public virtual List<Footballer> Footballers
        {
            get { return footballers ?? (footballers = new List<Footballer>()); }
            set { footballers = value; }
        }
    }
}
