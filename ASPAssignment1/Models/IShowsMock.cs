using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPAssignment1.Models
{
    public interface IShowsMock
    {
        IQueryable<Show> shows { get; }
        IQueryable<Movy> movies { get; }
        Show Saved(Show Show);
        void Delete(Show Show);
    }
}
