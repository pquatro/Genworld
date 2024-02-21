using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCenarioMVC.Domain.Entities
{
    public abstract class SecaoWeb : Entity
    {
        public string Css { get; protected set; }
    }
}
