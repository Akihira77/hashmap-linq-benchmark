using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

// BenchmarkRunner.Run<Benchmarker_100_Element>(
//     ManualConfig.Create(DefaultConfig.Instance)
//         .WithOptions(ConfigOptions.DisableOptimizationsValidator)
//         .WithOptions(ConfigOptions.KeepBenchmarkFiles)
//         .WithOptions(ConfigOptions.DontOverwriteResults));

// BenchmarkRunner.Run<Benchmarker_1000_Element>(
//     ManualConfig.Create(DefaultConfig.Instance)
//         .WithOptions(ConfigOptions.DisableOptimizationsValidator)
//         .WithOptions(ConfigOptions.KeepBenchmarkFiles)
//         .WithOptions(ConfigOptions.DontOverwriteResults));

BenchmarkRunner.Run<Benchmarker_10000_Element>(
    ManualConfig.Create(DefaultConfig.Instance)
        .WithOptions(ConfigOptions.DisableOptimizationsValidator)
        .WithOptions(ConfigOptions.KeepBenchmarkFiles)
        .WithOptions(ConfigOptions.DontOverwriteResults));

// BenchmarkRunner.Run<HashMapBenchmarker_100000>(
//     ManualConfig.Create(DefaultConfig.Instance)
//         .WithOptions(ConfigOptions.DisableOptimizationsValidator)
//         .WithOptions(ConfigOptions.KeepBenchmarkFiles)
//         .WithOptions(ConfigOptions.DontOverwriteResults));

// BenchmarkRunner.Run<HashMapBenchmarker_1000000>(
//     ManualConfig.Create(DefaultConfig.Instance)
//         .WithOptions(ConfigOptions.DisableOptimizationsValidator)
//         .WithOptions(ConfigOptions.KeepBenchmarkFiles)
//         .WithOptions(ConfigOptions.DontOverwriteResults));
