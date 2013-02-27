using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Siren.Json.Core
{
    public class SirenEntity
    {
        public SirenEntity(Dictionary<string, object> properties = null, 
                           IEnumerable<string> classes = null,
                           IEnumerable<SirenLink> links = null,
                           IEnumerable<SirenAction> actions = null,
                           IEnumerable<SirenEntity> embeddedRepresentations = null,
                           IEnumerable<SirenEntityLink> embeddedLinks = null)
            :this(classes, links, actions, embeddedRepresentations, embeddedLinks)
        {
            Properties = properties ?? new Dictionary<string, object>();
        }

        public SirenEntity(object properties = null,
                           IEnumerable<string> classes = null,
                           IEnumerable<SirenLink> links = null,
                           IEnumerable<SirenAction> actions = null,
                           IEnumerable<SirenEntity> embeddedRepresentations = null,
                           IEnumerable<SirenEntityLink> embeddedLinks = null)
            : this(classes, links, actions, embeddedRepresentations, embeddedLinks)
        {
            Properties = ParsePropertiesFromObject(properties);
        }

        private SirenEntity(IEnumerable<string> classes = null,
                            IEnumerable<SirenLink> links = null,
                            IEnumerable<SirenAction> actions = null,
                            IEnumerable<SirenEntity> embeddedRepresentations = null,
                            IEnumerable<SirenEntityLink> embeddedLinks = null)
        {
            Classes = (classes ?? Enumerable.Empty<string>()).ToList().AsReadOnly();
            Links = (links ?? Enumerable.Empty<SirenLink>()).ToList().AsReadOnly();
            Actions = (actions ?? Enumerable.Empty<SirenAction>()).ToList().AsReadOnly();
            EmbeddedRepresentations = (embeddedRepresentations ?? Enumerable.Empty<SirenEntity>()).ToList().AsReadOnly();
            EmbeddedLinks = (embeddedLinks ?? Enumerable.Empty<SirenEntityLink>()).ToList().AsReadOnly();
        }

        public ReadOnlyCollection<SirenEntityLink> EmbeddedLinks { get; private set; }
        public ReadOnlyCollection<SirenEntity> EmbeddedRepresentations { get; private set; }
        public Dictionary<string, object> Properties { get; private set; }
        public ReadOnlyCollection<string> Classes { get; private set; }
        public ReadOnlyCollection<SirenLink> Links { get; private set; }
        public ReadOnlyCollection<SirenAction> Actions { get; private set; }

        private Dictionary<string, object> ParsePropertiesFromObject(object propertyObject)
        {
            var propertyValues = new Dictionary<string, object>();

            if (propertyObject == null)
                return propertyValues;

            var propertyInfos = propertyObject.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                propertyValues.Add(propertyInfo.Name, propertyInfo.GetValue(propertyObject));
            }

            return propertyValues;
        }
    }
}
