#nullable enable

using System.ComponentModel.DataAnnotations;

public struct UniqueEntity
{
    public string DistrictCode { get; set; }
    public string SegmentBusinessName { get; set; }
    public string ParameterDescName { get; set; }
    public string CustomerCode { get; set; }

    public UniqueEntity CloneLower()
    {
        return new UniqueEntity
        {
            DistrictCode = DistrictCode.ToLower(),
            SegmentBusinessName = SegmentBusinessName.ToLower(),
            CustomerCode = CustomerCode.ToLower(),
            ParameterDescName = ParameterDescName.ToLower(),
        };
    }
}

public class Entity
{
    [Key]
    public Guid Id { get; set; }
    public required string DistrictCode { get; set; }
    public required string SegmentBusinessName { get; set; }
    public required string ParameterDescName { get; set; }
    public required string CustomerCode { get; set; }
    public required string IsForContract { get; set; }
    public required string IsForAccrue { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; }

    public static UniqueEntity ToUnique(Entity entity)
    {
        return new UniqueEntity
        {
            DistrictCode = entity.DistrictCode,
            SegmentBusinessName = entity.SegmentBusinessName,
            ParameterDescName = entity.ParameterDescName,
            CustomerCode = entity.CustomerCode
        };
    }

    public override bool Equals(object? obj)
    {
        if (obj is Entity dto)
        {
            return DistrictCode == dto.DistrictCode
                && SegmentBusinessName == dto.SegmentBusinessName
                && CustomerCode == dto.CustomerCode
                && ParameterDescName == dto.ParameterDescName
                && IsForAccrue == dto.IsForAccrue
                && IsForContract == dto.IsForContract;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            DistrictCode,
            SegmentBusinessName,
            CustomerCode,
            ParameterDescName,
            IsForContract,
            IsForAccrue);
    }

}
