using PaymentProcessor.Format.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentProcessor.Requests.Messages
{
    // TODO: move this to IAccessibleMessage if IMessage ends up not needing any properties or methods
    public interface IAccessible
    {
        int FieldCount { get; }
        IEnumerable<FieldDefinition> FieldDefinitions { get; }
    }
}
