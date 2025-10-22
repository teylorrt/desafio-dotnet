using ByCodersChallengeDotNet.Core.Enums;

namespace ByCodersChallengeDotNet.Application.Models
{
    public record Field(FieldType Type, int Start, int End, int Size)
    {
    }
}
