using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siren.Json.Core
{
    public class SirenAction
    {
        public SirenAction(string name, string href, IEnumerable<string> classes = null, HttpMethod method = HttpMethod.GET, string title = null, string encodingType = null, IEnumerable<SirenField> fields = null)
        {
            Name = name;
            Href = href;
            Method = method;
            Title = title;
            Fields = (fields ?? Enumerable.Empty<SirenField>()).ToList().AsReadOnly();
            Classes = (classes ?? Enumerable.Empty<string>()).ToList().AsReadOnly();

            Type = encodingType == null && fields != null
                ? "application/x-www-form-urlencoded"
                : encodingType;
        }

        public string Title { get; private set; }
        public string Href { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public HttpMethod Method { get; private set; }
        public ReadOnlyCollection<SirenField> Fields { get; private set; }
        public ReadOnlyCollection<string> Classes { get; private set; }
    }
}
