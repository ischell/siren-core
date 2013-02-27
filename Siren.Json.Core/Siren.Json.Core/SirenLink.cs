using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siren.Json.Core
{
    public class SirenLink
    {
        public SirenLink(string href, IEnumerable<string> relationships)
        {
            Href = href;
            Relationships = relationships.ToList().AsReadOnly();
        }

        public string Href { get; private set; }
        public ReadOnlyCollection<string> Relationships { get; private set; }
    }
}
