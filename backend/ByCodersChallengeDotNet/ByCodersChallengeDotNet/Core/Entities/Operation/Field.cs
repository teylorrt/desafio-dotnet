using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Core.Entities.Operation
{
    public record Field(FieldType Type, int Start, int End, int Size)
    {
    }
}
