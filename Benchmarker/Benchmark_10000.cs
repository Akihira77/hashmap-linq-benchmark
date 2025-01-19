using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using LinqKit;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Benchmarker_10000_Element
{
    private AppDbContext _context = new AppDbContext();
    private List<Entity> dataFromSpreadsheet = new List<Entity>();

    [GlobalSetup]
    public void Setup()
    {
        _context.Database.EnsureCreated();

        //INFO: DUPLICATE DATA FROM DATABASE
        for (int i = 1; i <= 5_000; i++)
        {
            dataFromSpreadsheet.Add(new Entity
            {
                DistrictCode = "District-" + i,
                SegmentBusinessName = "Segment Business Name " + i,
                ParameterDescName = "Formula " + i,
                CustomerCode = "Customer-" + i,
                IsForContract = i % 2 == 0 ? "Yes" : "No",
                IsForAccrue = i % 2 == 1 ? "Yes" : "No",
            });
        }

        //INFO: UNIQUE DATA
        for (int i = 1000_001; i <= 1003_000; i++)
        {
            dataFromSpreadsheet.Add(new Entity
            {
                DistrictCode = "District-" + i,
                SegmentBusinessName = "Segment Business Name " + i,
                ParameterDescName = "Formula " + i,
                CustomerCode = "Customer-" + i,
                IsForContract = i % 2 == 0 ? "Yes" : "No",
                IsForAccrue = i % 2 == 1 ? "Yes" : "No",
            });
        }

        //INFO: DUPLICATE EXCEL DATA
        var random = new Random();
        int listSize = dataFromSpreadsheet.Count;
        for (int i = 0; i < 2000; i++)
        {
            int duplicateIndex = random.Next(0, listSize);
            dataFromSpreadsheet.Add(new Entity
            {
                DistrictCode = dataFromSpreadsheet[duplicateIndex].DistrictCode,
                SegmentBusinessName = dataFromSpreadsheet[duplicateIndex].SegmentBusinessName,
                ParameterDescName = dataFromSpreadsheet[duplicateIndex].ParameterDescName,
                CustomerCode = dataFromSpreadsheet[duplicateIndex].CustomerCode,
                IsForContract = dataFromSpreadsheet[duplicateIndex].IsForContract,
                IsForAccrue = dataFromSpreadsheet[duplicateIndex].IsForAccrue
            });
        }
    }


    [Benchmark]
    public void HashSetAndContains()
    {
        var dbEntitiesSet = _context.Entities
            .Select(e => Entity.ToUnique(e).CloneLower())
            .ToHashSet();
        var nonExistingEntities = dataFromSpreadsheet
            .Select(e => Entity.ToUnique(e).CloneLower())
            .Where(e => !dbEntitiesSet.Contains(e));

        int count = nonExistingEntities.Count();
    }

    [Benchmark]
    public void DictionaryAndContains()
    {
        var dbEntitiesDict = _context.Entities
            .ToDictionary(
                key => Entity.ToUnique(key).CloneLower(),
                value => value
            );
        var nonExistingEntities = dataFromSpreadsheet
            .Select(e => Entity.ToUnique(e).CloneLower())
            .Where(e => !dbEntitiesDict.ContainsKey(e));

        int count = nonExistingEntities.Count();
    }

    [Benchmark]
    public void ListAndPredicate()
    {
        var predicate = PredicateBuilder.New<Entity>(false);

        foreach (var item in dataFromSpreadsheet)
        {
            predicate = predicate.Or(data =>
                string.Equals(data.DistrictCode.ToLower(), item.DistrictCode.ToLower())
                && string.Equals(data.SegmentBusinessName.ToLower(), item.SegmentBusinessName.ToLower())
                && string.Equals(data.CustomerCode.ToLower(), item.CustomerCode.ToLower())
                && string.Equals(data.ParameterDescName.ToLower(), item.ParameterDescName.ToLower()));
        }

        var existingEntities = _context.Entities.Where(predicate).ToList();
        var existingEntitiesToUniqueIdentifier = existingEntities.Select(e => Entity.ToUnique(e).CloneLower()).ToList();
        var nonExistingEntities = dataFromSpreadsheet
            .Select(e => Entity.ToUnique(e).CloneLower())
            .Except(existingEntitiesToUniqueIdentifier)
            .ToList();

        int count = nonExistingEntities.Count;
    }

    [Benchmark]
    public void ListAndLINQ()
    {
        var dbEntitiesList = _context.Entities
            .Select(e => Entity.ToUnique(e))
            .ToList();
        var nonExistingEntities = dataFromSpreadsheet
            .Select(e => Entity.ToUnique(e))
            .Where(e => !dbEntitiesList.Any(db =>
                string.Equals(db.CustomerCode, e.CustomerCode, StringComparison.OrdinalIgnoreCase)
                && string.Equals(db.DistrictCode, e.DistrictCode, StringComparison.OrdinalIgnoreCase)
                && string.Equals(db.SegmentBusinessName, e.SegmentBusinessName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(db.ParameterDescName, e.ParameterDescName, StringComparison.OrdinalIgnoreCase))
            );

        int count = nonExistingEntities.Count();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _context.Dispose();
    }
}
