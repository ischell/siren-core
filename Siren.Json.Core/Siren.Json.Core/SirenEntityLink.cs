using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siren.Json.Core
{
    public class SirenEntityLink : SirenLink
    {
        public SirenEntityLink(string href, IEnumerable<string> relationships, IEnumerable<string> classes = null)
            : base(href, relationships)
        {
            Classes = (classes ?? Enumerable.Empty<string>()).ToList().AsReadOnly();
        }

        public ReadOnlyCollection<string> Classes { get; private set; }
    }
}
